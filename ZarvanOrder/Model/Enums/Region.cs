using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZarvanOrder.Model.Enums
{
    public class Region
    {
        public enum Level
        {
            [Display(Name = "قاره")]
            Continent = 1,
            [Display(Name = "کشور")]
            Country = 2,
            [Display(Name = "استان")]
            Province = 3,
            [Display(Name = "شهر")]
            City = 4,
            [Display(Name = "منطقه")]
            Region = 5,
            [Display(Name ="مسیر")]
            Path = 6
        }
    }
}
