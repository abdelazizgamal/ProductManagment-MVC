using CompanySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace CompanySystem.MVC
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM rigVm)
        {

            if (!ModelState.IsValid)
            {
                return View(rigVm);
            }

            var user = new ApplicationUser
            {
                UserName = rigVm.UserName,
                Email = rigVm.Email,
                FirstName = rigVm.FirstName,
                LastName = rigVm.LastName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, rigVm.Password);

            if (!result.Succeeded)
            {
                
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
                return View(rigVm);
            }

            // Add Default Role To User
            IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, SystemRoles.Admin);
            if (!addRoleResult.Succeeded)
            {
                foreach (var errorItem in addRoleResult.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
                return View(rigVm);
            }

            return RedirectToAction(nameof(Login));

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM logVm)
        {
            if (!ModelState.IsValid)
            {
                return View(logVm);
            }

            ApplicationUser? user = await _userManager.FindByEmailAsync(logVm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(logVm);
            }

            var result = await _signInManager.PasswordSignInAsync(user, logVm.Password, logVm.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(logVm);
            }

            // Authentication logic will be implemented here in the future
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}