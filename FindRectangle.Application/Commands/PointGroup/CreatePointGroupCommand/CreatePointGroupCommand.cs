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
    public class CreatePointGroupCommand : IRequest<int>
    {
      public string Title { get; set; }
    }

    public class CreatePointGroupCommandHandler : IRequestHandler<CreatePointGroupCommand, int>
    {
      private readonly IAppDbContext _context;

      public CreatePointGroupCommandHandler(IAppDbContext context)
      {
        _context = context;
      }

      public async Task<int> Handle(CreatePointGroupCommand request, CancellationToken cancellationToken)
      {
        var entity = new PointGroup();
        entity.Title = request.Title;
        _context.GroupPoints.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
      }
  }
}
