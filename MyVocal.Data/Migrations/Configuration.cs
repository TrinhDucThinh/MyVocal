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
            
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyVocalDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MyVocalDbContext()));
            ////Add user
            //var user = new ApplicationUser()
            //{
            //    UserName = "admin",
            //    Email = "tdthinh1995@gmail.com",
            //    EmailConfirmed = true,
            //    FullName = @"Trịnh Đức Thịnh",
            //    Description = "Admin",
            //    CreateDate = DateTime.Now,
            //    WordRememeber = 0
            //};

            //manager.Create(user, "123456$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tdthinh1995@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            #endregion
            // context.Database.ExecuteSqlCommand("Delete FROM WordCategories;");
            //Add Word
            if (context.Words.Count() == 0)
            {
                context.Words.AddOrUpdate(
                    new Word { WordName = "accountant",
                               Defination = @"someone who keeps or examines the records of money received, paid, and owed by a company or person",
                               Synonym = @"book-keeper",
                               Transcription = @"/əˈkaʊntənt/",
                               WordCategoryId = 5,
                               Sound = @"UploadFiles\Audios\_accountant.mp3",
                               Image = @"UploadFiles\images\accountant.jpg",
                               SubjectId = 8,
                               Example = @"Her husband is an accountant of her company.",
                               ExampleTranslation = @"Người chồng chính là kế toán viên của công ty cô ta.",
                               SoundExample = @"UploadFiles\Audios\example_accountant.mp3" }
                );
            }else
            {
                context.Words.AddOrUpdate(
                    new Word {  WordName = "actor",
                                Meaning=@"Nam diễn viên",
                                Defination = @"someone who pretends to be someone else while performing in a film, play, or television or radio program",
                                Synonym = @"",
                                Transcription = @"/ˈæktə(r)/",
                                WordCategoryId = 5,
                                Sound = @"0B_QESOpwSu7sUWV0VWx6RENzYTA",
                                Image = @"UploadFiles\images\actor.jpg",
                                SubjectId = 8,
                                Example = @"Who's your favourite actor?",
                                ExampleTranslation = @"Nam diễn viên yêu thích của bạn là ai?",
                                SoundExample = @"0B_QESOpwSu7sRnlkSU8yWnU2OVE"
                    },
                    new Word
                    {
                                WordName = "actress",
                                Meaning=@"Nữ diễn viên",
                                Defination = @"a female actor",
                                Synonym = @"performer, player",
                                Transcription = @"/ˈæktrəs/",
                                WordCategoryId = 5,
                                Sound = @"0B_QESOpwSu7sMV9jUWpOcHRvQ0E",
                                Image = @"UploadFiles\images\actress.jpg",
                                SubjectId = 8,
                                Example = @"She's the highest-paid actress in Hollywood",
                                ExampleTranslation = @"Cô ấy là nữ diễn viên được trả cao nhất ở Hollywood.",
                                SoundExample = @"0B_QESOpwSu7sVXV3eG90aHZxTnc"
                    },
                    new Word
                    {
                        WordName = "architect",
                        Meaning = @"Kiến trúc sư",
                        Defination = @"a person whose job is to design new buildings and make certain that they are built correctly",
                        Synonym = @"",
                        Transcription = @"/ˈɑːkɪtekt/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sYzN3WXpOTXNPc3M",
                        Image = @"UploadFiles\images\architect.jpg",
                        SubjectId = 8,
                        Example = @"Peter is the architect of England",
                        ExampleTranslation = @"Peter là kiến ​​trúc sư người Anh",
                        SoundExample = @"0B_QESOpwSu7sb2NJTzFfbnh4M1k"
                    },
                    new Word
                    {
                        WordName = "artist",
                        Meaning = @"Họa sĩ",
                        Defination = @"someone who paints, draws, or makes sculptures",
                        Synonym = @"",
                        Transcription = @"/ˈɑːtɪst/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sVVFMczdhbTFaTlU",
                        Image = @"UploadFiles\images\artist_1.jpg",
                        SubjectId = 8,
                        Example = @"John is one of my favourite artist",
                        ExampleTranslation = @"John là một trong những họa sĩ yêu thích của tôi.",
                        SoundExample = @"0B_QESOpwSu7sdURPM0xJVVdteGc"
                    },
                    new Word
                    {
                        WordName = "babysitter",
                        Meaning = @"người giữ trẻ",
                        Defination = @"a person who takes care of babies or children while their parents are away from home and is usually paid to do this",
                        Synonym = @"",
                        Transcription = @"/ˈbeɪbiˌsɪtə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sTWppR0tQMjZJRU0",
                        Image = @"UploadFiles\images\babysitter.jpg",
                        SubjectId = 8,
                        Example = @"I promised the babysitter that we'd be home by midnight",
                        ExampleTranslation = @"Tôi đã hứa với người giữ trẻ, chúng tôi sẽ về nhà lúc nửa đêm.",
                        SoundExample = @"0B_QESOpwSu7sSENvQnh3cHloTGs"
                    },
                    new Word
                    {
                        WordName = "baker",
                        Meaning = @"thợ làm bánh",
                        Defination = @"a person whose job is baking and selling bread and cakes",
                        Synonym = @"",
                        Transcription = @"/ˈbeɪkə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sTmtvME9CNnM2QTg",
                        Image = @"UploadFiles\images\baker.jpg",
                        SubjectId = 8,
                        Example = @"Jack is the best baker in town",
                        ExampleTranslation = @"Jack là thợ làm bánh giỏi nhất trong  thị trấn.",
                        SoundExample = @"0B_QESOpwSu7sbnJWTkVZby1idW8"
                    },
                    new Word
                    {
                        WordName = "barber",
                        Meaning = @"Thợ cắt tóc",
                        Defination = @"a man whose job is cutting men's hair",
                        Synonym = @"",
                        Transcription = @"/ˈbɑːbə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sR1ROMXVkQTA5UE0",
                        Image = @"UploadFiles\images\barber.jpg",
                        SubjectId = 8,
                        Example = @"Our hair salon should hire a skilled barber",
                        ExampleTranslation = @"Tiệm cắt tóc của chúng tôi cần tuyển một thợ hớt tóc có tay nghề.",
                        SoundExample = @"0B_QESOpwSu7sSTFmZHhqQkR1VXM"
                    },
                    new Word
                    {
                        WordName = "carpenter",
                        Meaning = @"Thợ mộc",
                        Defination = @"a person whose job is making and repairing wooden objects and structures",
                        Synonym = @"",
                        Transcription = @"/ˈkɑːpəntə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sZFdfaDNUcnlQT2M",
                        Image = @"UploadFiles\images\carpenter.jpg",
                        SubjectId = 8,
                        Example = @"Tom's uncle is a skilled carpenter.",
                        ExampleTranslation = @"Chú của Tom là thợ mộc có tay nghề giỏi.",
                        SoundExample = @"0B_QESOpwSu7sN0ZEaXRYOTJ3ZFk"
                    },
                    new Word
                    {
                        WordName = "cashier",
                        Meaning = @"Nhân viên thu ngân",
                        Defination = @"a person whose job is to receive and pay out money in a shop, bank, restaurant, etc.",
                        Synonym = @"teller, bank clerk, banker",
                        Transcription = @"/kæʃˈɪə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sNDVUZnF3c1R0d3c",
                        Image = @"UploadFiles\images\cashier_1.jpg",
                        SubjectId = 8,
                        Example = @">Service attitude of the cashier is very friendly.",
                        ExampleTranslation = @"Thái độ phục vụ của nhân viên thu ngân này rất thân thiện.",
                        SoundExample = @"0B_QESOpwSu7sWmtTMjd3R2sxVFU"
                    },
                    new Word
                    {
                        WordName = "chef",
                        Meaning = @"Đầu bếp",
                        Defination = @"a skilled and trained cook who works in a hotel or restaurant, especially the most important cook",
                        Synonym = @"cook",
                        Transcription = @"/ʃef/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sZ3h5X2hZMTVVLTA",
                        Image = @"UploadFiles\images\chef.jpg",
                        SubjectId = 8,
                        Example = @"He is one of the top chefs in France.",
                        ExampleTranslation = @"Ông ấy là một trong những đầu bếp hàng đầu ở Pháp.",
                        SoundExample = @"0B_QESOpwSu7sUC16eG1SZktfOHc"
                    },
                    new Word
                    {
                        WordName = "doctor",
                        Meaning = @"Bác sĩ",
                        Defination = @"a person with a medical degree whose job is to treat people who are ill or hurt",
                        Synonym = @"medic (informal), physician",
                        Transcription = @"/ˈdɒktə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sd3J2czFEOGFqZm8",
                        Image = @"UploadFiles\images\doctor.jpg",
                        SubjectId = 8,
                        Example = @"The doctor prescribed some pills.",
                        ExampleTranslation = @"Bác sĩ kê đơn một số thuốc.",
                        SoundExample = @"0B_QESOpwSu7sZy1qd1g2TW9LWjQ"
                    },
                    new Word
                    {
                        WordName = "engineer",
                        Meaning = @"Kỹ sư",
                        Defination = @"someone who keeps or examines the records of money received, paid, and owed by a company or person",
                        Synonym = @"",
                        Transcription = @"/əˈkaʊntənt/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sS1lhZEE3TU5yRWM",
                        Image = @"UploadFiles\images\engineer.jpg",
                        SubjectId = 8,
                        Example = @"Her husband is an accountant of her company.",
                        ExampleTranslation = @"Người chồng chính là kế toán viên của công ty cô ta.",
                        SoundExample = @"0B_QESOpwSu7sLVlHbFloYk9yVUU"
                    },
                    new Word
                    {
                        WordName = "farmer",
                        Meaning = @"Nông dân",
                        Defination = @"someone who owns or takes care of a field.",
                        Synonym = @"peasant",
                        Transcription = @"/ˈfɑːmə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sc1FuNkZaanZkRDg",
                        Image = @"UploadFiles\images\farmer.jpg",
                        SubjectId = 8,
                        Example = @"My father is a farmer.",
                        ExampleTranslation = @"Ba tôi là một nông dân.",
                        SoundExample = @"0B_QESOpwSu7sX2FZM21zM2V2WGs"
                    },
                    new Word
                    {
                        WordName = "homemaker",
                        Meaning = @"Người nội trợ",
                        Defination = @"a woman who manages a home and often raises children instead of earning money from a job.",
                        Synonym = @"",
                        Transcription = @"/ˈhəʊmmeɪkə(r)/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sQUwzaUkydTJ5T0k",
                        Image = @"UploadFiles\images\homemaker.jpg",
                        SubjectId = 8,
                        Example = @"My mother is a good homemaker.",
                        ExampleTranslation = @"Mẹ tôi là người nội trợ giỏi.",
                        SoundExample = @"0B_QESOpwSu7sTThwOXMwZEtIbDQ"
                    },
                    new Word
                    {
                        WordName = "lawyer",
                        Meaning = @"Luật sư",
                        Defination = @"someone whose job is to give advice to people about the law and speak for them in court",
                        Synonym = @"",
                        Transcription = @"/ˈlɔɪ(ə)r/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sVE9LVUdfd21hLVE",
                        Image = @"UploadFiles\images\lawyer.jpg",
                        SubjectId = 8,
                        Example = @"I want to see my lawyer before I say anything.",
                        ExampleTranslation = @"Tôi muốn nhìn thấy luật sư của tôi trước khi tôi nói bất cứ điều gì.",
                        SoundExample = @"0B_QESOpwSu7sS3hNbDNzNWpHdHc"
                    },
                    new Word
                    {
                        WordName = "nurse",
                        Meaning = @"Y tá",
                        Defination = @"a person whose job is to care for people who are ill or injured, especially in a hospital.",
                        Synonym = @"",
                        Transcription = @"/nərs/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sWFlyN25nR0NWN1U",
                        Image = @"UploadFiles\images\nurse_1.jpg",
                        SubjectId = 8,
                        Example = @"Her husband is an accountant of her company.",
                        ExampleTranslation = @"Người chồng chính là kế toán viên của công ty cô ta.",
                        SoundExample = @"0B_QESOpwSu7sTmJpc3RrelBNV1E"
                    },
                    new Word
                    {
                        WordName = "photographer",
                        Meaning = @"Thợ chụp ảnh",
                        Defination = @"someone who keeps or examines the records of money received, paid, and owed by a company or person",
                        Synonym = @"",
                        Transcription = @"/əˈkaʊntənt/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7sRmsycFo4Zl9lZjQ",
                        Image = @"UploadFiles\images\photographer.jpg",
                        SubjectId = 8,
                        Example = @"I am very grateful to the taking care of me that day.",
                        ExampleTranslation = @"Tôi rất biết ơn cô ý tá chăm sóc tôi ngày hôm đó.",
                        SoundExample = @"0B_QESOpwSu7sazhmVWJfQW1EUkE"
                    },
                    new Word
                    {
                        WordName = "secretary",
                        Meaning = @"Thư ký",
                        Defination = @"someone who works in an office, writing letters, making phone calls, and arranging meetings for a person or for an organization.",
                        Synonym = @"",
                        Transcription = @"/ˈsekrətri/",
                        WordCategoryId = 5,
                        Sound = @"0B_QESOpwSu7scGF1dmFpaVpyVXc",
                        Image = @"UploadFiles\images\secretary.jpg",
                        SubjectId = 8,
                        Example = @"My secretary will phone you to arrange a meeting.",
                        ExampleTranslation = @"Thư ký của tôi sẽ gọi điện cho bạn để sắp xếp một cuộc họp.",
                        SoundExample = @"0B_QESOpwSu7sSUVjeDg5eW1GbEU"
                    },
                      new Word
                      {
                          WordName = "teacher",
                          Meaning = @"Giáo viên",
                          Defination = @"someone whose job is to teach in a school or college.",
                          Synonym = @"instructor, educator, schoolteacher",
                          Transcription = @"/ˈtiːtʃə(r)/",
                          WordCategoryId = 5,
                          Sound = @"0B_QESOpwSu7sbk96aEtnWkY1N1U",
                          Image = @"UploadFiles\images\teacher.jpg",
                          SubjectId = 8,
                          Example = @"My dream is to become a teacher.",
                          ExampleTranslation = @"Ước mơ của tôi là trở thành một giáo viên.",
                          SoundExample = @"0B_QESOpwSu7sRTJtODV5THZNWmc"
                      }
                );
            }

        }
    }
}