using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.DAL.Entity;
using TaskManager.Domain.AuthService.Interfaces;
using TaskManager.Web.Models;

namespace TaskManager.Web.Api
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserInfoes userInfoes;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
        }

        //api/Account/Login
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var user = await userInfoes.GetUserInfoByUser(model.UserName);
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(new {message ="Username or password is incorrect" });
            }

        }

    }
}
