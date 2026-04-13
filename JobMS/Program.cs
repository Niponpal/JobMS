using JobMS.Data;
using JobMS.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Add MVC Services
builder.Services.AddControllersWithViews();

// ? Database Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Coon")));

// ? Dependency Injection
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

var app = builder.Build();

// ? Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ? Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();   // Static files (css, js, images)
app.UseRouting();
app.UseAuthorization();

// ? Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();