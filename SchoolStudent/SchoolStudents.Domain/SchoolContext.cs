using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using SchoolStudents.Domain.Models;
namespace SchoolStudents.Domain
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("StudentDB")
        {}
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
