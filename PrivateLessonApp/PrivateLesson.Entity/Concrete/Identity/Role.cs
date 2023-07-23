using Microsoft.AspNetCore.Identity;
using PrivateLesson.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete.Identity
{
    public class Role :IdentityRole
    {
        public string Description { get; set; }
    }
}
