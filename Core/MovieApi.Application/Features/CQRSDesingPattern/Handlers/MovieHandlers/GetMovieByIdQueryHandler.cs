using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;

public class GetMovieByIdQueryHandler
{
    private readonly MovieContext context;

    public GetMovieByIdQueryHandler(MovieContext context)
    {
        this.context = context;
    }
    public async Task<GetMovieByIdQueryResult> Handler(GetMovieByIdQuery query)
    {
        var movie = await context.Movies.FindAsync(query.MovieId);
        return new GetMovieByIdQueryResult
        {
            MovieId = movie.MovieId,
            Title = movie.Title,
            CoverImageUrl = movie.CoverImageUrl,
            Rating = movie.Rating,
            Description = movie.Description,
            Duration = movie.Duration,
            ReleaseDate = movie.ReleaseDate,
            CreatedYear = movie.CreatedYear,
            Status = movie.Status
        };
    }
}
