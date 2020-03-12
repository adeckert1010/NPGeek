using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private bool isF;

        public HomeController(IParkDAO parkSqlDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkSqlDAO;
            this.weatherDAO = weatherDAO;
        }


        public IActionResult Index()
        {
            var parks = parkDAO.GetParks();
            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            
            var park = parkDAO.GetPark(parkCode);
            var weather = weatherDAO.GetWeather(parkCode);
            //bool isFahrenheit = HttpContext.Session.Get<bool>("isF");

            if (HttpContext.Session.Keys.Contains("isF") == false)
            {
                HttpContext.Session.Set<bool>("isF", true);
            }

            foreach (Weather w in weather)
            {
                w.isF = HttpContext.Session.Get<bool>("isF");
            }

            bool isF = HttpContext.Session.Get<bool>("isF");
            ViewData["isF"] = isF;

            DetailViewModel detail = new DetailViewModel(park, weather);
            return View(detail);
        }

        public IActionResult ChangeUnit(string parkCode)
        {
            bool isFarenheit = HttpContext.Session.Get<bool>("isF");
            HttpContext.Session.Set("isF", !isFarenheit);
            return RedirectToAction("Detail", "Home", new { parkCode = parkCode });
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
