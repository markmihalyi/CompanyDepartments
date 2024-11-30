namespace CompanyDepartments
{
    abstract class Subject
    {
        private List<IDepartmentObserver> observers = new List<IDepartmentObserver>();

        public void Attach(IDepartmentObserver observer)
        {
            if (observers.Contains(observer)) return;

            observers.Add(observer);
        }

        public void Detach(IDepartmentObserver observer)
        {
            if (!observers.Contains(observer)) return;

            observers.Remove(observer);
        }

        protected void NotifyObservers(List<ICompanyComponent> components)
        {
            foreach (var observer in observers)
            {
                observer.Update(components);
            }
        }
    }
}
