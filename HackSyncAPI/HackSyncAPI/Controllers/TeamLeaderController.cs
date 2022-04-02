using HackSyncAPI.Contract;
using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
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
    public class TeamLeaderController : ControllerBase
    {
        private readonly ITeamLeaderRepositories teamLeaderRepositories;

        public TeamLeaderController(ITeamLeaderRepositories teamLeaderRepositories)
        {
            this.teamLeaderRepositories = teamLeaderRepositories;
        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserModel>> logintl(TeamLeaderSigninVM userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await teamLeaderRepositories.LoginTeamLeader(userModel);
                if (result != null)
                {
                    return Ok("team leader login successfully...");
                }
            }

            return BadRequest("User Not Found");
        }
    }
}
