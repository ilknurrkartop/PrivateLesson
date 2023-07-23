using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    public interface ITeacherService
    {
        Task CreateAsync(Teacher teacher);
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();

        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string branchurl = null);

        Task<Teacher> GetTeacherFullDataAsync(int id);

        Task<Teacher> GetTeacherFullDataStringAsync(string id);

        void Update(Teacher teacher);
        void Delete(Teacher teacher);


        Task CreateTeacher(Teacher teacher, int[] SelectedBranches);

        Task UpdateTeacher(Teacher teacher, int[] SelectedBranches);

        Task<List<Teacher>> GetTeachersByBranch(int id);

        Task<List<Teacher>> GetTeachersByStudent(int id);

        Task<int> GetByUrlAsync(string url);

    }
}
