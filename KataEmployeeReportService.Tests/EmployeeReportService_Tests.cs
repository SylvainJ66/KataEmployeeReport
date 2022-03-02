using System.Collections.Generic;
using Xunit;

namespace KataEmployeeReportService.Tests;

public class EmployeeReportService_Tests
{
    [Fact]
    public void DoNothing()
    {
        Assert.False(false);
    }

    [Fact]
    public void EmployeeShouldHaveNameAndAge()
    {
        Employee employee = new Employee
        {
            Age = 17,
            Name = "Max",
        };
        Assert.Equal(17, employee.Age);
        Assert.Equal("Max", employee.Name);
    }

    [Fact]
    public void GivenOneEmployeeGetEmployeesShouldReturn1Employee()
    {
        Employee employee = new Employee
        {
            Age = 17,
            Name = "Max",
        };
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees.Add(employee);

        List<Employee> employees = employeeReportService.GetEmployees();
        Assert.Single(employees);
        Assert.Equal("Max", employee.Name);
        Assert.Equal(17, employee.Age);
    }

    [Fact]
    public void GetEmployeesShouldReturnAllEmployees()
    {
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees = this.MakeEmployees();

        List<Employee> employees = employeeReportService.GetEmployees();
        Assert.Collection(employees,
            item => Assert.Equal("Max", item.Name),
            item => Assert.Equal("Mike", item.Name),
            item => Assert.Equal("Nina", item.Name),
            item => Assert.Equal("Sepp", item.Name)
        );
    }

    [Fact]
    public void GetEmployees18PlusShouldReturnThe2EmployeesWhoHave18OrMore()
    {
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees = this.MakeEmployees();

        List<Employee> employees = employeeReportService.GetEmployees18Plus();
        Assert.Collection(employees,
            item => Assert.Equal("Sepp", item.Name),
            item => Assert.Equal("Mike", item.Name)
        );
        employees.ForEach(e => Assert.True(e.Age >= 18));
    }

    [Fact]
    public void GetEmployeesSortedShouldReturnEmployeesSortedByName()
    {
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees = this.MakeEmployees();

        List<Employee> employees = employeeReportService.GetEmployees();
        Assert.Equal("Max", employees[0].Name);
        Assert.Equal("Mike", employees[1].Name);
        Assert.Equal("Nina", employees[2].Name);
        Assert.Equal("Sepp", employees[3].Name);
    }

    [Fact]
    public void GetEmployeesCapitalizedShouldReturnEmployeesCapitalized()
    {
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees = this.MakeEmployees();

        List<Employee> employees = employeeReportService.GetEmployeesCapitalized();
        Assert.Equal("MAX", employees[0].Name);
        Assert.Equal("MIKE", employees[1].Name);
        Assert.Equal("NINA", employees[2].Name);
        Assert.Equal("SEPP", employees[3].Name);
    }

    [Fact]
    public void GetEmployeesSortedDescendingShouldReturnEmployeesSortedByNameDescending()
    {
        EmployeeReportService employeeReportService = new EmployeeReportService();
        employeeReportService.Employees = this.MakeEmployees();

        List<Employee> employees = employeeReportService.GetEmployeesSortedDescending();
        Assert.Equal("Sepp", employees[0].Name);
        Assert.Equal("Nina", employees[1].Name);
        Assert.Equal("Mike", employees[2].Name);
        Assert.Equal("Max", employees[3].Name);
    }

    private List<Employee> MakeEmployees()
    {
        return new List<Employee>
        {
            new Employee { Age = 17, Name = "Max", },
            new Employee { Age = 18, Name = "Sepp", },
            new Employee { Age = 15, Name = "Nina", },
            new Employee { Age = 61, Name = "Mike", },
        };
    }
}