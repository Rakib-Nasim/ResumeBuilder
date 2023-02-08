using Microsoft.EntityFrameworkCore;
using PersonalPortfolioApp.DataAccess;
using PersonalPortfolioApp.Models.Entitys;
using PersonalPortfolioApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Logicc
{
    public class GetAllPerson:IGetAllPerson
    {
        ApplicationDbContext _dbContext;
        public GetAllPerson(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(CerateViewModel model)
        {
            string uniqfilename = null;
            if (model.Files != null)
            {
                string upldfil = Path.Combine(Directory.GetCurrentDirectory(), "Photo");
                uniqfilename = Guid.NewGuid().ToString() + "_" + model.Files.FileName;
                string filePath = Path.Combine(upldfil, uniqfilename);
                model.Files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            PersoalModel person = new PersoalModel()
            {
                PersonalId = 0,
                PersonName = model.PersonName,
                CountryId = model.CountryId,
                CityId = model.CityId,
                DateOfBirth = model.DateOfBirth,
                Photo = uniqfilename
            };
             _dbContext.persoalModels.Add(person);
             _dbContext.SaveChanges();

            var lastColumn = _dbContext.persoalModels.OrderBy(x => x.PersonalId).LastOrDefault();


            foreach (var item in model.Skills)
            {
                Personal_Skill skill = new Personal_Skill()
                {
                    SkillId = item,
                    PersonalId = lastColumn.PersonalId
                };
                _dbContext.personal_Skills.Add(skill);
                int result = _dbContext.SaveChanges();
            }

        }

        public int Delete(int id)
        {
            var obj= _dbContext.persoalModels.Where(x=>x.PersonalId==id).Include(x=>x.personal_Skill).ToList();
            if (obj.Count() >0)
            {
                _dbContext.persoalModels.Remove(obj[0]);
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
            
        }

        public IEnumerable<CityModel> GetAllCity(int id)
        {
           return _dbContext.cityModels.Where(c => c.CountryId == id).ToList();
        }

        public IEnumerable<CountryModel> GetAllCountry()
        {
            return _dbContext.countryModels.ToList();
        }

        public IEnumerable<PersonalViewModel> GetAllPersonal()
        {
            List<PersonalViewModel> tota = new List<PersonalViewModel>();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Photo\\");

            var listAll = from c in _dbContext.persoalModels
                          join w in _dbContext.countryModels
                          on c.CountryId equals w.CountryId
                          join m in _dbContext.cityModels
                          on c.CityId equals m.CityId
                          select new PersonalViewModel
                          {
                              PersonalId=c.PersonalId,
                              PersonName = c.PersonName,
                              CountryName = w.CountryName,
                              CityName = m.CityName,
                              DateOfBirth = c.DateOfBirth,
                              Photo = c.Photo,
                              Skills = c.personal_Skill.Select(x => x.Skill.SkillName).ToList(),
                              Files = File.ReadAllBytes(filePath + c.Photo)
                          };


                        foreach (var item in listAll)
                        {
                            PersonalViewModel lst = new PersonalViewModel()
                            {
                                PersonalId=item.PersonalId,
                                PersonName = item.PersonName,
                                CountryName = item.CountryName,
                                CityName = item.CityName,
                                DateOfBirth = item.DateOfBirth,
                                Skill = item.Skills.Aggregate((a, b) => a + "," + b),
                                Images = Convert.ToBase64String(item.Files),
                                Photo = item.Photo
                            };
                            tota.Add(lst);
                        }
            return tota;
        }

        public IEnumerable<SkillModel> GetAllSkill()
        {
          return _dbContext.skillModels.ToList();
        }

        //SqlCommand cmd = new SqlCommand("GetOrder", conn);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@Id",id);
        //conn.Open();
        //int rowAffected = cmd.ExecuteNonQuery();
        //conn.Close();



        //var orderId = new SqlParameter("@Id", id);
        //var order = _dbContext.Database.ExecuteSqlRaw("EXEC GetOrder @Id", orderId);
        //var nm = 2;



    }
}
