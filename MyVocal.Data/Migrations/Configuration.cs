namespace MyVocal.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            if (context.WordCategories.Count() == 0) {
                context.WordCategories.AddOrUpdate(
                    new WordCategory { CategoryName = @"Danh từ", Identify = @"(n)" },
                    new WordCategory { CategoryName = @"Động từ", Identify = @"(v)" },
                    new WordCategory { CategoryName = @"Tính từ", Identify = @"(adj)" }
                );

            }

            //  This method will be called after migrating to the latest version.

            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyVocalDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MyVocalDbContext()));

            //     [MaxLength(100)]
            //public string FullName { set; get; }
            //[MaxLength(600)]
            //public string Description { set; get; }

            //public DateTime? CreateDate { set; get; }

            //[MaxLength(300)]
            //public string ImageAvatar { set; get; }

            //public int? WordRememeber { set; get; }


            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "tdthinh1995@gmail.com",
                EmailConfirmed = true,
                FullName = @"Trịnh Đức Thịnh",
                Description = "Admin",
                CreateDate = DateTime.Now,
                WordRememeber=0
            };

            manager.Create(user, "123456$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tdthinh1995@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            // context.Database.ExecuteSqlCommand("Delete FROM WordCategories;");
        }
    }
}