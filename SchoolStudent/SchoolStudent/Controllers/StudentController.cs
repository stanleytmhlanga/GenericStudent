using SchoolStudentsApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolStudents.Domain;
using SchoolStudentsApi.Models;
using SchoolStudentsApi.Repositories;

namespace SchoolStudent.Controllers
{
    public class StudentController : Controller
    {
        private  IStudentRepository studentRepository;
        private Student studentApi;
        public StudentController(IStudentRepository studentRepository,Student student)
        {
            this.studentRepository = studentRepository;
            this.studentApi = student;
        }

        //public StudentController()
        //{
        //    this.studentRepository = new StudentRepository(new SchoolContext());
        //}
        // GET: Student
        public ActionResult Index()
        {
            List<Student> list = new List<Student>();
            var student = studentRepository.GetStudent();
            //= new List<Student>(student.ToList());
            foreach (var item in student)
            {
                
               list = new List<Student>() { new Student()
               {
                   id = item.id,
                   Name = item.Name,
                   Surname = item.Surname,
                   Grade = item.Grade,
                   IDNumber =  item.IDNumber,
                   Age = item.Age
               } };
            }
          
            //list.Add(student);
            return View(list);
        }

        //internal List<Student> MapToApi(List<SchoolStudents.Domain.Models.Student> domain)
        //{
        //    List<Student> api = new List<Student>(){new Student()};
        //    foreach (var item in domain)
        //    {
        //        api.Add(item);
        //    }

        //}
        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student studentApi)
        {
            try
            {
                
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    SchoolStudents.Domain.Models.Student domain =
                        new SchoolStudents.Domain.Models.Student()
                        {
                           // id = studentApi.id != 0 ? studentApi.id : 1,
                            Name = studentApi.Name,
                            Surname = studentApi.Surname,
                            Age = studentApi.Age,
                            Grade = studentApi.Grade,
                            IDNumber = studentApi.IDNumber,
                        };


                    studentRepository.Insert(domain);
                }
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
