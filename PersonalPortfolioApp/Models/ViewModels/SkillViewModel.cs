using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.ViewModels
{
    public class SkillViewModel
    {
        public string PersonName { get; set; }

        public int CountryId { get; set; }


        public int CityId { get; set; }

        public string DateOfBirth { get; set; }

        public string Photo { get; set; }
        public string Skills { get; set; }
    }
}
