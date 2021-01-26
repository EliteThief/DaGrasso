using DaGrasso.Data.Models;
using DaGrasso.Data.Repositories;
using DaGrasso.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrinkAndGo.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("sigup")]
        public IActionResult Signup() => View();

        
        [Route("sigup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid) 
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
               if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors) 
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return RedirectToAction("Login", "Account");
                }
                ModelState.Clear();   
            }
            return View();
        }
        [Route("login")]
        public IActionResult Login()
        {
          
            return  View();

        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if(ModelState.IsValid)
            {
                var result=  await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(signInModel);

        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}