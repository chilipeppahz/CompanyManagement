using CompanyManagement.Application.Interfaces;
using CompanyManagement.Domain.Interfaces;

namespace CompanyManagement.Application.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IList<IDepartment> _departments;

        public DepartmentServices(IList<IDepartment> departments)
        {
            _departments = departments;
        }

        public IList<string> GetSurnamesInDepartment(string departmentName)
        {
            var department = _departments.FirstOrDefault(d => d.Name == departmentName);
            if (department == null) return new List<string>();
            return department.Members.Select(m => m.Lastname).ToList();
        }

        public IList<string> GetDepartmentsForPerson(string lastName, string firstName)
        {
            return _departments
                .Where(d => d.Members.Any(m => m.Lastname == lastName && m.Firstname == firstName))
                .Select(d => d.Name)
                .ToList();
        }
    }
}
