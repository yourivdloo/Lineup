﻿using Data.Dtos;
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
    public class LineupDbContext : IdentityDbContext<ApplicationUserDto, IdentityRole<Guid>, Guid>
    {
        public LineupDbContext(DbContextOptions<LineupDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerDto> Players { get; set; }
        public DbSet<TeamDto> Teams { get; set; }
        public DbSet<FormationDto> Formations { get; set; }
        public DbSet<PlayerPositionDto> PlayerPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDto>().HasData(
                    new PlayerDto
                    {
                        id = 1,
                        Name = "Youri",
                        Age = 17,
                        TeamId = 1
                    }
                );
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }

    }
}