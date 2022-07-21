namespace Qulix.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OrganizationalForm { get; set; }
    public ICollection<Employee> Employees { get; set; }
}