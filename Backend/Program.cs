using AchiHunter.Backend.Data;
using AchiHunter.Backend.Model;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


string? dbCon = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(dbCon);
});

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUserModel>()
    .AddEntityFrameworkStores<ApplicationDbContext>();






var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<AppUserModel>();

app.MapGet("/", () => "Hello World!");

app.Run();
