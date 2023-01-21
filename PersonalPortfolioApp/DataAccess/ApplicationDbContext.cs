using Microsoft.EntityFrameworkCore;
using PersonalPortfolioApp.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortfolioApp.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal_Skill>()
                .HasKey(PS => new { PS.Id });

            modelBuilder.Entity<Personal_Skill>()
                .HasOne(Pr => Pr.Personal)
                .WithMany(PS => PS.personal_Skill)
                .HasForeignKey(bc => bc.PersonalId)
                .OnDelete(DeleteBehavior.ClientCascade);

            //.OnDelete(DeleteBehavior.Cascade)

            modelBuilder.Entity<Personal_Skill>()
                .HasOne(bc => bc.Skill)
                .WithMany(c => c.personal_Skill)
                .HasForeignKey(bc => bc.SkillId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PersoalModel>()
                .HasKey(PS => new { PS.PersonalId });

            modelBuilder.Entity<PersoalModel>()
                .HasOne(bc => bc.Country)
                .WithMany()
                .HasForeignKey(bc => bc.CountryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PersoalModel>()
                .HasOne(bc => bc.City)
                .WithMany()
                .HasForeignKey(bc => bc.CityId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<CityModel>()
                .HasOne(bc => bc.Country)
                .WithMany(c => c.ListCity)
                .HasForeignKey(bc => bc.CountryId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }
        public DbSet<PersoalModel> persoalModels { get; set; }
        public DbSet<Personal_Skill> personal_Skills { get; set; }
        public DbSet<SkillModel> skillModels { get; set; }
        public DbSet<CityModel> cityModels { get; set; }
        public DbSet<CountryModel> countryModels { get; set; }




    }
}
