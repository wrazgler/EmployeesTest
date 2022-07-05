using System.Threading.Tasks;

using EmployeesTest.Models;
using EmployeesTest.ViewModels;

namespace EmployeesTest.Services
{
    public interface IEmployeeService
    {
        Task<bool> TryAddEmployeeAsync(AllEmployeesViewModel model);

        Task<bool> TryDeleteEmployeeAsync(int id);

        Task<EditEmployeeViewModel> EditEmployeeGetAsync(int id);

        Task EditPostAsync(EditEmployeeViewModel model);

        Task<AllEmployeesViewModel> GetEmployeesAsync(FilterViewModel filterViewModel, SortState sortOrder);

        Task<Employee> GetEmployeeAsync(int id);
    }
}
