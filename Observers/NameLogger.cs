namespace CompanyDepartments.Observers
{
    class NameLogger : IDepartmentObserver
    {
        public NameLogger() { }

        public void Update(List<ICompanyComponent> components)
        {
            Console.WriteLine("Attempted to add: " + string.Join("; ", components));
        }
    }
}
