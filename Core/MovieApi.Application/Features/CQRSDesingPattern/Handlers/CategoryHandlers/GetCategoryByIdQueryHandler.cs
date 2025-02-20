using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.CategoryResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<GetCategoryByIdQueryResult> Handler(GetCategoryByIdQuery query)
    {
        var category = await _context.Categories.FindAsync(query.CategoryId);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
    }
}
