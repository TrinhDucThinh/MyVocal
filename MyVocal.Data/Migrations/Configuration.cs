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
            #region add wordCategory
            if (context.WordCategories.Count() == 0)
            {
                context.WordCategories.AddOrUpdate(
                    new WordCategory { CategoryName = @"Danh từ", Identify = @"(n)" },
                    new WordCategory { CategoryName = @"Động từ", Identify = @"(v)" },
                    new WordCategory { CategoryName = @"Tính từ", Identify = @"(adj)" }
                );

            }
            #endregion

            #region add SubjectGroup
            if (context.SubjectGroups.Count() == 0)
            {
                context.SubjectGroups.AddOrUpdate(
                        new SubjectGroup {SubjecGroupName=@"Let's go",Description= @" LET'S GO là sản phẩm đầu tay của hệ thống học từ vựng VOCA.VN, gồm 7 chủ đề từ vựng tiếng Anh thông dụng được thể hiện qua hình thức Flashcards thông minh hỗ trợ nhớ từ dễ dàng và sâu sắc.",Image= @"UploadFiles\images\let's_go.png"},
                        new SubjectGroup { SubjecGroupName = @"3000 ESSENTIAL WORDS in STORIES", Description = @"3000 Essential Words in Stories bao gồm 3000 từ vựng tiếng Anh thông dụng theo câu chuyện. Bộ từ nhắm đến mọi đối tượng những người học tiếng Anh giao tiếp, từ người có trình độ cơ bản tới nâng cao.", Image = @"UploadFiles\images\3000-essential-words.jpg" },
                        new SubjectGroup { SubjecGroupName = @"EffortLess English", Description = @"Với 1000 từ vựng được chọn lọc kĩ lưỡng từ 40 bài học trong giáo trình Original Effortless English của Tiến sỹ AJ Hoge, sẽ giúp người học tiếp cận phương pháp này dễ dàng, hiệu quả hơn.", Image = @"UploadFiles\images\effort.jpg" },
                        new SubjectGroup { SubjecGroupName = @"1000 Essential words in story", Description = @"1000 Essential Words in Stories (Beginner) với 60 chủ đề, cung cấp gần 1200 từ vựng tiếng Anh thông dụng trong giao tiếp. Bộ sản phẩm nhắm đến đối tượng mới bắt đầu học tiếng Anh.", Image = @"UploadFiles\images\voca-instories-improver.jpg" }
                );
            }
            #endregion
            //  This method will be called after migrating to the latest version.
            #region add user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyVocalDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MyVocalDbContext()));
            //Add user
            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "tdthinh1995@gmail.com",
                EmailConfirmed = true,
                FullName = @"Trịnh Đức Thịnh",
                Description = "Admin",
                CreateDate = DateTime.Now,
                WordRememeber = 0
            };

            manager.Create(user, "123456$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tdthinh1995@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            #endregion
            // context.Database.ExecuteSqlCommand("Delete FROM WordCategories;");
        }
    }
}