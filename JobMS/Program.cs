using JobMS;
using JobMS.Auth_IdentityModel;
using JobMS.Data;
using JobMS.FilesUpload;
using JobMS.Helper;
using JobMS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Add MVC Services
builder.Services.AddControllersWithViews();

// ? Database Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Coon")));

// ? Dependency Injection
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IFileService, FileService>();


// Add Identity with custom classes and long key
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddTransient<ISignInHelper, SignInHelper>();

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

app.UseAuthentication();   // ✅ MUST
app.UseAuthorization();

// ? Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();