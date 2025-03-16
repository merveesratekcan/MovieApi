using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CarsHandler;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public  async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        //CancellationToken şu işe yarıyor. Eğer bir işlemi iptal etmek isterseniz, CancellationToken nesnesini kullanabilirsiniz.
        //Örneğin, bir işlemi başlattınız ve bu işlem birkaç saniye sürdü. Bu işlemi iptal etmek isterseniz, CancellationToken nesnesini kullanabilirsiniz.
        //Bu nesne, işlemi iptal etmek için kullanılır. Bu nesne, CancellationTokenSource nesnesi ile birlikte kullanılır.

        _context.Casts.Add(new Cast
         {
             Biography = request.Biography,
             ImageUrl = request.ImageUrl,
             Name = request.Name,
             Overview = request.Overview,
             SurName = request.SurName,
             Title = request.Title

         });
        await _context.SaveChangesAsync();
    }
}
