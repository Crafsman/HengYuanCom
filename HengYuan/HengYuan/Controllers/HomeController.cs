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

namespace HengYuan.Controllers
{
    public class HomeController : Controller
    {

        private IHttpContextAccessor _accessor;
        private readonly AppDbContext _appDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment,
            IHttpContextAccessor accessor,
            AppDbContext appDbcontext
            )
        {
            _hostingEnvironment = hostingEnvironment;
            _accessor = accessor;
            _appDbContext = appDbcontext;
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
                MyImage myImage = new MyImage();
                myImage.Path = Path.GetFileName(item);
                images.Add(myImage);
            }
            string ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            ViewData["IPAddress"] = ip;
            ViewData["image"] = Path.GetFileName(array1[0]);

            Visitor visitor = new Visitor
            {
                IPAddress = ip,

            };


            // Not save the same IP witin 30mins 
            // Save it to when disconnect the website   Response.IsClientConnected
            _appDbContext.Visitors.Add(visitor);
            await _appDbContext.SaveChangesAsync();
            if (HttpContext.RequestAborted.IsCancellationRequested == true)
            {
                //
            }


            return View(images);
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
