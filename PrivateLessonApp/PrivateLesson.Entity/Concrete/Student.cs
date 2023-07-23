using PrivateLesson.Entity.Abstract;
using PrivateLesson.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete
{
    public class Student : IBaseEntity
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }

    }
}
