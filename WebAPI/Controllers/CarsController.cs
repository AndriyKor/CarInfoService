using Infrastructure;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace WebAPI.Controllers;

public class CarsController : ODataController
{
    private readonly CarInfoServiceDbContext _dbContext;

    public CarsController(CarInfoServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery(PageSize = 10)]
    public IQueryable<Car> Get()
    {
        return _dbContext.Cars;
    }

    [EnableQuery]
    public async Task<IActionResult> Post([FromBody] Car car)
    {
        _dbContext.Cars.Add(car);
        await _dbContext.SaveChangesAsync();
        return Created(car);
    }
}