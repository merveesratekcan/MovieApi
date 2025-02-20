﻿using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public UpdateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateCategoryCommand command)
    {
        var category = await _context.Categories.FindAsync(command.CategoryId);
        category.CategoryName = command.CategoryName;
        await _context.SaveChangesAsync();
    }
}
