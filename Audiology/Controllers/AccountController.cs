using System;
using System.Collections.Generic;
using System.Security.Claims;
using Audiology.Domain;
using Audiology.Domain.DTO;
using Audiology.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Audiology.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto
                {
                    Email = userViewModel.Email,
                    Password = userViewModel.Password
                };
                var result = _accountService.IsValidUser(userDto);
                if (result > 0)
                {
                    GenerateClaims(userDto.Email);
                    return RedirectToAction(nameof(EstimationController.EstimationScreen), "Estimation", new { userType = result });
                }
            }
            return View(userViewModel);
        }

        private void GenerateClaims(string email)
        {
            var userClaims = new List<Claim>()
             {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Email, email),
                         };

            var userPrincipal = new ClaimsPrincipal(new[] { new ClaimsIdentity(userClaims, "User Identity") });
            HttpContext.SignInAsync(userPrincipal);
        }
    }
}
