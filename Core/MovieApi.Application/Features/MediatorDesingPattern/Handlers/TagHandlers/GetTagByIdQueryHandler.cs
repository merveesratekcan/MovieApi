﻿using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Results.TagResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers;

public class GetTagByIdQueryHandler:IRequestHandler<GetTagByIdQuery,GetTagByIdQueryResult>
{
    private readonly MovieContext _context;
    
    public GetTagByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Tags.FindAsync(request.TagId);
        return new GetTagByIdQueryResult
        {
            Title = values.Title
        };
    }
}
