using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Repositories;
using SportStore.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddScoped<ItCart, ProductRepository>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Session
//IdleTimeout: geeft aan hoe lang sessie ongebruikt mag zijn alvorens inhoud gewist wordt. Wordt bij elke request gereset.
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
