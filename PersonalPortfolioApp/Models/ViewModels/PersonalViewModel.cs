using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.ViewModels
{
    public class PersonalViewModel
    {
        public int PersonalId { get; set; }
        public string PersonName { get; set; }

        public string CountryName { get; set; }


        public string CityName { get; set; }

        public string DateOfBirth { get; set; }

        public string Photo { get; set; }
        public string Skill { get; set; }
        public string Images { get; set; }
        public byte[] Files { get; set; }
        public List<string> Skills { get; set; }
    }
    
}
