using AdvancedRoutingMVC.Constraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("guidcustom", typeof(GuidConstraint));
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "guidroute",
    pattern: "Custom/{id:guidcustom}",
    defaults: new
    {
        controller = "Products",
        action = "ProductGuid"
    });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();