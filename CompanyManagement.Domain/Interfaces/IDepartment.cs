using CompanyManagement.Domain.Entities;

namespace CompanyManagement.Domain.Interfaces
{
    public interface IDepartment
    {
        string Name { get; set; }
        string Location { get; set; }
        IList<Person> Members { get; set; }

        void AddMember(Person person);
        void RemoveMember(Person person);
    }
}
