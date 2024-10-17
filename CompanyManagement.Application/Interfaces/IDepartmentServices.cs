namespace CompanyManagement.Application.Interfaces
{
    public interface IDepartmentServices
    {
        IList<string> GetSurnamesInDepartment(string departmentName);
        IList<string> GetDepartmentsForPerson(string lastName, string firstName);
    }
}
