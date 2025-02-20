﻿using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async void Handle(UpdateMovieCommand command)
    {
        var movie = await _context.Movies.FindAsync(command.MovieId);
        movie.Title = command.Title;
        movie.CoverImageUrl = command.CoverImageUrl;
        movie.Rating = command.Rating;
        movie.Description = command.Description;
        movie.Duration = command.Duration;
        movie.ReleaseDate = command.ReleaseDate;
        movie.CreatedYear = command.CreatedYear;
        movie.Status = command.Status;

        await _context.SaveChangesAsync();
    }
}
