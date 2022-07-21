using Qulix.Entities;

namespace Qulix.Repositories;

public interface ICompanyRepository
{
    Task<Company> GetCompanyByIdAsync(int id);
    Task<List<Company>> GetAllCompanyAsync();
    Task<(bool IsSuccess, Exception e)> InsertCompanyAsync(Company company);
    Task<(bool IsSuccess, Exception e)> UpdateCompanyAsync(Company company);
    Task<(bool IsSuccess, Exception e)> DeleteCompanyIdAsync(int id);
} 