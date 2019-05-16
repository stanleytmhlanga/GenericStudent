using SchoolStudentsApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolStudents.Domain;
using SchoolStudentsApi.Mappers;
using SchoolStudentsApi.Models;
using SchoolStudentsApi.Repositories;
using SchoolStudentsApi.UnitOfWork;

namespace SchoolStudent.Controllers
{
    public class StudentController : Controller
    {
        private  IStudentRepository studentRepository;
        private UnitOfWork unitOfWork;
        public StudentController(IStudentRepository studentRepository,UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.studentRepository = studentRepository;
        }
        // GET: Student
        public ActionResult Index()
        {
            List<Student> list = new List<Student>();
            var courses = unitOfWork.CourseRepository.Get(includeProperties: "id");
            //var departments = unitOfWork.DepartmentRepository.GetAll();
            var student = studentRepository.GetStudent();
            foreach (var item in student)
            {
                list.Add(item.MapToApi());
            }
            return View(list);
        }
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
                    var domain = studentApi.MapToDomain();
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
            var api = studentRepository.GetById(id).MapToApi();

            return View(api);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student studentApi)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var domain = studentApi.MapToDomain();
                    studentRepository.Update(domain);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var api = studentRepository.GetById(id).MapToApi();
            return View(api);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student studentApi)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var domain = studentApi.MapToDomain();
                    studentRepository.Delete(domain.id);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
