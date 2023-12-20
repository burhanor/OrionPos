using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrionPos.Dto.UserDto;
using OrionPos.Entity.Entities;

namespace OrionPos.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly INotyfService notifyService;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, INotyfService notifyService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.notifyService = notifyService;
        }
        [HttpGet]
        [Route("giris-yap")]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
                return RedirectToAction("TelephoneDirectory", "Directory");
            return View();
        }

        [HttpPost]
        [Route("giris-yap")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {


            AppUser appUser = await userManager.FindByNameAsync(dto.UserName);
            if (appUser is null)
                appUser = await userManager.FindByEmailAsync(dto.UserName);
            var result = await  signInManager.PasswordSignInAsync(appUser??new(), dto.Password,dto.RememberMe,false);
            if (result.Succeeded)// Giris basariliysa
                return RedirectToAction("TelephoneDirectory", "Directory");
            else
            {
                notifyService.Error("Kullanıcı Adı ve/veya şifre hatalı.");
            }
            return View();

        }

    }
}
