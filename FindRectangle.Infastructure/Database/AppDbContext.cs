using FindRectangle.Application.Common.Interfaces;
using FindRectangle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRectangle.Infastructure.Database
{
    public class AppDbContext : DbContext, IAppDbContext
  {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Point> Points { get; set; }
        public DbSet<PointGroup> GroupPoints { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken() )
        {
          return await base.SaveChangesAsync(cancellationToken);
        }
  }
}
