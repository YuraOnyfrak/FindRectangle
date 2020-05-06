using FindRectangle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Infastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Point> Points { get; set; }
        public DbSet<PointGroup> PointGroups { get; set; }
    }
}
