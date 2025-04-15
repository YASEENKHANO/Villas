using Microsoft.EntityFrameworkCore;
using GulfVillas.Infrastructure.Data;
using GulfVillas.Application.Common.Interfaces;
using GulfVillas.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// here we added connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//GetConnectionString is a Helper method which gets our connection string from appsetting.json file. If we change the name of the key there then we have to use another method here which is GetValue

//Prevoius connection string : "DefaultConnection": "Server=DESKTOP-LFIUSB6\\SQLEXPRESS;Database=GulfVillas;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

//query for access
app.Use(async (context, next) =>
{
    if (!context.Request.Query.ContainsKey("devaccess"))
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Access Denied Contact Yaseen For Accessing");
        return;
    }
    await next();
});

// Middleware to serve static files
app.UseStaticFiles();

// Middleware to check for the "devaccess" query parameter
//app.Use(async (context, next) =>
//{
//    if (!context.Request.Query.ContainsKey("devaccess"))
//    {
//        context.Response.StatusCode = 403;
//        // Construct the full path to the image
//        var imagePath = "/images/accessDenied.png"; // Assuming 'wwwroot' is the web root
//        var fullImagePath = Path.Combine(context.Request.PathBase, imagePath);

//        // Redirect the user to the access denied image
//        context.Response.Redirect(fullImagePath);
//        return;
//    }
//    await next();
//});



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
