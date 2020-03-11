    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        private ISurveyResultDAO surveyResultDAO;
        public SurveyController(ISurveyResultDAO surveyResultDAO)
        {
            this.surveyResultDAO = surveyResultDAO;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results()
        {
            IList<SurveyResultsModel> surveyResults =  surveyResultDAO.GetPopularParks();
            return View(surveyResults);
        }

        public IActionResult SubmitSurvey(SurveyModel survey)
        {
            surveyResultDAO.SubmitSurvey(survey);
            return RedirectToAction("Results");
        }

    }
}