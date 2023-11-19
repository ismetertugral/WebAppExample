using WebApp.Data.Contexts;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositories;
using WebApp.Data.Uow;
using WebApp.Mapping;
using WebApp.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//Services>
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=EfCore;integrated security=true;TrustServerCertificate=True;");
    opt.LogTo(Console.WriteLine, LogLevel.Information);
});
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IBlogMapper, BlogMapper>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
//<Services

var app = builder.Build();

//Middleware>
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
string? isCamelCase = app.Configuration.GetSection("SpecialConfig1:isCamelCase").Value;
string? hostName = app.Configuration.GetSection("SpecialConfig1:NameofHost").Value;
string? startYear = app.Configuration.GetSection("SpecialConfig1:StartYear").Value;

app.UseExceptionHandler("/Error/Index");
app.UseStatusCodePagesWithReExecute("/Status/Index","?code={0}");
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/node_modules",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
});
app.UseRouting();
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
//app.MapControllerRoute(
//    name: "SpecialRoute",
//    pattern: "test/{action=Index}/{id?}",
//    defaults: new { Controller = "Home" }
//);
app.MapControllerRoute(
    name: "Defaults",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseSession();
app.UseMiddleware<ResponseEditingMiddleware>();
app.UseMiddleware<RequestEditingMiddleware>();
//<Middleware

app.Run();
