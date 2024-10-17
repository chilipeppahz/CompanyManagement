using CompanyManagement.Domain.Entities;

namespace CompanyManagement.Application.Interfaces
{
    public interface ICustomerServices
    {
        IList<Customer> GetShortestRoute(int startX, int startY);
        int CalculateTotalDistance(IList<Customer> route);
    }
}
