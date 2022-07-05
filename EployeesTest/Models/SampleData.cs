using System;
using System.Linq;

namespace EmployeesTest.Models
{
    public class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {

                var employee = new Employee { 
                    Departament = "IT технологии",
                    Name = "Иванов Павел Павлович",
                    Birtgday = DateTime.Today,
                    ApplyDate = DateTime.Today,
                    Salary = 100000,
                };
                context.Employees.AddRange(employee);

                context.SaveChanges();
            }
        }
    }
}
