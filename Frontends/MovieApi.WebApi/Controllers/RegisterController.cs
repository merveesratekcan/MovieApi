using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserRegisterDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers;

public class RegisterController : Controller
{

    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(CreateUserRegisterDto createUserRegisterDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createUserRegisterDto);
        StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        var response=await client.PostAsync("https://localhost:7288/api/Registers", stringContent);
        if(response.IsSuccessStatusCode)
        {
            return RedirectToAction("SingIn", "Login");
        }
        ViewBag.ErrorMessage = "Registration failed. Please try again.";

        return View();
    }
}
