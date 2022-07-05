using System;
using System.Collections.Generic;

using EmployeesTest.Models;

namespace EmployeesTest.ViewModels
{
    public class AllEmployeesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Departament { get; set; }
        public DateTime Birtgday { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Salary { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
