using SchoolStudents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStudentsApi.Mappers
{
    public static class Mappers
    {

        public static Models.Student MapToApi(this Student domain)
        {
            Models.Student api = new Models.Student();
            if (domain != null)
            {
                api.id = domain.id;
                api.Name = domain.Name;
                api.Surname = domain.Surname;
                api.Age = domain.Age;
                api.IDNumber = domain.IDNumber;
                api.Grade = domain.Grade;
            }
            return api;
        }

        public static Student MapToDomain(this Models.Student api)
        {
            Student domain = new Student();
            if (domain != null)
            {
                domain.id = api.id;
                domain.Name = api.Name;
                domain.Surname = api.Surname;
                domain.Age = api.Age;
                domain.IDNumber = api.IDNumber;
                domain.Grade = api.Grade;
            }
            return domain;
        }
    }
}
