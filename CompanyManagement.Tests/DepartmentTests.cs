using CompanyManagement.Application.Interfaces;
using CompanyManagement.Application.Services;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;

namespace CompanyManagement.Tests
{

    public class DepartmentTests
    {
        private readonly IDepartmentServices _departmentService;

        public DepartmentTests()
        {
            var departments = new List<IDepartment>
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

            _departmentService = new DepartmentServices(departments);
        }

        [Fact]
        public void GetSurnamesInDepartment_ReturnsCorrectSurnames()
        {
            var lastNames = _departmentService.GetSurnamesInDepartment("Sales");
            Assert.Equal(new List<string> { "Bradshaw", "Thompson", "Johnson" }, lastNames);
        }

        [Fact]
        public void GetDepartmentsForPerson_ReturnsCorrectDepartments()
        {
            var departments = _departmentService.GetDepartmentsForPerson("Bradshaw", "Lisa");
            Assert.Equal(new List<string> { "Purchasing", "Sales" }, departments);
        }
    }
}