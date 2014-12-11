//using System.Data.Entity;
// Access the Entity Framework (EF) API.
// Allows us to reference DbContext and DbSet.
using System;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Student
    {
        public Student() { }

        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string EnrollDate { get; set; }
    }
}