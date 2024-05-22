using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            var result = RemoveTown(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            StringBuilder stringBuilder = new();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .AsNoTracking()
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder stringBuilder = new();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder stringBuilder = new();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakovEmpl = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            if (nakovEmpl != null)
            {
                nakovEmpl.Address = address;
                context.SaveChanges();
            }

            var employees = context.Employees
                .Select(e => new
                {
                    e.AddressId,
                    e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.AddressText}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year < 2004)
                    .Select(e => e.Project)
                    .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new();
            string patternDateTime = "M/d/yyyy h:mm:ss tt";

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {

                    if (project.EndDate.HasValue)
                    {
                        stringBuilder.AppendLine($"--{project.Name} - {project.StartDate.ToString(patternDateTime, CultureInfo.InvariantCulture)} - {project.EndDate.Value.ToString(patternDateTime, CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"--{project.Name} - {project.StartDate.ToString(patternDateTime, CultureInfo.InvariantCulture)} - not finished");
                    }
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeNumber = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeNumber)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();


            StringBuilder stringBuilder = new();

            foreach (var address in addresses)
            {
                stringBuilder.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeNumber} employees");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project.Name)
                })
                .OrderBy(e => e.FirstName)
                .FirstOrDefault(e => e.EmployeeId == 147);


            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects.OrderBy(p => p))
            {
                stringBuilder.AppendLine($"{project}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    d.Employees
                })
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();


            StringBuilder stringBuilder = new();

            foreach (var department in departments)
            {
                stringBuilder.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName)
                                                                    .ThenBy(e => e.LastName))
                {
                    stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var last10StartedProjects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();


            StringBuilder stringBuilder = new();
            string datePattern = "M/d/yyyy h:mm:ss tt";

            foreach (var proejct in last10StartedProjects.OrderBy(p => p.Name))
            {
                stringBuilder.AppendLine($"{proejct.Name}{Environment.NewLine}{proejct.Description}{Environment.NewLine}{proejct.StartDate.ToString(datePattern, CultureInfo.InvariantCulture)}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeeIds = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                         || e.Department.Name == "Tool Design"
                         || e.Department.Name == "Marketing"
                         || e.Department.Name == "Information Services")
                .Select(e => e.EmployeeId)
                .ToList();


            StringBuilder stringBuilder = new();

            List<Employee> employees = new List<Employee>();
            foreach (var employeeId in employeeIds)
            {
                var employee = context.Employees.Find(employeeId);
                if (employee != null)
                {
                    employee.Salary *= (decimal)1.12;
                    employees.Add(employee);
                }
            }

            context.SaveChanges();

            foreach (var employee in employees.OrderBy(e => e.FirstName)
                                                .ThenBy(e => e.LastName))
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();


            StringBuilder stringBuilder = new();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder stringBuilder = new();

            var projectToDelete= context.Projects.Find(2);

            var employeesProjecttoDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeesProjecttoDelete);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            var projects = context.Projects
                    .Select(p => new
                    {
                        p.Name
                    })
                    .Take(10)
                    .ToList();

            foreach (var pr in projects)
            {
                stringBuilder.AppendLine($"{pr.Name}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder stringBuilder = new();

            var townToDelete = context.Towns.First(t => t.Name == "Seattle");
            var addressesToDelete = context.Addresses.Where(a => a.TownId == townToDelete.TownId);
            var employeesWithNoAddress = context.Employees.Where(e => e.Address.Town.Name == "Seattle");

            int removedAdresses = addressesToDelete.Count();

            foreach (var employee in employeesWithNoAddress) 
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{removedAdresses} addresses in Seattle were deleted";
        }
    }
}
