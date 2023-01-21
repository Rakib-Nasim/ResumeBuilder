using PersonalPortfolioApp.Models.Entitys;
using PersonalPortfolioApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Logicc
{
    public interface IGetAllPerson
    {
        public IEnumerable<PersonalViewModel> GetAllPersonal();
        public IEnumerable<CityModel> GetAllCity(int id);
        public IEnumerable<CountryModel> GetAllCountry();
        public IEnumerable<SkillModel> GetAllSkill();

        public void Create(CerateViewModel model);

        public int Delete(int id);

        //public IEnumerable<SkillModel> GetAllSkill();
    }
}
