using CompanyManagement.Domain.Interfaces;

namespace CompanyManagement.Domain.Entities
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Customer(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
