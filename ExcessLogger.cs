
namespace CompanyDepartments
{
    class ExcessLogger : IDepartmentObserver
    {
        private Department Department { get; set; }

        public ExcessLogger(Department department)
        {
            Department = department;
        }

        public void Update(List<ICompanyComponent> components)
        {
            int maxEmployeeCount = Department.MaxEmployeeCount;
            int currentEmployeeCount = Department.GetEmployeeCount();
            int newEmployeeCount = currentEmployeeCount + components.Count;
            Console.WriteLine($"Maximum capacity exceeded by {newEmployeeCount - maxEmployeeCount}.");
        }
    }
}
