using EduHome.Application.ViewModels.AppUser;

namespace EduHome.Application.Abstraction.Services;

public interface IAuthService
{
    Task<string> Register(AppUserRegisterVM userRegisterVM);
}
