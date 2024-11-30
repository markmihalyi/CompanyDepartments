namespace CompanyDepartments
{
    class Department : ICompanyComponent
    {
        private List<ICompanyComponent> children = new List<ICompanyComponent>();

        public string Name { get; set; }
        public int MaxEmployeeCount { get; set; }

        public Department(string name, int maxEmployeeCount)
        {
            Name = name;
            MaxEmployeeCount = maxEmployeeCount;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Részleg_{Name}");

            foreach (var child in children)
            {
                child.PrintDetails();
            }
        }

        private int GetEmployeeCount()
        {
            return children.Sum(child =>
                child is Employee ? 1 :
                child is Department department ? department.GetEmployeeCount() : 0);
        }


        #region Child Component Management
        public void Add(List<ICompanyComponent> components)
        {
            int currentEmployeeCount = GetEmployeeCount();
            int newEmployeeCount = currentEmployeeCount + components.Count;

            if (newEmployeeCount > MaxEmployeeCount)
            {
                string errorMessage = $"Cannot add component: maximum capacity of {MaxEmployeeCount} exceeded. Current: {currentEmployeeCount}, Attempted: {newEmployeeCount}";
                throw new InvalidOperationException(errorMessage);
            }

            children.AddRange(components);
        }

        public void Remove(ICompanyComponent component)
        {
            if (!children.Contains(component))
            {
                string errorMessage = "Cannot remove component: it does not exist in the department.";
                throw new InvalidOperationException(errorMessage);
            }

            children.Remove(component);
        }
        #endregion
    }
}
