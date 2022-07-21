using Microsoft.EntityFrameworkCore;
using Qulix.Data;
using Qulix.Entities;

namespace Qulix.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<EmployeeRepository> _logger;

    public EmployeeRepository(AppDbContext context, ILogger<EmployeeRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<(bool IsSuccess, Exception e)> DeleteEmployeeIdAsync(int id)
    {
         try
        {
            var result = await GetEmployeeByIdAsync(id);
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Employee {result.Id} was deleted.");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Employee wasn't deleted.\nMessage: {e.Message}");
            return (false, e);
        }
    }

    public async Task<List<Employee>> GetAllEmployeeAsync()
        => await _context.Employees.Include(p => p.Company).ToListAsync();
       

    public async Task<Employee> GetEmployeeByIdAsync(int id)
        => await _context.Employees.Include(p => p.Company).FirstOrDefaultAsync(p => p.Id == id);
        

    public async Task<(bool IsSuccess, Exception e)> InsertEmployeeAsync(Employee employee)
    {
        try
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Employee was not added{e.Message}");
            return (false, e);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> UpdateEmployeeAsync(Employee employee)
    {
        try
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Employee {employee.Id} was updated.");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError("Employee was not updated.");
            return (false, e);
        }
    }
}