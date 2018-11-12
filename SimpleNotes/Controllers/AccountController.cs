using SimpleNotes.Models;
using SimpleNotes.Providers.Interface;
using System.Web.Mvc;

namespace SimpleNotes.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (_authProvider.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {

            if (ModelState.IsValid && _authProvider.Login(model))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                return View(model);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            if (_authProvider.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegModel model)
        {
            if (ModelState.IsValid)
                if (_authProvider.Register(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View(model);
                }
            else
            {
                ModelState.AddModelError("", "Ошибка при регистрации");
                return View(model);
            }
        }
        public ActionResult Logoff()
        {
            _authProvider.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}