namespace CompanyDepartments
{
    public class Employee : ICompanyComponent
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
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Alkalm._{Name}";
        }
    }
}
