using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultsModel
    {

       
        public int ReviewCount { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }

    }
}
