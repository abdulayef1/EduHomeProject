using EduHome.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.UI.Controllers;

public class AuthController : Controller
{
    Microsoft.AspNetCore.Identity.SignInManager<AppUser> signInManager;
    public IActionResult Index()
    {
        return View();
    }
}
