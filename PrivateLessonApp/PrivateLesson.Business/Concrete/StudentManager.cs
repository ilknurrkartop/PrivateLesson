﻿using PrivateLesson.Business.Abstract;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }


        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus)
        {
            return await _studentRepository.GetAllStudentsWithTeachersAsync(ApprovedStatus);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }



        public async Task<Student> GetStudentFullDataAsync(int id)
        {
            return await _studentRepository.GetStudentFullDataAsync(id);
        }

        public async Task<List<Student>> GetStudentsByTeacher(int id)
        {
            return await _studentRepository.GetStudentsByTeacher(id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
