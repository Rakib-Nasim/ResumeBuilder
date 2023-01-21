using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.Entitys
{
    public class SkillModel
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int? Active { get; set; }
        public virtual List<Personal_Skill> personal_Skill { get; set; }
    }
}
