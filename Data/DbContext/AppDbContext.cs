using Data.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Data.DbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUserDto, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerDto> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDto>().HasData(
                    new PlayerDto
                    {
                        id = 1,
                        Name = "Youri",
                        Preference_one = Position.Libero,
                        Preference_two = Position.Rightback,
                        Preference_three = Position.Rightmidfield,
                        Priority = 6,
                        TeamId = 1
                    }
                );
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }

    }
}