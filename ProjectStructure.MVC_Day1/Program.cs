using ProjectStructure.Domain.DataAccess;
using ProjectStructure.Repository.IRepository;
using ProjectStructure.Repository.Repository;
using ProjectStucture.Application.Services;
using ProjectStucture.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DummyDataDB>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IRookieService, RookieService>();
builder.Services.AddScoped<IExcelService, ExcelService>();

var app = builder.Build();

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


app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //    name: "areaRoute",
    //    pattern: "{area:exists}/{controller=Rookie}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{area=NashTech}/{controller=Rookie}/{action=Index}/{id?}");
});


app.Run();
