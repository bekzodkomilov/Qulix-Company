using Microsoft.EntityFrameworkCore;
using Qulix.Data;
using Qulix.Entities;

namespace Qulix.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<CompanyRepository> _logger;

    public CompanyRepository(AppDbContext context, ILogger<CompanyRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<(bool IsSuccess, Exception e)> DeleteCompanyIdAsync(int id)
    {
       try
        {
            var result = await GetCompanyByIdAsync(id);
             if(result == default)
            {
                _logger.LogInformation($"Company doesn't exist: {id}");
                return (false, new ArgumentException("Not found."));
            }
            _context.Companies.Remove(result);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Company {result.Id} was deleted.");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Company wasn't deleted.\nMessage: {e.Message}");
            return (false, e);
        }
    }

    public async Task<List<Company>> GetAllCompanyAsync()
        => await _context.Companies.Include(p => p.Employees).OrderBy(c => c.Id).ToListAsync();

    public async Task<Company> GetCompanyByIdAsync(int id)
        => await _context.Companies.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == id);
    

    public async Task<(bool IsSuccess, Exception e)> InsertCompanyAsync(Company company)
    {
        try
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Company was not added {e.Message} ");
            return (false, e);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> UpdateCompanyAsync(Company company)
    {
        try
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Company {company.Id} was updated.");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError("Company was not updated.");
            return (false, e);
        }
    }
}