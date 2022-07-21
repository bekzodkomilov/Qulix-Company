using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime SignedDate { get; set; }
    public EPosition Position { get; set; }
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }
    public int CompanyId { get; set; }
}