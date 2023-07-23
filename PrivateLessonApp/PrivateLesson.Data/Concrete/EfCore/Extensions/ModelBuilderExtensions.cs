using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> roles = new List<Role>()
            {
                new Role{Name="Admin", Description="Yöneticiler",NormalizedName="ADMIN" },
                new Role{Name="Öğretmen", Description="Öğretmenler", NormalizedName="OGRETMEN"},
                new Role {Name="Öğrenci", Description="Öğrenciler", NormalizedName="OGRENCI"}
            };
            modelBuilder.Entity<Role>().HasData(roles);

            #endregion

            #region Kullanıcı Bilgileri

            List<User> users = new List<User>()
            {
                //Admin
               new User {
                   FirstName="İlknur", 
                   LastName="Kartop", 
                   UserName="ilknurkartop", 
                   NormalizedUserName="ILKNURKARTOP", 
                   Email="ilknurkartop@hotmail.com", 
                   NormalizedEmail="ILKNURKARTOP@HOTMAIL.COM", 
                   Gender="Kadın", 
                   DateOfBirth= new DateTime(1997,7,16), 
                   City="İstanbul",
                   Phone = "5555555555",
                   EmailConfirmed=true, 
                   ImageId = 5}, 
                //Students
                new User {
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    UserName = "ahmetyilmaz",
                    NormalizedUserName = "AHMETYILMAZ",
                    Email = "ahmet.yilmaz@example.com",
                    NormalizedEmail = "AHMET.YILMAZ@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1988, 3, 22),
                    City = "Ankara",
                    Phone = "5551234567",
                    EmailConfirmed = true,
                   ImageId = 5
                },

                new User {
                    FirstName = "Selin",
                    LastName = "Özcan",
                    UserName = "selinozcan",
                    NormalizedUserName = "SELINOZCAN",
                    Email = "selin.ozcan@example.com",
                    NormalizedEmail = "SELIN.OZCAN@EXAMPLE.COM",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1995, 5, 12),
                    City = "İzmir",
                    Phone = "5559876543",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Mehmet",
                    LastName = "Kaya",
                    UserName = "mehmetkaya",
                    NormalizedUserName = "MEHMETKAYA",
                    Email = "mehmet.kaya@example.com",
                    NormalizedEmail = "MEHMET.KAYA@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1990, 11, 7),
                    City = "Antalya",
                    Phone = "5551112233",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Seda",
                    LastName = "Doğan",
                    UserName = "sedadogan",
                    NormalizedUserName = "SEDADOGAN",
                    Email = "seda.dogan@example.com",
                    NormalizedEmail = "SEDA.DOGAN@EXAMPLE.COM",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1998, 2, 25),
                    City = "Bursa",
                    Phone = "5554445566",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Murat",
                    LastName = "Güneş",
                    UserName = "muratgunes",
                    NormalizedUserName = "MURATGUNES",
                    Email = "murat.gunes@example.com",
                    NormalizedEmail = "MURAT.GUNES@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1985, 9, 3),
                    City = "İstanbul",
                    Phone = "5558889999",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Ayşe",
                    LastName = "Yıldız",
                    UserName = "ayseyildiz",
                    NormalizedUserName = "AYSEYILDIZ",
                    Email = "ayse.yildiz@example.com",
                    NormalizedEmail = "AYSE.YILDIZ@EXAMPLE.COM",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1991, 12, 15),
                    City = "Ankara",
                    Phone = "5553334444",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Ercan",
                    LastName = "Öztürk",
                    UserName = "ercanozturk",
                    NormalizedUserName = "ERCANOZTURK",
                    Email = "ercan.ozturk@example.com",
                    NormalizedEmail = "ERCAN.OZTURK@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1980, 6, 8),
                    City = "İzmir",
                    Phone = "5552223344",
                    EmailConfirmed = true,
                   ImageId = 5
                },

                new User {
                    FirstName = "Ali",
                    LastName = "Güler",
                    UserName = "aliguler",
                    NormalizedUserName = "ALIGULER",
                    Email = "ali.guler@example.com",
                    NormalizedEmail = "ALI.GULER@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1996, 4, 10),
                    City = "Adana",
                    Phone = "5557778899",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Hatice",
                    LastName = "Aydın",
                    UserName = "haticeaydin",
                    NormalizedUserName = "HATICEAYDIN",
                    Email = "hatice.aydin@example.com",
                    NormalizedEmail = "HATICE.AYDIN@EXAMPLE.COM",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1992, 11, 21),
                    City = "İstanbul",
                    Phone = "5551234567",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Mert",
                    LastName = "Kılıç",
                    UserName = "mertkilic",
                    NormalizedUserName = "MERTKILIC",
                    Email = "mert.kilic@example.com",
                    NormalizedEmail = "MERT.KILIC@EXAMPLE.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1987, 8, 5),
                    City = "Ankara",
                    Phone = "5551112233",
                    EmailConfirmed = true,
                   ImageId = 5
                },
                new User {
                    FirstName = "Aslı",
                    LastName = "Yılmaz",
                    UserName = "asliyilmaz",
                    NormalizedUserName = "ASLIYILMAZ",
                    Email = "asli.yilmaz@example.com",
                    NormalizedEmail = "ASLI.YILMAZ@EXAMPLE.COM",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1994, 1, 28),
                    City = "Bursa",
                    Phone = "5555556677",
                    EmailConfirmed = true,
                   ImageId = 5
                },


                //Teachers

                    new User {
                        FirstName = "Emre",
                        LastName = "Yıldır",
                        UserName = "emreyildir",
                        NormalizedUserName = "EMREYILDIR",
                        Email = "emre.yildir@example.com",
                        NormalizedEmail = "EMRE.YILDIR@EXAMPLE.COM",
                        Gender = "Erkek",
                        DateOfBirth = new DateTime(1991, 5, 17),
                        City = "İzmir",
                        Phone = "5558887744",
                        EmailConfirmed = true,
                        ImageId = 1
                    },
                    new User {
                        FirstName = "Ebru",
                        LastName = "Öztürk",
                        UserName = "ebruozturk",
                        NormalizedUserName = "EBRUOZTURK",
                        Email = "ebru.ozturk@example.com",
                        NormalizedEmail = "EBRU.OZTURK@EXAMPLE.COM",
                        Gender = "Kadın",
                        DateOfBirth = new DateTime(1985, 12, 3),
                        City = "Antalya",
                        Phone = "5552221133",
                        EmailConfirmed = true,
                        ImageId = 2
                    },
                    new User {
                        FirstName = "Umut",
                        LastName = "Çelik",
                        UserName = "umutcelik",
                        NormalizedUserName = "UMUTCELIK",
                        Email = "umut.celik@example.com",
                        NormalizedEmail = "UMUT.CELIK@EXAMPLE.COM",
                        Gender = "Erkek",
                        DateOfBirth = new DateTime(1999, 2, 14),
                        City = "Ankara",
                        Phone = "5552223344",
                        EmailConfirmed = true,
                        ImageId = 3
                    },
                    new User {
                        FirstName = "Aylin",
                        LastName = "Demir",
                        UserName = "aylindemir",
                        NormalizedUserName = "AYLINDEMIR",
                        Email = "aylin.demir@example.com",
                        NormalizedEmail = "AYLIN.DEMIR@EXAMPLE.COM",
                        Gender = "Kadın",
                        DateOfBirth = new DateTime(1988, 7, 8),
                        City = "İstanbul",
                        Phone = "5557779900",
                        EmailConfirmed = true,
                        ImageId = 4
                    },
                    new User {
                        FirstName = "Murat",
                        LastName = "Can",
                        UserName = "muratcan",
                        NormalizedUserName = "MURATCAN",
                        Email = "murat.can@example.com",
                        NormalizedEmail = "MURAT.CAN@EXAMPLE.COM",
                        Gender = "Erkek",
                        DateOfBirth = new DateTime(1997, 12, 20),
                        City = "İzmir",
                        Phone = "5556667788",
                        EmailConfirmed = true,
                        ImageId = 5
                    },
                    new User {
                        FirstName = "Elif",
                        LastName = "Akyıldız",
                        UserName = "elifakyildiz",
                        NormalizedUserName = "ELIFAKYILDIZ",
                        Email = "elif.akyildiz@example.com",
                        NormalizedEmail = "ELIF.AKYILDIZ@EXAMPLE.COM",
                        Gender = "Kadın",
                        DateOfBirth = new DateTime(1994, 3, 27),
                        City = "Ankara",
                        Phone = "5558887766",
                        EmailConfirmed = true,
                        ImageId = 5
                    },
                    new User {
                        FirstName = "Göksu",
                        LastName = "Demir",
                        UserName = "goksudemir",
                        NormalizedUserName = "GOKSUDEMIR",
                        Email = "goksu.demir@example.com",
                        NormalizedEmail = "GOKSU.DEMIR@EXAMPLE.COM",
                        Gender = "Kadın",
                        DateOfBirth = new DateTime(1992, 11, 29),
                        City = "İstanbul",
                        Phone = "5554443322",
                        EmailConfirmed = true,
                        ImageId = 5
                    },
                    new User {
                        FirstName = "Emre",
                        LastName = "Yıldız",
                        UserName = "emreyildiz",
                        NormalizedUserName = "EMREYILDIZ",
                        Email = "emre.yildiz@example.com",
                        NormalizedEmail = "EMRE.YILDIZ@EXAMPLE.COM",
                        Gender = "Erkek",
                        DateOfBirth = new DateTime(1985, 5, 17),
                        City = "Ankara",
                        Phone = "5301234567",
                        EmailConfirmed = true,
                        ImageId = 5
                    }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Öğrenci Bilgileri


            List<Student> students = new List<Student>() {
            new Student{
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[1].Id
                },
                new Student
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[2].Id
                },
                new Student
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[3].Id
                },
                new Student
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[4].Id
                },
                new Student
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[5].Id
                },
                new Student
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[6].Id
                },
                new Student
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[7].Id
                },
                new Student
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[8].Id

                },
                new Student
                {
                    Id = 9,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[9].Id
                },
                new Student
                {
                    Id = 10,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[10].Id
                }
            };
            modelBuilder.Entity<Student>().HasData(students);
            #endregion

            #region Öğretmen Bİlgileri

            List<Teacher> teachers = new List<Teacher>()
            {
                 new Teacher
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Kırıkkale Üniversitesi",
                    UserId=users[11].Id
                },
                new Teacher
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Orta Doğu Teknik Üniversitesi",
                    UserId=users[12].Id
                },
                new Teacher
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "İstanbul Teknik Üniversitesi",
                    UserId=users[13].Id
                },
                new Teacher
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Yıldız Teknik Üniversitesi",
                    UserId=users[14].Id
                },
                new Teacher
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Akdeniz Üniversitesi",
                    UserId=users[15].Id
                },
                new Teacher
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Erciyes Üniversitesi",
                    UserId=users[16].Id
                },
                new Teacher
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Çukurova Üniversitesi",
                    UserId=users[17].Id
                },
                new Teacher
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Uludağ Üniversitesi",
                    UserId=users[18].Id
                }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);

            #endregion


            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            //Admin

            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");

            //Student

            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
            users[4].PasswordHash = passwordHasher.HashPassword(users[4], "Qwe123.");
            users[5].PasswordHash = passwordHasher.HashPassword(users[5], "Qwe123.");
            users[6].PasswordHash = passwordHasher.HashPassword(users[6], "Qwe123.");
            users[7].PasswordHash = passwordHasher.HashPassword(users[7], "Qwe123.");
            users[8].PasswordHash = passwordHasher.HashPassword(users[8], "Qwe123.");
            users[9].PasswordHash = passwordHasher.HashPassword(users[9], "Qwe123.");
            users[10].PasswordHash = passwordHasher.HashPassword(users[10], "Qwe123.");

            //Teacher

            users[11].PasswordHash = passwordHasher.HashPassword(users[11], "Qwe123.");
            users[12].PasswordHash = passwordHasher.HashPassword(users[12], "Qwe123.");
            users[13].PasswordHash = passwordHasher.HashPassword(users[13], "Qwe123.");
            users[14].PasswordHash = passwordHasher.HashPassword(users[14], "Qwe123.");
            users[15].PasswordHash = passwordHasher.HashPassword(users[15], "Qwe123.");
            users[16].PasswordHash = passwordHasher.HashPassword(users[16], "Qwe123.");
            users[17].PasswordHash = passwordHasher.HashPassword(users[17], "Qwe123.");
            users[18].PasswordHash = passwordHasher.HashPassword(users[18], "Qwe123.");

            #endregion
         

            #region Rol Atama İşlemleri

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{UserId=users[0].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Admin").Id },

                new IdentityUserRole<string>{UserId=users[1].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[2].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[3].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[4].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[5].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[6].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[7].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[8].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[9].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },
                new IdentityUserRole<string>{UserId=users[10].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Öğrenci").Id },

                new IdentityUserRole<string>{UserId=users[11].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[12].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[13].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[14].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[15].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[16].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[17].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
                new IdentityUserRole<string>{UserId=users[18].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Öğretmen").Id},
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region AlışVeriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{Id=1, UserId=users[0].Id},
                new Cart{Id=2, UserId=users[1].Id},
                new Cart{Id=3, UserId=users[2].Id},
                new Cart{Id=4, UserId=users[3].Id},
                new Cart{Id=5, UserId=users[4].Id},
                new Cart{Id=6, UserId=users[5].Id},
                new Cart{Id=7, UserId=users[6].Id},
                new Cart{Id=8, UserId=users[7].Id},
                new Cart{Id=9, UserId=users[8].Id},
                new Cart{Id=10, UserId=users[9].Id},
                new Cart{Id=11, UserId=users[10].Id},
                new Cart{Id=12, UserId=users[11].Id},
                new Cart{Id=13, UserId=users[12].Id},
                new Cart{Id=14, UserId=users[13].Id},
                new Cart{Id=15, UserId=users[14].Id},
                new Cart{Id=16, UserId=users[15].Id},
                new Cart{Id=17, UserId=users[16].Id},
                new Cart{Id=18, UserId=users[17].Id},
                new Cart{Id=19, UserId=users[18].Id},
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion

            List<Advert> adverts = new List<Advert>()
            {
                new Advert{Id=1, TeacherId= 4, Description="dsdasd", Price=45, CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true, Url="dsdds",BranchId=4 }
            };
            modelBuilder.Entity<Advert>().HasData(adverts);
        }
    }
}
