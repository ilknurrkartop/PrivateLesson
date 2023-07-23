using Microsoft.AspNetCore.Identity;
using PrivateLesson.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete.Identity
{
    public class User : IdentityUser,IBaseCommonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
