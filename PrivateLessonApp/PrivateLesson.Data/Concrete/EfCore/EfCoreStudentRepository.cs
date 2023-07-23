using Microsoft.EntityFrameworkCore;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Data.Concrete.EfCore.Context;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }

        public async Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus)
        {
            List<Student> students = await AppContext
                .Students
                .Where(s => s.IsApproved == ApprovedStatus)
                .Include(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(s => s.TeacherStudents)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.User)
                .ThenInclude(s => s.Image)
                .ToListAsync();
            return students;
        }


        public Task<Student> GetStudentFullDataAsync(int id)
        {
            var student = AppContext
                .Students
                .Where(s => s.Id == id)
                .Include(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Teacher)
                 .ThenInclude(s => s.User)
                .ThenInclude(s => s.Image)
                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<List<Student>> GetStudentsByTeacher(int id)
        {
            List<Student> students = await AppContext
                .Students
                .Where(t => t.IsApproved == true)
                .Include(tu => tu.User)
                .ThenInclude(t => t.Image)
               .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Teacher)
                .ThenInclude(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Where(t => t.TeacherStudents.Any(x => x.StudentId == id))
               .ToListAsync();
            return students;
        }
    }
}
