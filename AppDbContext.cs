using Collab_API;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString, b => b.MigrationsAssembly("Collab API")).Options;
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public virtual DbSet<Project> projects { get; set; }
            public virtual DbSet<DataAccess.Models.Task> tasks { get; set; }
            public virtual DbSet<Sprint> sprints { get; set; }
            public virtual DbSet<Team> teams { get; set; }
            public virtual DbSet<Document> documents { get; set; }
            public virtual DbSet<TeamUsers> teamusers { get; set; }
            public virtual DbSet<IdentityUser> Administrator { get; set; }
            

    }
}
