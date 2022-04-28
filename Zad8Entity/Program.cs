using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using efcore.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityContext") ?? throw new InvalidOperationException("Connection string 'UniversityContext' not found.")));

var app = builder.Build();

var host = CreateHostBuilder(args).Build();
CreateDbIfNotExists(host);
host.Run();


static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<UniversityContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}
static IHostBuilder CreateHostBuilder(string[] args) =>
 Host.CreateDefaultBuilder(args)
 .ConfigureWebHostDefaults(webBuilder =>
 {
     webBuilder.UseStartup<Startup>();
 });


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
