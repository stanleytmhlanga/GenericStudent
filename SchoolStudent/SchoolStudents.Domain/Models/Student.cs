﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolStudents.Domain.Models
{
   public class Student
    {
        public Student()
        { }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string IDNumber { get; set; }
        public string Grade { get; set; }
        [ForeignKey("id")]
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Department> Department{ get; set; }

        
    }
}
