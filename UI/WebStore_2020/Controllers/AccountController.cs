using System.Threading.Tasks;
using Common.WebStore.DomainNew.Entities;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Вход невозможен");
                return View(model);
            }

            if (Url.IsLocalUrl(model.ReturnUrl)) //если returnUrl - локальный
            {
                return Redirect(model.ReturnUrl); //перенаправляем туда, откуда пришли
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var user = new User { UserName = model.UserName, Email = model.Email };
            var createResult = await _userManager.CreateAsync(user, model.Password);

            if (!createResult.Succeeded)
            {
                foreach (var identityError in createResult.Errors)//выводим ошибки
                {
                    ModelState.AddModelError("", identityError.Description);
                    return View(model);
                }
            }

            await _signInManager.SignInAsync(user, false);
            await _userManager.AddToRoleAsync(user, "Users"); // добавление пользователя к группе Users
            return RedirectToAction("Index", "Home");
        }

    }
}
