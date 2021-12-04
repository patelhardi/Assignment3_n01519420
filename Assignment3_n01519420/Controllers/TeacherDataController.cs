using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_n01519420.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Assignment3_n01519420.Controllers
{
    public class TeacherDataController : ApiController
    {
        //database connection object
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Display all teachers data
        /// </summary>
        /// <returns>List of Teachers with teacherfirstname, teacherlastname, and employee number</returns>
        [HttpGet]
        [Route("api/teacherdata/listteachers")]
        public IEnumerable<Teacher> ListTeachers()
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Select teacherid, teacherfname, teacherlname, employeenumber from teachers";
            
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            
            List<Teacher> TeacherNames = new List<Teacher> { };
            
            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFName = ResultSet["teacherfname"].ToString();
                string TeacherLName = ResultSet["teacherlname"].ToString();
                string TeacherEmpNumber = ResultSet["employeenumber"].ToString();

                Teacher TeacherName = new Teacher();
                TeacherName.TeacherId = TeacherId;
                TeacherName.TeacherFName = TeacherFName;
                TeacherName.TeacherLName = TeacherLName;
                TeacherName.TEmpNumber = TeacherEmpNumber;
                TeacherNames.Add(TeacherName);
            }

            Conn.Close();
            
            return TeacherNames;
        }

        /// <summary>
        /// display teacher information of the selected teacherid input value from database
        /// </summary>
        /// <param name="id">take input teacherid number of the selected teacher </param>
        /// <returns>returns teacherfirstname, teacherlastname, employee number, hire date and salary of the selected teacher</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Select * from teachers where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string TeacherEmpNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFname;
                NewTeacher.TeacherLName = TeacherLname;
                NewTeacher.TEmpNumber = TeacherEmpNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }
            Conn.Close();

            return NewTeacher;
        }

        /// <summary>
        /// delete selected teacher data from the database
        /// </summary>
        /// <param name="id">input teacherid value</param>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        /// <summary>
        /// Add new teacher data into the database
        /// </summary>
        /// <param name="NewTeacher">passing values teacherfirstname, teacherlastname, employeenumber, hire date, and salary</param>
        [HttpPost]
        public void AddTeacher(Teacher NewTeacher)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname,@TeacherLname,@TENumber, CURRENT_DATE(), @Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFName);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLName);
            cmd.Parameters.AddWithValue("@TENumber", NewTeacher.TEmpNumber);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        /// <summary>
        /// display list of students from database
        /// </summary>
        /// <returns>list of studenst</returns>
        [HttpGet]
        [Route("api/teacherdata/liststudents")]
        public IEnumerable<string> ListStudents()
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Select * from students";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<String> StudentNames = new List<string> { };

            while (ResultSet.Read())
            {
                string StudentName = ResultSet["studentfname"] + " " + ResultSet["studentlname"] + " StudentNumber: " + ResultSet["studentnumber"];
                StudentNames.Add(StudentName);
            }
            Conn.Close();

            return StudentNames;
        }

        /// <summary>
        /// display list of classes from database
        /// </summary>
        /// <returns>list of classes</returns>
        [HttpGet]
        [Route("api/teacherdata/listclasses")]
        public IEnumerable<string> ListClasses()
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Select * from classes";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<String> ClassNames = new List<string> { };

            while (ResultSet.Read())
            {
                string ClassName = ResultSet["classname"] + " ClassCode: " + ResultSet["classcode"] + " Start: " + ResultSet["startdate"] + " End: " + ResultSet["finishdate"];
                ClassNames.Add(ClassName);
            }
            Conn.Close();

            return ClassNames;
        }
    }
}
