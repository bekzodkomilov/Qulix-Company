using Qulix.Entities;

namespace Qulix.Models;

public class EmployeeViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime SignedDate { get; set; }
    public EPosition Position { get; set; }
    public int CompanyId { get; set; }
}