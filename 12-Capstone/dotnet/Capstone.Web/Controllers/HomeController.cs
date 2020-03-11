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

            DetailViewModel detail = new DetailViewModel(park, weather);
            return View(detail);
        }

        public IActionResult ChangeUnit(string parkCode)
        {
            var park = parkDAO.GetPark(parkCode);
            var weathers = weatherDAO.GetWeather(parkCode);
            bool isF = GetUnit();
            if (isF)
            {
                foreach(Weather weather in weathers)
                {
                    weather.ConvertTempToCelcius(weather.LowTemp, weather.HighTemp);
                }
                
            }
            else
            {
                foreach (Weather weather in weathers)
                {
                    weather.ConvertTempToFahrenheit(weather.LowTemp, weather.HighTemp);
                }
            }

            DetailViewModel detail = new DetailViewModel(park, weathers);
            return View("Detail", detail);
        }

        private bool GetUnit()
        {
            bool isF = HttpContext.Session.Get<bool>("isF");
            if (isF == false)
            {
                SetUnit(isF);
            }
            else
            {
                isF = false;
            }
            return isF;
        }

        private void SetUnit(bool isF)
        {
            HttpContext.Session.Set("isF", true);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
