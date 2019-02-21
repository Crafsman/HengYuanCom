using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HengYuan.Data.Repository;
using HengYuan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HengYuan.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IRepository _repo;

        public DashBoardController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            // Frome database get IPaddress and present to dashboard
            List<Visitor> visitors = _repo.GetAllVisitors();

            return View(visitors);

        }

        public ActionResult Map()
        {
            // Frome database get IPaddress and present to dashboard

            return View();

        }
        public static string GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://api.ipstack.com/" + ip + "?access_key=3d8b4b81ee9fa77ef95b73822a4c09d5&format=1");
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country_name);
                ipInfo.Country_name = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country_name = null;
            }

            return ipInfo.Country_name;
        }


        // GET: DashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}