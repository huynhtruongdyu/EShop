using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

builder.Services.AddScoped<IDateTimeService, DateTimeService>();


var localizationOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(LocalizationConstants.DefaultCulture),
    SupportedCultures = LocalizationConstants.SupportedCultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = LocalizationConstants.SupportedCultures.Select(c => new CultureInfo(c)).ToList()
};

localizationOptions.RequestCultureProviders = new[]
{
    new RouteDataRequestCultureProvider()
    {
        RouteDataStringKey = "culture",
        UIRouteDataStringKey = "culture"
    }
};


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");




app.Run();
