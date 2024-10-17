using CompanyManagement.Application.Interfaces;
using CompanyManagement.Application.Services;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CompanyManagement.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<ICustomer> customers = new List<ICustomer>
            {
                new Customer("Customer 1", 10, 20),
                new Customer("Customer 2", 90, 24),
                new Customer("Customer 3", 34, 63),
                new Customer("Customer 4", 67, 1),
                new Customer("Customer 5", 24, 84),
                new Customer("Customer 6", 51, 44),
                new Customer("Customer 7", 97, 92),
                new Customer("Customer 8", 77, 13),
                new Customer("Customer 9", 35, 39),
                new Customer("Customer 10", 85, 29)
            };

            IList<IDepartment> departments = new List<IDepartment>
            {
                new Department("Purchasing", "Top floor", new List<Person>
                {
                    new Person("Smith", "John", "Mr"),
                    new Person("Jones", "Steve", "Mr"),
                    new Person("Bradshaw", "Lisa", "Mrs")
                }),
                new Department("Sales", "Bottom floor", new List<Person>
                {
                    new Person("Bradshaw", "Lisa", "Mrs"),
                    new Person("Thompson", "Joanne", "Miss"),
                    new Person("Johnson", "David", "Mr")
                })
            };

            IDepartmentServices departmentService = new DepartmentServices(departments);
            ICustomerServices customerService = new CustomerServices(customers);

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Check the Lastnames in a department");
                Console.WriteLine("2. Check peoples department");
                Console.WriteLine("3. Get shortest route to visit customers");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter department name: ");
                        var departmentName = Console.ReadLine();
                        var lastNames = departmentService.GetSurnamesInDepartment(departmentName);
                        Console.WriteLine($"Lastnames in {departmentName} department:");
                        foreach (var item in lastNames)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "2":
                        Console.Write("Lastname: ");
                        var lastName = Console.ReadLine();
                        Console.Write("Firstname: ");
                        var firstName = Console.ReadLine();
                        var departmentsList = departmentService.GetDepartmentsForPerson(lastName, firstName);
                        Console.WriteLine($"{firstName} {lastName} is part of the following departments:");
                        foreach (var department in departmentsList)
                        {
                            Console.WriteLine(department);
                        }
                        break;

                    case "3":
                        Console.Write("Enter starting X coordinate: ");
                        var startX = int.Parse(Console.ReadLine());
                        Console.Write("Enter starting Y coordinate: ");
                        var startY = int.Parse(Console.ReadLine());
                        var route = customerService.GetShortestRoute(startX, startY);
                        int totalDistance = customerService.CalculateTotalDistance(route);
                        Console.WriteLine("Route:");
                        foreach (var customer in route)
                        {
                            Console.WriteLine($"{customer.Name} at ({customer.X}, {customer.Y})");
                        }
                        Console.WriteLine($"Total Distance: {totalDistance}");
                        break;

                    case "4":
                        Console.WriteLine("Exiting the application.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }

                Console.WriteLine();
            }
        }

    }
}
