using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CarsHandler;

public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
{
    private readonly MovieContext _context;
    //Constructor metot genel olarak kullanılan bir metottur. Bir sınıfın nesnesi oluşturulduğunda çalışan ilk metottur.
    public GetCastByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
         var values = await _context.Casts.FindAsync(request.CastId);
        return new GetCastByIdQueryResult
        {
            CastId = values.CastId,
            Title = values.Title,
            Name = values.Name,
            SurName = values.SurName,
            ImageUrl = values.ImageUrl,
            Overview = values.Overview,
            Biography = values.Biography
        };
    }
}
