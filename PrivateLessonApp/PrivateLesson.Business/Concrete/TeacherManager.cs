using PrivateLesson.Business.Abstract;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PrivateLesson.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherRepository.CreateAsync(teacher);
        }

        public async Task CreateTeacher(Teacher teacher, int[] SelectedBranches)
        {
            await _teacherRepository.CreateTeacher(teacher, SelectedBranches);
        }

        public void Delete(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string branchurl = null)
        {
            return await _teacherRepository.GetAllTeachersFullDataAsync(ApprovedStatus, branchurl);
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<int> GetByUrlAsync(string url)
        {
            return await _teacherRepository.GetByUrlAsync(url);
        }

        public async Task<Teacher> GetTeacherFullDataAsync(int id)
        {
            return await _teacherRepository.GetTeacherFullDataAsync(id);
        }

        public async Task<Teacher> GetTeacherFullDataStringAsync(string id)
        {
            return await _teacherRepository.GetTeacherFullDataStringAsync(id);

        }

        public async Task<List<Teacher>> GetTeachersByBranch(int id)
        {
            return await _teacherRepository.GetTeachersByBranch(id);
        }

        public async Task<List<Teacher>> GetTeachersByStudent(int id)
        {
            return await _teacherRepository.GetTeachersByStudent(id);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }

        public async Task UpdateTeacher(Teacher teacher, int[] SelectedBranches)
        {
            await _teacherRepository.UpdateTeacher(teacher, SelectedBranches);
        }
    }
}
