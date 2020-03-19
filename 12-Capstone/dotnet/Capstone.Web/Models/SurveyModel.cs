﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyID { get; set; }
        [Required]
        [Display(Name = "Pick your favorite park")]
        public string ParkCode { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Enter your email address")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "Please select a state from the list")]
        [Display(Name = "What state are you from?")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Describe your activity level")]
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> ParkNamesByCode = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Please make a selection", Value = ""},
            new SelectListItem() { Text = "Cuyahoga Valley", Value = "CVNP"},
            new SelectListItem() { Text = "Everglades", Value = "ENP"},
            new SelectListItem() { Text = "Grand Canyon", Value = "GCNP"},
            new SelectListItem() { Text = "Glacier", Value = "GNP"},
            new SelectListItem() { Text = "Great Smoky Mountains", Value = "GSMNP"},
            new SelectListItem() { Text = "Grand Teton", Value = "GTNP"},
            new SelectListItem() { Text = "Mount Rainier", Value = "MRNP"},
            new SelectListItem() { Text = "Rocky Mountain", Value = "RMNP"},
            new SelectListItem() { Text = "Yellowstone", Value = "YNP"},
            new SelectListItem() { Text = "Yosemite", Value = "YNP2"}
        };

        public static List<SelectListItem> States = new List<SelectListItem>()
        {
            new SelectListItem {Value = "", Text = "Please make a selection"},
            new SelectListItem { Value = "AL", Text = "Alabama" },
            new SelectListItem { Value = "AK", Text = "Alaska" },
            new SelectListItem { Value = "AZ", Text = "Arizona" },
            new SelectListItem { Value = "AR", Text = "Arkansas" },
            new SelectListItem { Value = "CA", Text = "California" },
            new SelectListItem { Value = "CO", Text = "Colorado" },
            new SelectListItem { Value = "CT", Text = "Connecticut" },
            new SelectListItem { Value = "DE", Text = "Delaware" },
            new SelectListItem { Value = "DC", Text = "District of Columbia"},
            new SelectListItem { Value = "FL", Text = "Florida" },
            new SelectListItem { Value = "GA", Text = "Georgia" },
            new SelectListItem { Value = "HI", Text = "Hawaii" },
            new SelectListItem { Value = "ID", Text = "Idaho" },
            new SelectListItem { Value = "IL", Text = "Illinois" },
            new SelectListItem { Value = "IN", Text = "Indiana" },
            new SelectListItem { Value = "IA", Text = "Iowa" },
            new SelectListItem { Value = "KS", Text = "Kansas" },
            new SelectListItem { Value = "KY", Text = "Kentucky" },
            new SelectListItem { Value = "LA", Text = "Louisiana" },
            new SelectListItem { Value = "ME", Text = "Maine" },
            new SelectListItem { Value = "MD", Text = "Maryland" },
            new SelectListItem { Value = "MA", Text = "Massachusetts" },
            new SelectListItem { Value = "MI", Text = "Michigan" },
            new SelectListItem { Value = "MN", Text = "Minnesota" },
            new SelectListItem { Value = "MS", Text = "Mississippi" },
            new SelectListItem { Value = "MO", Text = "Missouri" },
            new SelectListItem { Value = "MT", Text = "Montana" },
            new SelectListItem { Value = "NC", Text = "North Carolina" },
            new SelectListItem { Value = "ND", Text = "North Dakota" },
            new SelectListItem { Value = "NE", Text = "Nebraska" },
            new SelectListItem { Value = "NV", Text = "Nevada" },
            new SelectListItem { Value = "NH", Text = "New Hampshire" },
            new SelectListItem { Value = "NJ", Text = "New Jersey" },
            new SelectListItem { Value = "NM", Text = "New Mexico" },
            new SelectListItem { Value = "NY", Text = "New York" },
            new SelectListItem { Value = "OH", Text = "Ohio" },
            new SelectListItem { Value = "OK", Text = "Oklahoma" },
            new SelectListItem { Value = "OR", Text = "Oregon" },
            new SelectListItem { Value = "PA", Text = "Pennsylvania" },
            new SelectListItem { Value = "RI", Text = "Rhode Island" },
            new SelectListItem { Value = "SC", Text = "South Carolina" },
            new SelectListItem { Value = "SD", Text = "South Dakota" },
            new SelectListItem { Value = "TN", Text = "Tennessee" },
            new SelectListItem { Value = "TX", Text = "Texas" },
            new SelectListItem { Value = "UT", Text = "Utah" },
            new SelectListItem { Value = "VT", Text = "Vermont" },
            new SelectListItem { Value = "VA", Text = "Virginia" },
            new SelectListItem { Value = "WA", Text = "Washington" },
            new SelectListItem { Value = "WV", Text = "West Virginia" },
            new SelectListItem { Value = "WI", Text = "Wisconsin" },
            new SelectListItem { Value = "WY", Text = "Wyoming" }
        };
    }
}
