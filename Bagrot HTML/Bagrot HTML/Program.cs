var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<VisitorService>();

// Add Session service
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;
});

// Serverside Memory ==> Application
builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Set the ServiceProvider
ServiceProviderAccessor.ServiceProvider = app.Services;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();

public static class ServiceProviderAccessor
{
    public static IServiceProvider ServiceProvider { get; set; }
}

public class VisitorService
{
    private int _visitorCount = 0;
    public int GetVisitorCount() => _visitorCount;
    public void IncrementVisitorCount() => _visitorCount++;
}
