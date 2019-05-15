using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SchoolStudents.Domain.Interfaces;
using SchoolStudents.Domain.Models;
using SchoolStudents.Domain;

namespace SchoolStudents.Domain.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }
        public void Delete(int studentId)
        {
            Student student = context.Student.Find(studentId);
            context.Student.Remove(student);
        }
        public Student GetById(int studentId)
        {
           return context.Student.Find(studentId);
        }

        public IEnumerable<Student> GetStudent()
        {
            return context.Student.ToList();
        }

        public void Insert(Student student)
        {
            context.Student.Add(student);
        }

        public void Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
