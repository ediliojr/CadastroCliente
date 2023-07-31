using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CadastroCliente.Data;
using Microsoft.AspNetCore.Identity;
using CadastroCliente.Areas.Identity.Data;
using System;
using UserDbContext;

var builder = WebApplication.CreateBuilder(args);
string? mySqlConnection = builder.Configuration.GetConnectionString("CadastroClienteContext");

if (mySqlConnection is null)
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContextPool<CadastroClienteContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

// Rename UserDbContext to AppDbContext or any other appropriate name
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));


builder.Services.AddDefaultIdentity<CadastroClienteUser>(options =>
{
    // Identity options if needed
})
.AddEntityFrameworkStores<CadastroClienteContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
