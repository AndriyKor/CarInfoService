using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPIGraphQL.Brands;
using WebAPIGraphQL.Cars;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarInfoServiceDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<ISchema, CarsSchema>(services => new CarsSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddTransient<ISchema, BrandsSchema>(services => new BrandsSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(options =>
    options.ConfigureExecution((opt, next) =>
    {
        opt.EnableMetrics = true;
        return next(opt);
    }).AddSystemTextJson()
);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiGraphQL", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiGraphQL v1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL();

app.Run();