using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.Models.Entitys
{
    public class Personal_Skill
    {
        [Key ]
        public int Id { get; set; }

        public int PersonalId { get; set; }
        public virtual PersoalModel Personal { get; set; }


        public int SkillId { get; set; }
        public virtual SkillModel Skill { get; set; }
    }
}
