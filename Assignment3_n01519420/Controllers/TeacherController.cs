using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_n01519420.Models;
using System.Diagnostics;

namespace Assignment3_n01519420.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET: Teacher/List
        public ActionResult List()
        {
            //create object of datacontroller class
            TeacherDataController controller = new TeacherDataController();
            //connect with ListTeacher method into the datacontroller class
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            //display list of teachers
            return View(Teachers);
        }

        //taking teacherid input value
        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            //call FindTeacher method and passing teacherid 
            Teacher NewTeacher = controller.FindTeacher(id);
            //display selected teacher information
            return View(NewTeacher);
        }

        //GET: /Teacher/Add
        public ActionResult Add()
        {
            return View();
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            //call DeleteTeacher method into the datacontroller class and pass teacherid
            controller.DeleteTeacher(id);
            //redirect to list view page
            return RedirectToAction("List");
        }

        //GET : /Teacher/Update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }

        //POST : /Teacher/Update/{id}/{TeacherFname}/{TeacherLname}/{EmployeeNumber}/{hiredate}/{salary}
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime hiredate, decimal salary)
        {
            //validate input data
            //validates input data but not printing appropriate message. if any input value for string empty or int 0 then it is not updating into the table
            if(id == 0 || TeacherFname == "" || TeacherLname == "" ||EmployeeNumber == "" || hiredate == null || salary == 0)
            {
                ViewBag.Message = "Please Fill all the fields";
                return View();
            }
            else
            {
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherFName = TeacherFname;
                NewTeacher.TeacherLName = TeacherLname;
                NewTeacher.TEmpNumber = EmployeeNumber;
                NewTeacher.HireDate = hiredate;
                NewTeacher.Salary = salary;

                TeacherDataController controller = new TeacherDataController();
                controller.UpdateTeacher(id, NewTeacher);
            }
            return RedirectToAction("List");
        }

        //take parameters firtname, lastname, employeenumber, hiredate, and salary from the view page
        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime hiredate, decimal salary)
        {
            //validate input data
            if (TeacherFname == "" || TeacherLname == "" || EmployeeNumber == "" || hiredate == null || salary == 0)
            {
                ViewBag.Message = "Please Fill all the fields";
                
            }
            else
            {
                //create model class teacher object
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherFName = TeacherFname;
                NewTeacher.TeacherLName = TeacherLname;
                NewTeacher.TEmpNumber = EmployeeNumber;
                NewTeacher.HireDate = hiredate;
                NewTeacher.Salary = salary;

                TeacherDataController controller = new TeacherDataController();
                //call AddTeacher method and pass teacher object to the method
                controller.AddTeacher(NewTeacher);
            }

            //redirect to the list view page
            return RedirectToAction("List");
        }
    }
}