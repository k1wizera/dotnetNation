using dotnetNation;
using dotnetNation.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
try
{
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    context.Database.EnsureCreated();

    var adminRole = new IdentityRole("Admin");
    if (!context.Roles.Any())
    {
        //Create a Role
        roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
    }

    if (!context.Users.Any(u => u.UserName == "admin"))
    {
        //Create an admin
        var adminUser = new IdentityUser()
        {
            UserName = "admin",
            Email = "dotnetnation@gmail.com"
        };
        userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
        //Add Role to User
        userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


startup.Configure(app, app.Environment);
app.Run();
