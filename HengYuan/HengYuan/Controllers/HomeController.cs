using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HengYuan.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using HengYuan.Data;
using System.Net;
using HengYuan.Data.Repository;
using Newtonsoft.Json;
using System.Globalization;

namespace HengYuan.Controllers
{
    public class HomeController : Controller
    {

        private IHttpContextAccessor _accessor;
        private readonly IRepository _repo;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment,
            IHttpContextAccessor accessor,
            IRepository repo
            )
        {
            _hostingEnvironment = hostingEnvironment;
            _accessor = accessor;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            // Get all image paths from wwwroot/products 
            string webRootPath = _hostingEnvironment.WebRootPath;
            string imageFolderPath = Path.Combine(webRootPath, "images", "products");

            var array1 = Directory.GetFiles(imageFolderPath).ToList();

            List<MyImage> images = new List<MyImage>();
            foreach (var item in array1)
            {
                MyImage myImage = new MyImage
                {
                    Path = Path.GetFileName(item)
                };
                images.Add(myImage);
            }

            await RecordVisitor();
            return View(images);
        }


        public async Task<bool> RecordVisitor()
        {
            string ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var vi = _repo.GetVisitor(ip);
            if (vi == null)
            {

                IpInfo ipInfo = new IpInfo();
                try
                {
                    string info = new WebClient().DownloadString("http://api.ipstack.com/" + ip + "?access_key=3d8b4b81ee9fa77ef95b73822a4c09d5&format=1");
                    ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

                }
                catch (Exception)
                {
                    ipInfo.Country_name = null;
                }

                Visitor newVisitor = new Visitor
                {
                    IPAddress = ip,
                    Country = ipInfo.Country_name,
                    City = ipInfo.City,
                    Longtitude = ipInfo.Longitude,
                    Latitude = ipInfo.Latitude
                };
                _repo.AddVisitor(newVisitor);
                await _repo.SaveChangesAsync();
            }
            else
            {
                DateTime currentTime = DateTime.Now.ToLocalTime();
                int result = currentTime.CompareTo(vi.RecentVisitTime.AddMinutes(30));
                if (result > 0)
                {
                    // Update visit time +1
                    vi.VisitTimes += 1;
                    vi.RecentVisitTime = currentTime;
                    _repo.UpdateVisitor(vi);
                    await _repo.SaveChangesAsync();
                }
            }
            // Not save the same IP witin 30mins 

            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
