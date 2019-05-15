using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using SchoolStudents.Domain.Models;
namespace SchoolStudents.Domain
{
    public class SchoolContext : DbContext
    {
        //public SchoolContext(string ConnectionString) : base(ConnectionString)
        //{

        //}

        public SchoolContext() : base("StudentDB")
        {

        }
        public DbSet<Student> Student { get; set; }

    //    public System.Data.Entity.DbSet<SchoolStudents.Domain.Models.Student> Students { get; set; }
    }
}
