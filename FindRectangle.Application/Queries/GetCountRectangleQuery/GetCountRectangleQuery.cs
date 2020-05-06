using FindRectangle.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRectangle.Application.Queries.GetCountRectangleQuery
{
    public class GetCountRectangleQuery : IRequest<int>
    {
        public int[,] Points { get; set; }
    }

    public class GetCountRectangleQueryHandlet : IRequestHandler<GetCountRectangleQuery, int>
    {
        private readonly IFindRectangleService _findRectangleService;

        public GetCountRectangleQueryHandlet(IFindRectangleService findRectangleService)
        {
            _findRectangleService = findRectangleService;
        }

        public async Task<int> Handle(GetCountRectangleQuery request, CancellationToken cancellationToken)
        {
            return  await Task.Run(() =>_findRectangleService.GetCountRectangle(request.Points));
        }
    }
}
