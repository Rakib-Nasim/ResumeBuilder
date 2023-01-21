using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalPortfolioApp.DataAccess;
using PersonalPortfolioApp.Logicc;
using PersonalPortfolioApp.Models.Entitys;
using PersonalPortfolioApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalPortfolioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        IGetAllPerson _getAll;
        public PersonalController(IGetAllPerson getAll )
        {
            _getAll = getAll;
        }

        [HttpPost("CreatePerson")]
        public  IActionResult CreatePerson([FromForm] CerateViewModel model)
        {
             _getAll.Create(model);
            return Ok();
        }


        //[HttpGet("Get/{id}")]
        //public async Task<SkillViewModel> Get(int id)
        //{
        //    var list = await _dbContext.persoalModels.FindAsync(id);
        //    var listOfPerSkill = await _dbContext.personal_Skills.Where(x => x.PersonalId == id)
        //        .ToListAsync();


        //    List<string> val = new List<string>();
        //    foreach (var item in listOfPerSkill)
        //    {
        //        var name = await _dbContext.skillModels.FindAsync(item.SkillId);
        //        val.Add(name.SkillName);
        //    }
        //    StringBuilder line = new StringBuilder();
        //    var fullstring = String.Join(",", val);
        //    SkillViewModel model = new SkillViewModel()
        //    {
        //        PersonName = list.PersonName,
        //        Photo = list.Photo,
        //        CountryId = list.CountryId,
        //        CityId = list.CityId,
        //        DateOfBirth = list.DateOfBirth,
        //        Skills = fullstring
        //    };


        //    return model;
        //}

        [HttpGet("GetPersonal")]
        public IActionResult GetPersonal()
        {
            return Ok(_getAll.GetAllPersonal());
        }

        [HttpGet("GetAllSkill")]
        public IEnumerable<SkillModel> GetAllSkill()
        {
            return _getAll.GetAllSkill();
        }

        [HttpGet("GetAllCountry")]
        public IEnumerable<CountryModel> GetAllCountry()
        {
            return _getAll.GetAllCountry();
        }

        [HttpGet("GetAllCity/{id}")]
        public IEnumerable<CityModel> GetAllCity(int id)
        {
            return _getAll.GetAllCity(id); 
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {

            if (_getAll.Delete(id) > 0) 
            {
                return Ok("Delete Successfully");
            };
            return Ok("There Is No Entity For Delete");
        }
    }
}


