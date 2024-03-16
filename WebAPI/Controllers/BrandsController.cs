using Infrastructure;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace WebAPI.Controllers;

public class BrandsController : ODataController
{
    private readonly CarInfoServiceDbContext _dbContext;

    public BrandsController(CarInfoServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery(PageSize = 10)]
    public IQueryable<Brand> Get()
    {
        return _dbContext.Brands;
    }

    [EnableQuery]
    public async Task<IActionResult> Post([FromBody] Brand brand)
    {
        _dbContext.Brands.Add(brand);
        await _dbContext.SaveChangesAsync();
        return Created(brand);
    }
}