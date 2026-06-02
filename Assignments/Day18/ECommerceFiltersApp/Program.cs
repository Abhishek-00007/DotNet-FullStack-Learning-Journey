using ECommerceFiltersApp.Filters;
using ECommerceFiltersApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<LoggingFilter>();
builder.Services.AddScoped<AuthenticationFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<LoggingFilter>();
    options.Filters.AddService<GlobalExceptionFilter>();
    options.Filters.AddService<AuthenticationFilter>();
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();