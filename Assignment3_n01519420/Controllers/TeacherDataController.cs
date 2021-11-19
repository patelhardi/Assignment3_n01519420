using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_n01519420.Models;
using MySql.Data.MySqlClient;

namespace Assignment3_n01519420.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        [Route("api/teacherdata/listteachers")]
        public IEnumerable<string> ListTeachers()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<String> TeacherNames = new List<string> { };

            while (ResultSet.Read())
            {
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                TeacherNames.Add(TeacherName);
            }

            Conn.Close();

            return TeacherNames;
        }

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
