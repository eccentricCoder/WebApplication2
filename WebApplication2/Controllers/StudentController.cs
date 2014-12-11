using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using System.Web.Configuration;

// This is a quick demo I wrote to learn both WEB API and AngularJS
namespace WebApplication2.Controllers
{
    public class StudentController : ApiController
    {
        public List<WebApplication2.Models.Student> Students = new List<WebApplication2.Models.Student>();

        private StudentsDataContext dbStudent = new StudentsDataContext();

        private List<WebApplication2.Models.Student> GetStudents()
        {
            return (from student in dbStudent.Students
                    orderby student.firstName
                    orderby student.lastName
                    select new WebApplication2.Models.Student
                        {
                            FirstName = student.firstName,
                            LastName = student.lastName,
                            StudentNumber = student.studentNumber.ToString(),
                            StudentId = student.studentId,
                            Email = student.email,
                            EnrollDate = student.enrollDate.ToShortDateString()
                        }).ToList<WebApplication2.Models.Student>();
        }

        // GET api/student
        public List<WebApplication2.Models.Student> Get()
        {
            Students = GetStudents();
            return Students;
        }

        // GET api/student/5
        public WebApplication2.Models.Student Get(int id)
        {
            // Just a place holder. I want to use this method to return a
            // detailed view of the selected record.
            return Students[id];
        }

        // POST api/student
        public void Post([FromBody]Student value)
        {
            value.studentNumber = Guid.NewGuid();
            Student student = (from s in dbStudent.Students where s.studentNumber == value.studentNumber select s).FirstOrDefault();
            
            if (student != null)
            {
                do
                {
                    value.studentNumber = Guid.NewGuid();
                } while (student.studentNumber == value.studentNumber);
            }

            dbStudent.Students.InsertOnSubmit(value);
            dbStudent.SubmitChanges();
        }

        // PUT api/student/5
        public void Put(int id, [FromBody]Student value)
        {

        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            Student student = (from s in dbStudent.Students where s.studentId == id select s).FirstOrDefault();
            dbStudent.Students.DeleteOnSubmit(student);
            dbStudent.SubmitChanges();
        }
    }
}
