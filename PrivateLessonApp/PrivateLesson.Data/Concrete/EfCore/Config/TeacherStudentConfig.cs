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
    public class TeacherStudentConfig : IEntityTypeConfiguration<TeacherStudent>
    {
        public void Configure(EntityTypeBuilder<TeacherStudent> builder)
        {
            builder.HasKey(ts => new { ts.TeacherId, ts.StudentId });
            builder.HasData(
                new TeacherStudent { TeacherId = 1, StudentId = 2 },
                new TeacherStudent { TeacherId = 7, StudentId = 1 },
                new TeacherStudent { TeacherId = 7, StudentId = 2 },
                new TeacherStudent { TeacherId = 7, StudentId = 3 },
                new TeacherStudent { TeacherId = 2, StudentId = 4 },
                new TeacherStudent { TeacherId = 6, StudentId = 5 },
                new TeacherStudent { TeacherId = 3, StudentId = 6 }
                );
        }
    }
}
