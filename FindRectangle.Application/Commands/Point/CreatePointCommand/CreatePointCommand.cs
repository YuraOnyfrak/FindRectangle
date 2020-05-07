using FindRectangle.Application.Common.Interfaces;
using FindRectangle.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRectangle.Application.Commands
{
    public class CreatePointCommand : IRequest
    {
      public int IdGroup { get; set; }
      public int[,] Coordinates { get; set; }
    }

    public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand>
    {
      private readonly IAppDbContext _context;

      public CreatePointCommandHandler(IAppDbContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(CreatePointCommand request, CancellationToken cancellationToken)
      {
          List<Point> points = new List<Point>();

          int countRow = request.Coordinates.GetUpperBound(0) + 1;
          for (int i = 0; i < countRow; i++)      
          {
              points.Add(new Point
              {
                GroupId = request.IdGroup,
                X = request.Coordinates[i,0],
                Y = request.Coordinates[i, 1],
              });
          }
       
          _context.Points.AddRange(points);
          await _context.SaveChangesAsync(cancellationToken);

          return Unit.Value;
      }
  }
}
