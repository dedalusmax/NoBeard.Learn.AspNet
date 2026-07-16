// 1. faza = builder

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
