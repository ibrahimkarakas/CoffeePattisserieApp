using CoffeePattisserie.Data;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Data.Concrete.EfCore.Repositories;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Service.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<CoffeeAppDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));

builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICoffeeRepository, EfCoreCoffeeRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
