namespace MyVocal.Data.Migrations
{
    using Model.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyVocal.Data.MyVocalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyVocal.Data.MyVocalDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.WordCategories.AddOrUpdate(
                    new WordCategory { CategoryName = @"Danh từ", Identify = @"(n)" },
                    new WordCategory { CategoryName = @"Động từ", Identify = @"(v)" },
                    new WordCategory { CategoryName = @"Tính từ", Identify = @"(adj)" }
                );
           // context.Database.ExecuteSqlCommand("Delete FROM WordCategories;");
        }
    }
}