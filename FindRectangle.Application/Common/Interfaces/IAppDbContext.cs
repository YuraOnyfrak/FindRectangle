using FindRectangle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRectangle.Application.Common.Interfaces
{
  public interface IAppDbContext
  {
     DbSet<Point> Points { get; set; }
     DbSet<PointGroup> GroupPoints { get; set; }
     Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}
