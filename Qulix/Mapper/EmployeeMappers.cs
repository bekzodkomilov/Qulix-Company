using System.Runtime.InteropServices;
using Qulix.Entities;
using Qulix.Models;

namespace Qulix.Mappers;

public static class EmployeeMappers
{
    public static Employee ToEntity(this EmployeeViewModel model)
        => new Employee()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            SignedDate = model.SignedDate,
            Position = EPosition.None,
            CompanyId = model.CompanyId
        };

    public static EmployeeViewModel ToModel(this Employee employee)
        => new EmployeeViewModel()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            MiddleName = employee.MiddleName,
            SignedDate = employee.SignedDate,
            Position = default(EPosition)
        };
}