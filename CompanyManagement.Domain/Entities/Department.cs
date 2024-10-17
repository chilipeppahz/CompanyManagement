using System.Collections.Generic;
using CompanyManagement.Domain.Interfaces;

namespace CompanyManagement.Domain.Entities
{
    public class Department : IDepartment
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IList<Person> Members { get; set; }

        public Department(string name, string location, IList<Person> members)
        {
            Name = name;
            Location = location;
            Members = members;
        }

        public void AddMember(Person person)
        {
            Members.Add(person);
        }

        public void RemoveMember(Person person)
        {
            Members.Remove(person);
        }
    }
}
