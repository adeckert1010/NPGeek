﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;

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
            ViewData["weather"] = weather;
            return View(park);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
