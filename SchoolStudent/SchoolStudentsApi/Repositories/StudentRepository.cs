using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
//using SchoolStudents.Domain.Interfaces;
using SchoolStudents.Domain.Models;
using SchoolStudents.Domain;

namespace SchoolStudentsApi.Repositories{
    public class StudentRepository : SchoolStudentsApi.Interfaces.IStudentRepository
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
            Save();
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
            Save();
        }

        public void Update(Student student)
        {
            var RecordExist = context.Student.Find(student.id);
            if (RecordExist == null)
            {
                context.Student.Add(student);
            }
            else
            {
                context.Entry(RecordExist).State = EntityState.Detached;
                context.Entry(student).State = EntityState.Modified;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    context.Dispose();
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
