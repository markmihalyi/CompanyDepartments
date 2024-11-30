namespace CompanyDepartments
{
    class Employee : ICompanyComponent
    {
        public string Name { get; set; }
        public DateTime StartOfEmployment { get; set; }

        public Employee(string name, DateTime startOfEmployment)
        {
            Name = name;
            StartOfEmployment = startOfEmployment;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Alkalm._{Name}");
        }
    }
}
