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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
            builder.Property(x => x.UserId);
            builder.Property(x => x.Graduation).IsRequired();

            //builder.HasData(
            //    new Teacher
            //    {
            //        Id = 1,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Ali",
            //        //LastName = "Yılmaz",
            //        //Gender = "Erkek",
            //        //City = "İstanbul",
            //        //Url = "ali-yilmaz",
            //        //Phone = "5321234567",
            //        //Email = "ali.yilmaz@gmail.com",
            //        Graduation = "Boğaziçi Üniversitesi",
            //        Price = 500,
            //        ImageId = 1
            //    },
            //    new Teacher
            //    {
            //        Id = 2,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Ayşe",
            //        //LastName = "Kaya",
            //        //Gender = "Kadın",
            //        //City = "Ankara",
            //        //Url = "ayse-kaya",
            //        //Phone = "5322345678",
            //        //Email = "ayse.kaya@gmail.com",
            //        Graduation = "Hacettepe Üniversitesi",
            //        Price = 450,
            //        ImageId = 2
            //    },
            //    new Teacher
            //    {
            //        Id = 3,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Mehmet",
            //        //LastName = "Demir",
            //        //Gender = "Erkek",
            //        //City = "İzmir",
            //        //Url = "mehmet-demir",
            //        //Phone = "5323456789",
            //        //Email = "mehmet.demir@gmail.com",
            //        Graduation = "Ege Üniversitesi",
            //        Price = 550,
            //        ImageId = 3
            //    },
            //    new Teacher
            //    {
            //        Id = 4,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Fatma",
            //        //LastName = "Can",
            //        //Gender = "Kadın",
            //        //City = "Bursa",
            //        //Url = "fatma-can",
            //        //Phone = "5324567890",
            //        //Email = "fatma.can@gmail.com",
            //        Graduation = "Uludağ Üniversitesi",
            //        Price = 600,
            //        ImageId = 4
            //    },
            //    new Teacher
            //    {
            //        Id = 5,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Mustafa",
            //        //LastName = "Koç",
            //        //Gender = "Erkek",
            //        //City = "İstanbul",
            //        //Url = "mustafa-koc",
            //        //Phone = "5325678901",
            //        //Email = "mustafa.koc@gmail.com",
            //        Graduation = "İstanbul Teknik Üniversitesi",
            //        Price = 450,
            //        ImageId = 5
            //    },
            //    new Teacher
            //    {
            //        Id = 6,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Emine",
            //        //LastName = "Yıldız",
            //        //Gender = "Kadın",
            //        //City = "Ankara",
            //        //Url = "emine-yildiz",
            //        //Phone = "5326789012",
            //        //Email = "emine.yildiz@gmail.com",
            //        Graduation = "ODTÜ",
            //        Price = 550,
            //        ImageId = 5
            //    },
            //    new Teacher
            //    {
            //        Id = 7,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Hakan",
            //        //LastName = "Yıldırım",
            //        //Gender = "Erkek",
            //        //City = "İstanbul",
            //        //Url = "hakan-yildirim",
            //        //Phone = "5327890123",
            //        //Email = "hakan.yildirim@gmail.com",
            //        Graduation = "İstanbul Üniversitesi",
            //        Price = 500,
            //        ImageId = 5
            //    },
            //    new Teacher
            //    {
            //        Id = 8,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now,
            //        IsApproved = true,
            //        UserId = "",
            //        //FirstName = "Buse",
            //        //LastName = "Özkan",
            //        //Gender = "Kadın",
            //        //City = "İzmir",
            //        //Url = "buse-ozkan",
            //        //Phone = "5328901234",
            //        //Email = "buse.ozkan@gmail.com",
            //        Graduation = "Dokuz Eylül Üniversitesi",
            //        Price = 550,
            //        ImageId = 5
            //    }
            //);
        }
    }
}
