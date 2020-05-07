using FindRectangle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRectangle.Application.Queries
{
    public class GetPointsByGroupQuery : IRequest<int[,]>
    {
      public int GroupId { get; set; }
    }

    public class GetPointsByGroupQueryHandler : IRequestHandler<GetPointsByGroupQuery, int[,]>
    {
      private readonly IAppDbContext _context;

      public GetPointsByGroupQueryHandler(IAppDbContext context)
      {
        _context = context;
      }

      public async Task<int[,]> Handle(GetPointsByGroupQuery request, CancellationToken cancellationToken)
      {
          var points = await _context.Points.Where(s => s.GroupId == request.GroupId).ToListAsync();

          int[,] arrayPoints = new int[points.Count(),2];

          for (int i = 0; i < points.Count(); i++)
          {
            arrayPoints[i, 0] = points.ElementAt(i).X;
            arrayPoints[i, 1] = points.ElementAt(i).Y;
          }

          return arrayPoints;
      }
    }
}
