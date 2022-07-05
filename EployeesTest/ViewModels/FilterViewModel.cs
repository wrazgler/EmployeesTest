using System;
using System.Collections.Generic;

using EmployeesTest.Models;

namespace EmployeesTest.ViewModels
{
    public class FilterViewModel
    {
        public List<Employee> Employees { get; set; }
        public string SelectedDepartment { get; set; }
        public string SelectedName { get; set; }
        public DateTime SelectedBirthday { get; set; }
        public DateTime SelectedApplyDate { get; set; }
        public string SelectedSalary { get; set; }
    }
}
