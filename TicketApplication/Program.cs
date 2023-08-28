using Microsoft.EntityFrameworkCore;
using TicketApplication.Data.Data;
using TicketApplication.Data.Repository.Imp;
using TicketApplication.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using TicketApplication.Utility;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Services.Interface;
using TicketApplication.Services.Impl;
using TicketApplication.Models.Relationship;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();

//  Repositories 

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Movie>, MoviesRepository>();
builder.Services.AddScoped<IRepository<CinemaHall>, CinemaHallRepository>();
builder.Services.AddScoped<IRepository<MovieShowing>, MovieShowingRepository>();
builder.Services.AddScoped<IRepository<ShoppingCart>, ShoppingCartRepository>();
builder.Services.AddScoped<IRepository<ShowingInShoppingCart>, ShowingInShoppingCartRepository>();
builder.Services.AddScoped<IRepository<ShowingInOrder>, ShowingInOrderRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<ApplicationUser>, UserRepository>();

// Services

builder.Services.AddScoped<IMovieShowingService, MovieShowingService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


static bool CheckDatabaseExists(string connectionString, string databaseName)
{
    string sqlQuery;
    bool result = false;
    try
    {
        SqlConnection conn = new SqlConnection(connectionString);
        sqlQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
        using (conn)
        {
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                conn.Open();
                int databaseID = (int)cmd.ExecuteScalar();
                conn.Close();
                result = (databaseID > 0);
            }
        }
    }
    catch (Exception ex)
    {
        result = false;
    }
    return result;
}
// "Server=sql_server;Database=TicketApplicationDb;User Id=sa;Password=ticketAppPassword77%;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"
//  TicketApplicationDb
using (var scope = app.Services.CreateScope())
{
   
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (CheckDatabaseExists("Server=sql_server;Database=TicketApplicationDb;User Id=sa;Password=ticketAppPassword77%;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True", "TicketApplicationDb") == false)
    {
        context.Database.Migrate();
    }
        
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
