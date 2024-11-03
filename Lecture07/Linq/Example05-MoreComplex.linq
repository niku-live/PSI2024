<Query Kind="Statements" />

using System.Collections.Generic;

var data = new[] {
    new Company
    {
        CompanyName = "Company One",
        CompanyAddress = "In the middle of nowhere st. 1",
        Employees = new List<Employee>()
        {
            new Employee
            {
                Name = "John",
                LastName = "Smith",
                Age = 30,
                BirthDate = new DateTime(1991, 10, 7)
            },
            new Employee
            {
                Name = "Alex",
                LastName = "Max",
                Age = 25,
                BirthDate = new DateTime(1996, 1, 7)
            }
        }
    },
    new Company
    {
        CompanyName = "Company Two",
        CompanyAddress = "Somewhere in Mars",
        Employees = new List<Employee>()
        {
            new Employee
            {
                Name = "Torii",
                LastName = "Marel",
                Age = 130,
                BirthDate = new DateTime(1891, 7, 5)
            }
        }
    }
};

data.Dump();
var info = 
  data.
  Where(company => company.CompanyName == "Company One").
  Select(company => new { company.CompanyName, company.CompanyAddress, EmployeeCount = company.Employees.Count() });
info.Dump();

var info2 = 
  from company in data
  where company.CompanyName == "Company One"
  select new { company.CompanyName, company.CompanyAddress, EmployeeCount = company.Employees.Count() };
info2.Dump();


var info3 = 
  data.
  Where(company => company.CompanyName == "Company One").
  Select(company => new 
  { 
     company.CompanyName,
	 company.CompanyAddress,
	 EmployeeCount = company.Employees.Count(), 
	 OldestEmployee = company.Employees.FirstOrDefault(e => e.Age == company.Employees.Max(e2 => e2.Age)) 
  });
info3.Dump();

var info4 = 
  from company in data
  where company.CompanyName == "Company One"
  select new 
  { 
    company.CompanyName, company.CompanyAddress, EmployeeCount = company.Employees.Count(),
    OldestEmployee = company.Employees.FirstOrDefault(e => e.Age == company.Employees.Max(e2 => e2.Age)) 	
  };
info4.Dump();



public class Employee
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
}

public class Company
{
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public List<Employee> Employees { get; set;}
}