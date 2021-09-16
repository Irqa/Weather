using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class WeatherContext:DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherModel> Weathers { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<TokenModel> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(1).CopyTo(bytes, 0);
            RoleModel adminRole = new RoleModel { Id = new Guid(bytes), Name = "admin" };
            UserModel adminUser = new UserModel { Id = new Guid(bytes), Email = "admin@gmail.com", Password = CryptoHelper.Crypto.HashPassword("admin"), RoleId = adminRole.Id };
            BitConverter.GetBytes(2).CopyTo(bytes, 0);
            RoleModel userRole = new RoleModel { Id = new Guid(bytes), Name = "user" };
            modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { adminRole, userRole });
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] { adminUser });
            base.OnModelCreating(modelBuilder);
        } 
    }
}
