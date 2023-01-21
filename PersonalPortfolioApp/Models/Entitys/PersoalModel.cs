using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.Entitys
{
    public class PersoalModel
    {
        
        [Key]
        public int PersonalId { get; set; }
        [Required]
        public string PersonName { get; set; }


        public int CountryId { get; set; }
        public virtual CountryModel Country { get; set; }

        public int CityId { get; set; }
        public virtual CityModel City { get; set; }

        public string DateOfBirth { get; set; }

        [Required]
        public string Photo { get; set; }
        public virtual List<Personal_Skill> personal_Skill { get; set; }
    }
}
