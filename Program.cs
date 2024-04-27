
using BusinessLogic.Services;
using Collab_API.Services;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using PostSharp.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using IProject = BusinessLogic.Services.IProject;
using Microsoft.AspNetCore.Authentication;


namespace Collab_API
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ITask, TaskServices>();
            builder.Services.AddSingleton<IProject, ProjectServices>();
            builder.Services.AddSingleton<IDocument, DocumentsServices>();
            builder.Services.AddSingleton<ITeam, TeamsServices>();
            builder.Services.AddSingleton<ITeamUser, TeamUsersServices>();
            builder.Services.AddSingleton<ISprint, SprintServices>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
           


            builder.Services.AddAuthorization();
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Administrator", "Project Lead", "Developer", "Reporter", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

            }


            using (var scope = app.Services.CreateScope())
            {
                var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string email = "malek@admin.com";
                string password = "Test1234,";
                string email2 = "malek2@admin.com";
                string password2 = "Test123,";

                if (await UserManager.FindByEmailAsync(email) == null)

                {
                    var user = new IdentityUser();
                    var user2= new IdentityUser();

                    user.UserName = email;

                    user.Email = email;
                    user2.UserName = email;

                    user2.Email = email;

                    await UserManager.CreateAsync(user, password);

                    await UserManager.AddToRoleAsync(user, "Administrator");
                    await UserManager.CreateAsync(user2, password2);

                    await UserManager.AddToRoleAsync(user2, "Developer");



                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                // Map Identity API endpoints
                app.MapIdentityApi<IdentityUser>();

                // Map API controllers
                app.MapControllers();

                app.Run();
            }
        }
    }
}

