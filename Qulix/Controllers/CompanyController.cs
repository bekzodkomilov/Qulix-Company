using Microsoft.AspNetCore.Mvc;
using Qulix.Data;
using Qulix.Entities;
using Qulix.Mappers;
using Qulix.Models;
using Qulix.Repositories;

namespace Qulix.Controllers;

public class CompanyController : Controller
{
    private readonly ILogger<CompanyController> _logger;
    private readonly AppDbContext _db;
    private readonly ICompanyRepository _repo;

    public CompanyController(AppDbContext dbContext,ICompanyRepository repository, ILogger<CompanyController> logger)
    {
        _logger = logger;
        _db = dbContext;
        _repo = repository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllCompanyAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CompanyViewModel obj)
    {
        if(ModelState.IsValid)
        {
            await _repo.InsertCompanyAsync(obj.ToEntity());
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public async Task<IActionResult> CompanyEdit([FromRoute] int id) 
    {
        var company = await _repo.GetCompanyByIdAsync(id);

        if (company is null)
            return NotFound();
    
        return View(company);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CompanyEdit(Company obj)
    {
        if(ModelState.IsValid)
        {
            await _repo.UpdateCompanyAsync(obj);
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CompanyDelete([FromRoute]int id)
    {
        if(ModelState.IsValid)
        {
            await _repo.DeleteCompanyIdAsync((await _repo.GetCompanyByIdAsync(id)).Id);
            return RedirectToAction("Index");
        }
        return BadRequest();
    }
}