using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.Entitys
{
    public class CountryModel
    {
        public CountryModel()
        {
            this.ListCity = new List<CityModel>();
        }
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public virtual List<CityModel> ListCity{ get; set; }
    }
}
