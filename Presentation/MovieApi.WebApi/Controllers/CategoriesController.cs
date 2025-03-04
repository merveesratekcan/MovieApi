using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }
    //Bunu kısa hali mediator ile yapılabilir.bunu sonra yapacağım.daha doğrusu başka entitiylerde yapacağım.
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var value = await _getCategoryQueryHandler.Handle();
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Ok("Kategori ekleme işlemi başarılı");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand (id));
        return Ok("Kategori silme işlemi başarılı");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await _updateCategoryCommandHandler.Handle(command);
        return Ok("Kategori güncelleme işlemi başarılı");
    }
    [HttpGet("GetCategory")]
    public async Task<IActionResult> GetCategory(int id)
    {
       var value = await _getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(id));
        return Ok(value);
    }
}
