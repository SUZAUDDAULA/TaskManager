using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IJwtFactoryService _jwtFactory;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes, IJwtFactoryService jwtFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            _jwtFactory = jwtFactory;
        }

        //api/Account/Login
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            try
            {
                var user = await userInfoes.GetUserInfoByUser(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    var jwt = JsonConvert.SerializeObject(await _jwtFactory.GenerateToken(user.UserName, user.Id, roles));

                    var obj = new ReturnObject
                    {
                        token = jwt.Replace("\"", ""),
                        userInfo = user,
                        role = roles.FirstOrDefault(),
                        //employeeData = employee
                    };

                    //return new OkObjectResult(obj);
                    return Ok(obj);
                }
                else
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Something is wrong" });
            }
            

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(true);
        }

    }
}
