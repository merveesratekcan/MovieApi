﻿using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Results.CastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;

public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
{
    public GetCastByIdQuery(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }

}
