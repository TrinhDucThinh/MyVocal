using MyVocal.Model.Models;
using System.Data.Entity;

namespace MyVocal.Data
{
    public class MyVocalDbContext : DbContext
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}