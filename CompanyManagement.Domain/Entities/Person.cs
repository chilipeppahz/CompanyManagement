namespace CompanyManagement.Domain.Entities
{
    public class Person
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Title { get; set; }

        public Person(string lastName, string firstName, string title)
        {
            Lastname = lastName;
            Firstname = firstName;
            Title = title;
        }
    }

}
