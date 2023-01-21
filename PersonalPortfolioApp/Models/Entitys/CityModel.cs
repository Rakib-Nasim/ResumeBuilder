using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.Entitys
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }

        public int CountryId { get; set; }
        public virtual CountryModel Country{ get; set; }
    }
}
