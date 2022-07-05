using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using EmployeesTest.Models;
using EmployeesTest.Services;
using EmployeesTest.ViewModels;

namespace EmployeesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService productService)
        {
            _employeeService = productService;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(
            FilterViewModel filterViewModel,
            SortState sortOrder = SortState.NameAsc)
        {
            var model = await _employeeService.GetEmployeesAsync(filterViewModel, sortOrder);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var model = new AddEmployeeViewModel() { };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AllEmployeesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _employeeService.TryAddEmployeeAsync(model);

            return RedirectToAction("GetAllEmployees", "Home", new {  });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            var model = new DeleteEmployeeViewModel { Employee = employee};

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _employeeService.TryDeleteEmployeeAsync(model.Employee.Id);

            return RedirectToAction("GetAllEmployees", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var model = await _employeeService.EditEmployeeGetAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _employeeService.EditPostAsync(model);

            return RedirectToAction("GetAllEmployees", "Home");
        }
    }
}