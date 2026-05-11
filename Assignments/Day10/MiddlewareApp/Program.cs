var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


// Middleware for global exception handling
app.UseExceptionHandler("/error");

// HTTPS redirection
app.UseHttpsRedirection();


// Custom middleware for request logging
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    await next();

    Console.WriteLine($"Response Status: {context.Response.StatusCode}");
});


// Content Security Policy Middleware
app.Use(async (context, next) =>
{
    context.Response.Headers.Append(
        "Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self';"
    );

    await next();
});


// Serve static files
app.UseStaticFiles();


// Error page
app.Map("/error", (HttpContext context) =>
{
    return Results.Content(
        "<h1>Something went wrong!</h1>",
        "text/html"
    );
});


// Default route
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});


app.Run();