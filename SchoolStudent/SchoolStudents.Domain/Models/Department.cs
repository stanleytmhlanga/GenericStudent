using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStudents.Domain.Models
{
   public class Department
    {
        public Department()
        { }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
