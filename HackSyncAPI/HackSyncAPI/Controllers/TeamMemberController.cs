using HackSyncAPI.Contract;
using HackSyncAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberRepositories teamMemberRepositories;

        public TeamMemberController(ITeamMemberRepositories teamMemberRepositories)
        {
            this.teamMemberRepositories = teamMemberRepositories;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserModel>> RegisterTeamMember(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var res = await teamMemberRepositories.UserExist(userModel);


                if (res == true)
                {
                    return Conflict("User Already exist");
                }
                else
                {
                    await teamMemberRepositories.RegisterTeamMate(userModel);
                }
            }

            return Ok(HttpContext.Response.StatusCode = 200);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignInTeamMate(UserModel model)
        {
            var result = await teamMemberRepositories.LogTeamMate(model);

            if (!result.Succeeded)
            {
                //return NotFound(HttpContext.Response.WriteAsync("User Not Found")) ;
                return NotFound("User not found");
            }
            return Ok("Login Successfully");

        }
    }
}
