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
        public async Task<ActionResult<UserModel>> Login_TeamLeader([FromBody] TeamLeaderSigninVM userModel)
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
        [HttpGet("Availablemember/{org_id}")]
        public async Task<ActionResult<List<UserModel>>> Availablemember(int org_id)
        {
            var result = await teamLeaderRepositories.GetAvailableMember(org_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Available member not found");
        }
        [HttpPut("switchroletoTM/{TL_id}")]
        public async Task<ActionResult<bool>> switchroletoTeamMate(int TL_id)
        {
            var result = await teamLeaderRepositories.SwitchToTeamMember(TL_id);
            if (result != null)
            {
                return Ok("You successfully become the Team Member");
            }
            return Conflict("Error in changing the role...");
        }

            [HttpPost("SendRequestTeamMateToJoin")]
            public async Task<ActionResult<bool>> SendRequestTeamMateToJoin(int TL_id, string userId, int org_id)
            {
                var result = await teamLeaderRepositories.SendRequestToTeamMember(TL_id, userId, org_id);
                if (result != null)
                {
                    return Ok($"Request successfully send to {userId}");
                }
                return Conflict("Error in sending the request.");
            }

        [HttpGet("GetTeamMemberRequest")]
        public async Task<ActionResult> GetTeamMemberRequest(int orgId)
        {
            var result = await teamLeaderRepositories.GetTeamMemberRequest(orgId);
            if (result.Count != 0)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");

        }

        [HttpPut("ApproveRequestForTeamMate")]
        public async Task<ActionResult<bool>> ApproveRequestForTeamMate(string userid,int orgId)
        {
            var result = await teamLeaderRepositories.ApproveTeamMemberRequest(userid, orgId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }
        [HttpPut("CancelRequest")]
        public async Task<ActionResult<bool>> CancelRequest(int orgId, string userid)
        {
            var result = await teamLeaderRepositories.CancelTeamMemberRequest(orgId, userid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }



        [HttpGet("GetMyTeam")]
        public async Task<ActionResult> GetMyTeam(int orgId,int team_id)
        {
            var result = await teamLeaderRepositories.GetMyTeamMember(orgId,team_id);
            if (result!=null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");

        }
        [HttpGet("getmemberdatarequest/{uid}")]
        public async Task<ActionResult<List<TeamMateDataWhileRequestVM>>> GetMemberDataRequest(string uid)
        {
            var result = await teamLeaderRepositories.TeamMateDataByid(uid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }
    }
    }

