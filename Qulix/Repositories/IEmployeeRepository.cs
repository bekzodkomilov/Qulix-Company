using Qulix.Entities;

namespace Qulix.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<List<Employee>> GetAllEmployeeAsync();
    Task<(bool IsSuccess, Exception e)> InsertEmployeeAsync(Employee employee);
    Task<(bool IsSuccess, Exception e)> UpdateEmployeeAsync(Employee employee);
    Task<(bool IsSuccess, Exception e)> DeleteEmployeeIdAsync(int id);
} 