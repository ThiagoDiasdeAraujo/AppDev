using Microsoft.EntityFrameworkCore;
using SportStore.Authentication;
using SportStore.Data;
using SportStore.Repositories;
using Microsoft.AspNetCore.Identity;
using SportStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository> ();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.SignIn.RequireConfirmedAccount = true;
    }).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();

//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//}).AddEntityFrameworkStores<ApplicationDbContext>();

//Session
//IdleTimeout: geeft aan hoe lang sessie ongebruikt mag zijn alvorens inhoud gewist wordt. Wordt bij elke request gereset.
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
});


builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminOnly", policyBuilder => policyBuilder.RequireClaim("CanManageCatalog", "true"));
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
