using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetMovieQueryResult>> Handler()
    {
        var values = await _context.Movies.ToListAsync();
        return values.Select(x => new GetMovieQueryResult
        {
            MovieId = x.MovieId,
            Title = x.Title,
            CoverImageUrl = x.CoverImageUrl,
            Rating = x.Rating,
            Description = x.Description,
            Duration = x.Duration,
            ReleaseDate = x.ReleaseDate,
            CreatedYear = x.CreatedYear,
            Status = x.Status,
        }).ToList();
    }
}
