using CompanyDepartments;
using CompanyDepartments.Components;
using CompanyDepartments.Observers;

// Create employees
var employee1 = new Employee("Alice", DateTime.Parse("2020-01-15"));
var employee2 = new Employee("Bob", DateTime.Parse("2019-07-10"));
var employee3 = new Employee("John", DateTime.Parse("2021-03-20"));

// Create sub-department
var subDepartment = new Department("ITSupport", 2);
subDepartment.Add([employee1, employee2]);

// Create main department
var mainDepartment = new Department("ITDepartment", 5);
mainDepartment.Add([subDepartment, employee3]);

// Create and attach observers to sub-department
var nameLogger = new NameLogger();
subDepartment.Attach(nameLogger);

var excessLogger = new ExcessLogger(subDepartment);
subDepartment.Attach(excessLogger);

// 1: Display details
Console.WriteLine("[Initial Company Structure]");
mainDepartment.PrintDetails();

Console.WriteLine("\n");

// 2: Add employees

// 2a: Add an employee
bool successA = mainDepartment.Add(new List<ICompanyComponent> { new Employee("Dave", DateTime.Now), new Employee("James", DateTime.Now) });
if (successA) Console.WriteLine("2a) Employee(s) added successfully.");

// 2b: Attempt to add too many employees
bool successB = subDepartment.Add(new List<ICompanyComponent> { new Employee("Chris", DateTime.Now), new Employee("Joe", DateTime.Now), new Employee("Peter", DateTime.Now) });
if (successB) Console.WriteLine("2b) Employee(s) added successfully.");

Console.WriteLine();

// 3: Remove employees
try
{
    // 3a: Remove an employee
    mainDepartment.Remove(employee3);
    Console.WriteLine("3a) Employee removed successfully.");

    // 3b: Attempt to remove nonexistent employee
    mainDepartment.Remove(new Employee("Ubul", DateTime.Parse("2024-10-01")));
    Console.WriteLine("3b) Employee removed successfully.");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n");

// Display details again
Console.WriteLine("[Updated Company Structure]");
mainDepartment.PrintDetails();