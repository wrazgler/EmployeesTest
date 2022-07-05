using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using EmployeesTest.Models;
using EmployeesTest.ViewModels;
using System;

namespace EmployeesTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        public EmployeeService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<bool> TryAddEmployeeAsync(AllEmployeesViewModel model)
        {
            if (model.Name == null)
                return false;

            var employees = _db.Employees.ToList();

            foreach (var employee in employees)
            {
                if (employee.Name.ToLower() == model.Name.ToLower())
                    return false;
            }

            var newEmployee = new Employee 
            { 
                Departament = model.Departament,
                Name = model.Name,
                Birtgday = model.Birtgday,
                ApplyDate = model.ApplyDate,
                Salary = model.Salary,
            };

            _db.Employees.Add(newEmployee);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TryDeleteEmployeeAsync(int id)
        {
            var employee = await _db.Employees
                .FirstOrDefaultAsync(p => p.Id == id);

            if (employee == null)
                return false;

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<EditEmployeeViewModel> EditEmployeeGetAsync(int id)
        {
            var employee  = await _db.Employees
                .FirstOrDefaultAsync(p => p.Id == id);

            var model = new EditEmployeeViewModel() { Employee = employee };

            return model;
        }
 
        public async Task EditPostAsync(EditEmployeeViewModel model)
        {
            if (model == null) 
                return;

            var employee = await _db.Employees
                .FirstOrDefaultAsync(e => e.Id == model.Employee.Id);

            if (employee == null) 
                return;

            employee.Departament = model.Employee.Departament;
            employee.Name = model.Employee.Name;
            employee.Birtgday = model.Employee.Birtgday;
            employee.ApplyDate = model.Employee.ApplyDate;
            employee.Salary = model.Employee.Salary;

            await _db.SaveChangesAsync();
        }

        public async Task<AllEmployeesViewModel> GetEmployeesAsync(FilterViewModel filterViewModel, SortState sortOrder)
        {
            var employees = await _db.Employees.ToListAsync();

            if (!string.IsNullOrEmpty(filterViewModel.SelectedName))
            {
                employees = employees
                    .Where(p => p.Name.ToLower()
                    .Contains(filterViewModel.SelectedName.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(filterViewModel.SelectedDepartment))
            {
                employees = employees
                    .Where(p => p.Departament.ToLower()
                    .Contains(filterViewModel.SelectedDepartment.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(filterViewModel.SelectedSalary))
            {
                employees = employees
                    .Where(p => p.Salary.ToString().ToLower()
                    .Contains(filterViewModel.SelectedDepartment.ToLower()))
                    .ToList();
            }

            if (filterViewModel.SelectedBirthday != DateTime.MinValue)
            {
                employees = employees
                    .Where(p => p.Birtgday == filterViewModel.SelectedBirthday)
                    .ToList();
            }

            if (filterViewModel.SelectedApplyDate != DateTime.MinValue)
            {
                employees = employees
                    .Where(p => p.ApplyDate == filterViewModel.SelectedApplyDate)
                    .ToList();
            }

            switch (sortOrder)
            {
                case SortState.DepartamentAsc:
                    employees = employees.OrderBy(p => p.Departament).ToList();
                    break;
                case SortState.DepartamentDesc:
                    employees = employees.OrderByDescending(p => p.Departament).ToList();
                    break;
                case SortState.NameAsc:
                    employees = employees.OrderBy(p => p.Name).ToList();
                    break;
                case SortState.NameDesc:
                    employees = employees.OrderByDescending(p => p.Name).ToList();
                    break;
                case SortState.BirthdayAsc:
                    employees = employees.OrderBy(p => p.Birtgday).ToList();
                    break;
                case SortState.BirthdayDesc:
                    employees = employees.OrderByDescending(p => p.Birtgday).ToList();
                    break;
                case SortState.ApplyDateAsc:
                    employees = employees.OrderBy(p => p.ApplyDate).ToList();
                    break;
                case SortState.ApplyDateDesc:
                    employees = employees.OrderByDescending(p => p.ApplyDate).ToList();
                    break;
                case SortState.SalaryAsc:
                    employees = employees.OrderBy(p => p.Salary).ToList();
                    break;
                case SortState.SalaryDesc:
                    employees = employees.OrderByDescending(p => p.Salary).ToList();
                    break;
                default:
                    employees = employees.OrderBy(p => p.Name).ToList();
                    break;
            }

            var viewModel = new AllEmployeesViewModel
            {
                FilterViewModel = new FilterViewModel()
                {
                    Employees = _db.Employees.ToList(),
                    SelectedDepartment = filterViewModel.SelectedDepartment,
                    SelectedName = filterViewModel.SelectedName,
                    SelectedBirthday = filterViewModel.SelectedBirthday,
                    SelectedApplyDate = filterViewModel.SelectedApplyDate,
                    SelectedSalary = filterViewModel.SelectedSalary,
                },
                SortViewModel = new SortViewModel(sortOrder),
                Employees = employees
            };

            return viewModel;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employee = await _db.Employees
                .FirstOrDefaultAsync(p => p.Id == id);

            return employee;
        }
    }
}
