
namespace CompanyDepartments
{
    class ExcessLogger : IDepartmentObserver
    {
        private Department department;

        public ExcessLogger(Department department)
        {
            this.department = department;
        }

        public void Update(List<ICompanyComponent> components)
        {
            int maxEmployeeCount = department.MaxEmployeeCount;
            int currentEmployeeCount = department.GetEmployeeCount();
            int newEmployeeCount = currentEmployeeCount + components.Count;
            Console.WriteLine($"Maximum capacity exceeded by {newEmployeeCount - maxEmployeeCount}.");
        }
    }
}
