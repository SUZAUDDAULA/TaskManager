using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.DAL.Entity;
using TaskManager.DAL.Entity.Master;
using TaskManager.Domain.AuthService.Interfaces;
using TaskManager.Domain.RepositoryService.Interfaces;
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
        private readonly IRepository<Skill> _skillRepo;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes, IJwtFactoryService jwtFactory, IRepository<Skill> skillRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            _jwtFactory = jwtFactory;
            _skillRepo = skillRepo;
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
        public async Task<IActionResult> Register(SignUpViewModel model)
        {
            try
            {
                var user = new ApplicationUser { UserName = model.email, isActive = 1, Email = model.email, firstName = model.personName.firstName, lastName = model.personName.lastName, PhoneNumber = model.mobile, countryId = model.countryId, receiveNewsLetters = model.receiveNewsLetters };
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");

                    var roles = await _userManager.GetRolesAsync(user);
                    var jwt = JsonConvert.SerializeObject(await _jwtFactory.GenerateToken(user.UserName, user.Id, roles));

                    var obj = new ReturnObject
                    {
                        token = jwt.Replace("\"", ""),
                        userInfo = user,
                        role = roles.FirstOrDefault(),
                        //employeeData = employee
                    };

                    foreach (var sk in model.skills)
                    {
                        Skill skill = new Skill
                        {
                            skillName = sk.skillName,
                            skillLevel = sk.skillLevel,
                            userId = sk.userId,
                            ApplicationUser = null
                        };
                        _skillRepo.Insert(skill);
                    }

                    Response.Headers.Add("Access-Control-Expose-Headers", "XSRF-REQUEST-TOKEN");
                    Response.Headers.Add("XSRF-REQUEST-TOKEN", jwt.Replace("\"", ""));

                    return Ok(obj);
                }
                else
                {
                    return BadRequest(new { message = "Invalid Data" });
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Something went wrong" });
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
