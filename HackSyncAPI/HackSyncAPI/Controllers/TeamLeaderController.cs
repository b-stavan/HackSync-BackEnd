using HackSyncAPI.Contract;
using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public TeamLeaderController(ITeamLeaderRepositories teamLeaderRepositories, UserManager<UserModel> userManager,
                              SignInManager<UserModel> signInManager)
        {
            this.teamLeaderRepositories = teamLeaderRepositories;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> LoginTeamLeader(UserModel TLModel)
        {
           
                var res = await teamLeaderRepositories.LoginTeamLeader(TLModel);
                if (res != null)
                {
                    return Ok("Team Leader Login Successfully...");
                }


            return NotFound("User Not Found");
        }
       
        }
   
}
