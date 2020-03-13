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
using static Capstone.Web.Models.WeatherModelFromJSON;
using System.Net.Http;
using Newtonsoft.Json;

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

        public async Task<ActionResult> Detail(string parkCode)
        {
            Datum[] dataArray = null;
            var park = parkDAO.GetPark(parkCode);

            //accessing weather by database
            //var weather = weatherDAO.GetWeather(parkCode);
            //bool isFahrenheit = HttpContext.Session.Get<bool>("isF");
            DetailViewModel detail = new DetailViewModel(park);
            string latitude = park.Latitude.ToString();
            string longitude = park.Longitude.ToString();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.darksky.net/forecast/11f6def22a0f23b0acdf9167bb8f7bf5/");
                //HTTP GET
                var responseTask = client.GetAsync(latitude + "," + longitude + "?exclude=currently,minutely,hourly,alerts,flags");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var weatherArray = JsonConvert.DeserializeObject<Rootobject>(content).daily.data;
                    for (int i = 1; i < 6; i++)
                    {
                        Weather w = new Weather();
                        w.LowTemp = (int)weatherArray[i].temperatureLow;
                        w.HighTemp = (int)weatherArray[i].temperatureHigh;
                        w.ForecastString = weatherArray[i].icon;
                        w.FiveDayForecastValue = i;
                        w.ParkCode = parkCode;
                        detail.Weathers.Add(w);
                    }

                }
            }

            ViewData["dataArray"] = dataArray;


            if (HttpContext.Session.Keys.Contains("isF") == false)
            {
                HttpContext.Session.Set<bool>("isF", true);
            }

            foreach (Weather w in detail.Weathers)
            {
                w.isF = HttpContext.Session.Get<bool>("isF");
            }

            bool isF = HttpContext.Session.Get<bool>("isF");
            ViewData["isF"] = isF;

            
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
