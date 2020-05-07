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
    public class GetGroupPointsQuery : IRequest<IEnumerable<GroupPointVM>>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetGroupPointsQuery, IEnumerable<GroupPointVM>>
    {
    private readonly IAppDbContext _context;

    public GetTodosQueryHandler(IAppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<GroupPointVM>> Handle(GetGroupPointsQuery request, CancellationToken cancellationToken)
    {
      return await _context.GroupPoints
        .Select(s => new GroupPointVM
          {
            Id = s.Id,
            Title = s.Title
          })
        .ToListAsync();
    }
  }
}


