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
   public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasData(
                new Image { Id = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "1.jpg" },
                new Image { Id = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "2.jpg" },
                new Image { Id = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "3.jpg" },
                new Image { Id = 4, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "4.jpg" },
                new Image { Id = 5, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "5.jpg" }
                );
        }
    }
}
