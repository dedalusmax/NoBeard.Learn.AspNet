// 1. faza = builder

using Microsoft.Data.SqlClient;
using NoBeard.Learn.AspNet.Data.Repositories;
using NoBeard.Learn.AspNet.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();

var app = builder.Build();

// 2. faza = konfiguracija web hosta

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    Console.WriteLine("Development environment");
}
else if (app.Environment.IsProduction())
{
    Console.WriteLine("Production environment");    
}
else if (app.Environment.IsStaging())
{
    Console.WriteLine("Staging environment");
}
else if (app.Environment.IsEnvironment("Testing"))
{
    Console.WriteLine("Testing environment");
}
else
{
    throw new Exception("Unknown environment");
}

/*
var connectionString = "Server=(localdb)\\mssqllocaldb;Database=invoices2;Trusted_Connection=true;";

var sqlConnection = new SqlConnection(connectionString);

try
{
    sqlConnection.Open();
}
catch (SqlException ex)
{
    Console.WriteLine($"Error connecting to database: {ex.Message}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
    throw;
}
finally
{
    sqlConnection.Close();
    sqlConnection.Dispose();
}

*/

/*
var logLevel = app.Configuration.GetValue<string>("Logging:LogLevel:Default");
var featuresSection = app.Configuration.GetSection("Features"); 
var connectionString = app.Configuration.GetConnectionString("DefaultConnection"); // section = "ConnectionStrings"
*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
