using Microsoft.AspNetCore.Http;
using PersonalPortfolioApp.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.ViewModels
{
    public class CerateViewModel
    {
        public int PersonalId { get; set; }
        public string PersonName { get; set; }

        public int CountryId { get; set; }
        

        public int CityId { get; set; }

        public string DateOfBirth { get; set; }

        public IFormFile Files { get; set; }
        public  List<int> Skills { get; set; }


    }
}
