using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVocal.Model.Models;

namespace MyVocal.Data
{
    public class MyVocalDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyVocalDbContext() : base("MyVocalConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        public DbSet<Semantic> Semantics { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectGroup> SubjectGroups { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<WordCategory> WordCategories { get; set; }

        public DbSet<Error> Errors { get; set; }

        public static MyVocalDbContext Create()
        {
            return new MyVocalDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i =>  i.UserId );
        }
    }
}