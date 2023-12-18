using Bussiness.Services;
using Bussiness.Services.Abstracts;
using Core.AOP;
using Data.Contexts;
using Data.Repositories;
using Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=localhost,1433;Database=MemberDb;User Id=sa;Password=1Secure*Password1;TrustServerCertificate=true;"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
