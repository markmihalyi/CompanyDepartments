namespace CompanyDepartments
{
    interface IDepartmentObserver
    {
        void Update(List<ICompanyComponent> components);
    }
}
