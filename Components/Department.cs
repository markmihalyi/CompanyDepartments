namespace CompanyDepartments.Components
{
    class Department : DepartmentSubject, ICompanyComponent
    {
        private List<ICompanyComponent> children = new List<ICompanyComponent>();

        public string Name { get; set; }
        public int MaxEmployeeCount { get; set; }

        public Department(string name, int maxEmployeeCount)
        {
            Name = name;
            MaxEmployeeCount = maxEmployeeCount;
        }

        public int GetEmployeeCount()
        {
            return children.Sum(child =>
                child is Employee ? 1 :
                child is Department department ? department.GetEmployeeCount() : 0);
        }

        public void PrintDetails()
        {
            Console.WriteLine(this);

            foreach (var child in children)
            {
                child.PrintDetails();
            }
        }

        public override string ToString()
        {
            return $"Részleg_{Name}";
        }

        #region Child Component Management
        public bool Add(List<ICompanyComponent> components)
        {
            int currentEmployeeCount = GetEmployeeCount();
            int newEmployeeCount = currentEmployeeCount + components.Count;

            if (newEmployeeCount > MaxEmployeeCount)
            {
                NotifyObservers(components);
                return false;
            }

            int componentsAdded = 0;
            foreach (var component in components)
            {
                if (children.Contains(component)) continue;

                children.Add(component);
                componentsAdded++;
            }
            return componentsAdded > 0;
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
