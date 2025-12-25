using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.UserRegisterCommads;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.UserRegisterHandlers;

public class CreateUserRegisterCommadHandler
{
    private readonly MovieContext _movieContext;
    private readonly UserManager<AppUser> _userManager;

    public CreateUserRegisterCommadHandler(MovieContext movieContext, UserManager<AppUser> userManager)
    {
        _movieContext = movieContext;
        _userManager = userManager;
    }

    public async Task Handle(CreateUserRegisterCommad commad)
    {
        var user = new AppUser()
        {
            Name = commad.Name,
            Surname = commad.Surname,
            UserName = commad.Username,
            Email = commad.Email
        };
        await _userManager.CreateAsync(user, commad.Password);

    }
}

