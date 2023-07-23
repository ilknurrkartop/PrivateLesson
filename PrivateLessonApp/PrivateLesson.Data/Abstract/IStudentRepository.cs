using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus);
        Task<Student> GetStudentFullDataAsync(int id);
        Task<List<Student>> GetStudentsByTeacher(int id);
    }
}
