using LuckySpin.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

//NOTE - DIJ Part 0: Registers the classes, TextTranform and Spin class, as available for injection
//      The TextTransform class is registered with a Transient< > lifetime
//TODO: Register the Spin class with a Scoped< > lifetime
builder.Services.AddTransient<TextTransform>();
builder.Services.AddScoped<Spin>();

var app = builder.Build();


/* Middleware in the HTTP Request Pipeline
 */
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{luck:range(1,10)}",
    defaults: new {
        controller = "Spinner",
        action = "Index",
        luck = 7
    });

app.Run();

// Wawa