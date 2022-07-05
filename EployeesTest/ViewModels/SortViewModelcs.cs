using EmployeesTest.Models;

namespace EmployeesTest.ViewModels
{
    public class SortViewModel
    {
        public SortState DepartamentSort { get; }
        public SortState NameSort { get; }
        public SortState BirthdaytSort { get; }
        public SortState ApplyDateSort { get; }
        public SortState SalarySort { get; }
        public SortState Current { get; }

        public SortViewModel(SortState sortOrder)
        {
            DepartamentSort = sortOrder == SortState.DepartamentAsc ? SortState.DepartamentDesc : SortState.DepartamentAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            BirthdaytSort = sortOrder == SortState.BirthdayAsc ? SortState.BirthdayDesc : SortState.BirthdayAsc;
            ApplyDateSort = sortOrder == SortState.ApplyDateAsc ? SortState.ApplyDateDesc : SortState.ApplyDateAsc;
            SalarySort = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;
            Current = sortOrder;
        }
    }
}
