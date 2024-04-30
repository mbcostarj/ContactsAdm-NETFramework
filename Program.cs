using ContactsAdm.Data;
using ContactsAdm.Repository;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
/*builder.Services.AddEntityFrameworkSqlServer()
       .AddDbContext<ContactsContext>(c => c.UseSqlServer(builder.Configuration["Connection:Default"]));
*/
builder.Services.AddScoped<ContactsDapperContext, ContactsDapperContext>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
