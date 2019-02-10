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

namespace HengYuan.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
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

            ViewData["image"] = Path.GetFileName(array1[0]);
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
