using DataAccess.Configurations;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IDbContext:IdentityDbContext<AppUser, AppRole,int>
    {
        public IDbContext(DbContextOptions<IDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\BERKAY\\source\\repos\\SinavOlusturmaApp\\DataAccess\\Db\\SınavApp.db;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Exam> Exams { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            base.OnModelCreating(builder);
        }

    }
    public class IDbContextFactory : IDesignTimeDbContextFactory<IDbContext>
    {
        public IDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IDbContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\BERKAY\\source\\repos\\SinavOlusturmaApp\\DataAccess\\Db\\SınavApp.db;");
            

            return new IDbContext(optionsBuilder.Options);
        }
    }
}
