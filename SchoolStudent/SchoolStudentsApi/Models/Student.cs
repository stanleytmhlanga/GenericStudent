using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolStudentsApi.Models
{
    public class Student
    {
        //public Student(List<SchoolStudents.Domain.Models.Student> domains)
        //{
        //    foreach (var domain in domains)
        //    {
        //        this.id = domain.id;
        //        this.Name = domain.Name;
        //        this.Surname = domain.Surname;
        //        this.Age = domain.Age;
        //        this.Grade = domain.Grade;
        //        this.IDNumber = domain.IDNumber;
        //    }
          
           
        //}

        public Student()
        {

        }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string IDNumber { get; set; }
        public string Grade { get; set; }
    }
}
