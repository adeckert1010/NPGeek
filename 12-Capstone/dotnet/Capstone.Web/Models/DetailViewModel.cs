using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set; }
        public IList<Weather> Weathers { get; set; }
        public bool IsF { get; set; } = true;

        public DetailViewModel(Park park, IList<Weather> weathers)
        {
            this.Park = park;
            this.Weathers = weathers;
        }


    }
}
