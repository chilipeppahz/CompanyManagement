using CompanyManagement.Application.Interfaces;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;

namespace CompanyManagement.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IList<ICustomer> _customers;

        public CustomerServices(IList<ICustomer> customers)
        {
            _customers = customers;
        }

        public IList<Customer> GetShortestRoute(int startX, int startY)
        {
            var remainingCustomers = new List<ICustomer>(_customers);
            var currentX = startX;
            var currentY = startY;
            var route = new List<Customer>();

            while (remainingCustomers.Any())
            {
                var nearestCustomer = remainingCustomers
                    .OrderBy(c => Math.Abs(c.X - currentX) + Math.Abs(c.Y - currentY))
                    .First();

                route.Add(new Customer(nearestCustomer.Name, nearestCustomer.X, nearestCustomer.Y));
                currentX = nearestCustomer.X;
                currentY = nearestCustomer.Y;
                remainingCustomers.Remove(nearestCustomer);
            }

            return route;
        }

        public int CalculateTotalDistance(IList<Customer> route)
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
