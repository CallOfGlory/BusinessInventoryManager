using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Repositories;
using WebApplication2.Services.Interface;
using WebApplication2.Services.Repository;

namespace WebApplication2
{
    class Programs
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Configuration
            builder.Services.AddDbContext<ApplicationContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Uncomment for in-memory database (development/testing)
            //builder.Services.AddDbContext<ApplicationContext>(opts =>
            //{
            //    opts.UseInMemoryDatabase("BusinessInventoryManagement");
            //});

            // Authentication Configuration
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Enterance/Login";
                    options.LogoutPath = "/Enterance/Logout";
                    options.AccessDeniedPath = "/Home/Error";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.SlidingExpiration = true;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                });

            builder.Services.AddAuthorization();

            // Repositories (Data Access)
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IEntranceRepository, EntranceRepository>();
            builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            // Services (Business Logic)
            builder.Services.AddScoped<IPasswordService, PasswordService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IEnteranceService, EnteranceService>();
            builder.Services.AddScoped<IBusinessService, BusinessService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            builder.Services.AddScoped<IClaimsService, ClaimsService>();
            builder.Services.AddScoped<IValidationService, ValidationService>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
        }
    }
}
