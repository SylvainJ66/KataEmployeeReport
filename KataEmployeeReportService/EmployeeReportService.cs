namespace KataEmployeeReportService;

/// <summary>
/// 1. As shop owner I want to view a list of all employees, 
/// which are older than 18 years, so that I know who is allowed to work on Sundays.
/// 
/// 2. As shop owner I want the list of employees to be sorted by their name, 
/// so I can find employees easier.
/// 
/// 3. As shop owner I want the employees to be sorted by their names descending instead of ascending
/// </summary>

public class EmployeeReportService
{
    public List<Employee> Employees { get; set; } = new List<Employee>();

    public List<Employee> GetEmployees()
    {
        return this.Employees.OrderBy(e => e.Name).ToList();
    }

    public List<Employee> GetEmployeesCapitalized()
    {
        List<Employee> listeEmployes = this.GetEmployees();
        listeEmployes.ForEach(e => e.Name = e.Name.ToUpper());

        return listeEmployes;
    }

    public List<Employee> GetEmployeesSortedDescending()
    {
        return this.Employees.OrderByDescending(e => e.Name).ToList();
    }

    public List<Employee> GetEmployees18Plus()
    {
        return this.Employees.Where(e => e.Age >= 18).ToList();
    }
}
