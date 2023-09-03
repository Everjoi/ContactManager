using ContactManager;
using ContactManager.Repository.Implementation;
using ContactManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPersonRepository,PersonRepository>();
builder.Services.AddDbContext<ContactManagerDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});


var app = builder.Build();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=Upload}/{id?}");


app.Run();
