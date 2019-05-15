using SchoolStudents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStudentsApi.Interfaces
{
    public interface IStudentRepository 
    {
        IEnumerable<Student> GetStudent();
        void Update(Student student);
        void Insert(Student student);
        void Delete(int studentId);
        Student GetById(int studentId);
    }
}
