using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.ProjectService.interfaces;

namespace TaskManager.Web.Api
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ClientLocationsController : ControllerBase
    {
        private readonly IProjectService _pojectService;

        public ClientLocationsController(IProjectService pojectService)
        {
            _pojectService = pojectService;
        }

        //api/ClientLocations/GetClientLocation
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetClientLocation()
        {
            var result = await _pojectService.GetClientLocationList();
            return Ok(result);
        }
    }
}
