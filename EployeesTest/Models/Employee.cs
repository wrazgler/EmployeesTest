using System;

namespace EmployeesTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Departament { get; set; }
        public DateTime Birtgday { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Salary { get; set; }
    }
}
