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

            //Add subject in group let's go
            #region subject
            if (context.Subjects.Count() == 0)
            {
                context.Subjects.AddOrUpdate(
                        new Subject {SubjectName="Job",Description= @"Chủ đề JOB gồm 20 từ vựng được trình bày bằng Flashcards, nội dung xoay quanh những nghề nghiệp phổ biến trong xã hội như giáo viên, diễn viên, bác sĩ…", Identify="Job",Image= @"UploadFiles\images\job.jpg", SubjectGroupId=8,WordTotal=20},
                        new Subject { SubjectName = "Love", Description = @"Chủ đề LOVE gồm 20 từ vựng được trình bày bằng Flashcards, nội dung xoay quanh vấn đề tình yêu như con người, mối quan hệ, cảm xúc.", Identify = "", Image = @"UploadFiles\images\love.jpg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Place around town", Description = @" Chủ đề PLACE AROUND TOWN gồm 20 từ vựng được trình bày bằng Flashcards, nói về những địa điểm xuất hiện quanh ta.", Identify = "Place around town", Image = @"UploadFiles\images\place_around_town.jpeg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Holidays", Description = @"Chủ đề HOLIDAYS gồm 20 từ vựng được trình bày bằng Flashcards, nói về các ngày lễ lớn và các vấn đề liên quan khác.", Identify = "", Image = @"UploadFiles\images\holiday.jpg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Hobbies", Description = @" Chủ đề HOBBIES gồm 20 từ vựng được trình bày bằng Flashcards, nói về sở thích cá nhân.", Identify = "", Image = @"UploadFiles\images\hobby.jpg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Entertaiment", Description = @" Chủ đề ENTERTAINMENT gồm 20 từ vựng được trình bày bằng Flashcards, nói về các hình thức giải trí, vui chơi trong cuộc sống.", Identify = "", Image = @"UploadFiles\images\entertainment.jpg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Nature", Description = @" Chủ đề NATURE gồm 20 từ vựng được trình bày bằng Flashcards, nói về những sự vật, hiện tượng thiên nhiên quen thuộc với chúng ta.", Identify = "", Image = @"UploadFiles\images\nature.jpg", SubjectGroupId = 8, WordTotal = 20 },
                        new Subject { SubjectName = "Final test", Description = @"Tổng hợp 7 chủ đề", Identify = "", Image = @"UploadFiles\images\finalexam.jpg", SubjectGroupId = 8, WordTotal = 20 }
                    );
            }
            #endregion

            //Add group subject 
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

            //Add Word
            if (context.Words.Count() == 0)
            {
                context.Words.AddOrUpdate(
                    new Word { WordName = "accountant",Defination= @"someone who keeps or examines the records of money received, paid, and owed by a company or person", Synonym= @"book-keeper", Transcription = @"/əˈkaʊntənt/", WordCategoryId = 5, Sound = @"UploadFiles\Audios\_accountant.mp3", Image = @"UploadFiles\images\accountant.jpg", SubjectId = 8, Example = @"Her husband is an accountant of her company.", ExampleTranslation = @"Người chồng chính là kế toán viên của công ty cô ta.", SoundExample = @"UploadFiles\Audios\example_accountant.mp3" }
                );
            }

        }
    }
}