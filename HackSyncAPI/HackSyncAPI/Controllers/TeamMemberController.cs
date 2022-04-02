using HackSyncAPI.Contract;
using HackSyncAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost("sendrequesttoadmin")]
        public async Task<ActionResult> sendrequesttoadmin(string uid, string teamname, string problemdefination, int orgId)
        {
            var result = await teamMemberRepositories.SendRequestForTeamLeader(uid, teamname, problemdefination, orgId);

            if (!result)
            {
                //return NotFound(HttpContext.Response.WriteAsync("User Not Found")) ;
                return Conflict("Error in sending request...");
            }
            return Ok("Request Send to Admin...");

        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<IdentityResult>> EditProfile(string id, UserModel User)
        {
            //if (id != User.Id)
            //{
            //    return BadRequest();
            //}

           //try
            //{
                var edited = await teamMemberRepositories.EditMember(id, User);
                return Ok(edited);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (await teamMemberRepositories.UserExist(User))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            
        }
    }
}
