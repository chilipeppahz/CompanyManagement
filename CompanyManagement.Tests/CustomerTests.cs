using CompanyManagement.Application.Interfaces;
using CompanyManagement.Application.Services;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using System.Diagnostics;

namespace CompanyManagement.Tests
{
    public class CustomerTests
    {
        private readonly ICustomerServices _customerService;

        public CustomerTests()
        {
            var customers = new List<ICustomer>
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

            _customerService = new CustomerServices(customers);
        }

        [Fact]
        public void ShortestRouteTest()
        {
            var route = _customerService.GetShortestRoute(0, 0);
            int totalDistance = CalculateTotalDistance(route);

            Debug.WriteLine("Total Distance: " + totalDistance);
            foreach (var customer in route)
            {
                Debug.WriteLine(customer.Name);
            }

            Assert.NotEmpty(route);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        [InlineData(50, 50)]
        public void GetShortestRoute_ThreeScenarios(int startX, int startY)
        {
            var route = _customerService.GetShortestRoute(startX, startY);

            int totalDistance = CalculateTotalDistance(route);

            Debug.WriteLine($"Starting from ({startX}, {startY})");
            Debug.WriteLine($"Total Distance: {totalDistance}");
            foreach (var customer in route)
            {
                Debug.WriteLine($"{customer.Name} at ({customer.X}, {customer.Y})");
            }

            Assert.NotEmpty(route); 
        }

        private int CalculateTotalDistance(IList<Customer> route)
        {
            int totalDistance = 0;
            int currentX = route[0].X;
            int currentY = route[0].Y;

            for (int i = 1; i < route.Count; i++)
            {
                totalDistance += Math.Abs(route[i].X - currentX) + Math.Abs(route[i].Y - currentY);
                currentX = route[i].X;
                currentY = route[i].Y;
            }

            return totalDistance;
        }
    }
}
