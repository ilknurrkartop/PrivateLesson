using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
            builder.Property(x=>x.UserId).IsRequired();
            builder.HasOne(t => t.User).WithOne(t => t.Student).HasForeignKey<Student>(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasData(
            //   new Student
            //   {
            //       Id = 1,
            //       CreatedDate = DateTime.Now,
            //       UpdatedDate = DateTime.Now,
            //       IsApproved = true,
            //       UserId="",
            //       //FirstName = "Merve",
            //       //LastName = "Kaya",
            //       //Gender = "Kadın",
            //       //City = "İstanbul",
            //       //Url = "merve-kaya",
            //       //Phone = "5552345678",
            //       //Email = "mervekaya@gmail.com",
            //       ImageId = 5
            //   },
            //    new Student
            //    {
            //        Id = 2,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Deniz",
            //        //LastName = "Özkan",
            //        //Gender = "Erkek",
            //        //City = "İzmir",
            //        //Url = "deniz-ozkan",
            //        //Phone = "5553456789",
            //        //Email = "denizozkan@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 3,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Selin",
            //        //LastName = "Demir",
            //        //Gender = "Kadın",
            //        //City = "Ankara",
            //        //Url = "selin-demir",
            //        //Phone = "5554567890",
            //        //Email = "selindemir@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 4,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Ali",
            //        //LastName = "Yıldız",
            //        //Gender = "Erkek",
            //        //City = "İstanbul",
            //        //Url = "ali-yildiz",
            //        //Phone = "5555678901",
            //        //Email = "aliyildiz@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 5,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Ayşe",
            //        //LastName = "Kara",
            //        //Gender = "Kadın",
            //        //City = "Ankara",
            //        //Url = "ayse-kara",
            //        //Phone = "5556789012",
            //        //Email = "aysekara@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 6,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Mehmet",
            //        //LastName = "Öztürk",
            //        //Gender = "Erkek",
            //        //City = "İstanbul",
            //        //Url = "mehmet-ozturk",
            //        //Phone = "5557890123",
            //        //Email = "mehmetozturk@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 7,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Ece",
            //        //LastName = "Çelik",
            //        //Gender = "Kadın",
            //        //City = "İzmir",
            //        //Url = "ece-celik",
            //        //Phone = "5558901234",
            //        //Email = "ececelik@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 8,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Murat",
            //        //LastName = "Güneş",
            //        //Gender = "Erkek",
            //        //City = "Ankara",
            //        //Url = "murat-gunes",
            //        //Phone = "5559012345",
            //        //Email = "muratgunes@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 9,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Elif",
            //        //LastName = "Kurt",
            //        //Gender = "Kadın",
            //        //City = "İstanbul",
            //        //Url = "elif-kurt",
            //        //Phone = "5550123456",
            //        //Email = "elifkurt@gmail.com",
            //        ImageId = 5
            //    },
            //    new Student
            //    {
            //        Id = 10,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Can",
            //        //LastName = "Aydın",
            //        //Gender = "Erkek",
            //        //City = "İzmir",
            //        //Url = "can-aydin",
            //        //Phone = "5551234567",
            //        //Email = "canaydin@gmail.com",
            //        ImageId = 5
            //    }
            // );
        }
    }
}
