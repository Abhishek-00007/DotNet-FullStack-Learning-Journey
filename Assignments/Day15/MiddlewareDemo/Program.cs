var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("----- Incoming Request -----");
    Console.WriteLine($"Method: {context.Request.Method}");
    Console.WriteLine($"Path: {context.Request.Path}");

    await next();

    Console.WriteLine("----- Outgoing Response -----");
    Console.WriteLine($"Status Code: {context.Response.StatusCode}");
});

app.UseExceptionHandler("/Error");

app.Use(async (context, next) =>
{
    context.Response.Headers.Add(
        "Content-Security-Policy",
        "default-src 'self';");

    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
