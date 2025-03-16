using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CarsHandler;

public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
{
    private readonly MovieContext _context;

    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        var values= await _context.Casts.ToListAsync();
        return values.Select(x => new GetCastQueryResult
        {
            CastId = x.CastId,
            Title = x.Title,
            Name = x.Name,
            SurName = x.SurName,
            ImageUrl = x.ImageUrl,
            Overview = x.Overview,
            Biography = x.Biography
        }).ToList();
        //AsnoTracking() nedir?
        //AsNoTracking() metodu, bir sorgunun sonuçlarının izlenmesini devre dışı bırakır. Bu, bir sorgunun sonuçlarının bir bağlamın izleme durumunu değiştirmemesi gerektiğinde yararlıdır. Örneğin, bir sorgunun sonuçları yalnızca okunur ve değiştirilmezse, bu metot, bağlamın bellek kullanımını ve CPU performansını iyileştirebilir.
    }
}
