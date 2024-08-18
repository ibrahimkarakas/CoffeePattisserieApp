using CoffeePattisserie.Data;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Data.Concrete.EfCore.Repositories;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Service.Concrete;
using CoffeePattisserie.Shared.Helpers.Abstract;
using CoffeePattisserie.Shared.Helpers.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// JSON serileştirme seçeneklerini ayarla
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64;
});

// Veritabanı bağlantısını ayarla (SQLite kullanılıyor)
builder.Services.AddDbContext<CoffeeAppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));

// Repositories (Veri Katmanı) Bağımlılıklarını Ayarla
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICoffeeRepository, EfCoreCoffeeRepository>();
builder.Services.AddScoped<IMoctailRepository, EfCoreMoctailRepository>();
builder.Services.AddScoped<IPattisserieRepository, EfCorePattisserieRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

// Services (İş Katmanı) Bağımlılıklarını Ayarla
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();
builder.Services.AddScoped<IMoctailService, MoctailService>();
builder.Services.AddScoped<IPattisserieService, PattisserieService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Diğer Hizmetler
builder.Services.AddScoped<IImageHelper, ImageHelper>();

// AutoMapper'ı yapılandır
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger'ı yapılandır
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geliştirme ortamı için Swagger'ı etkinleştir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
