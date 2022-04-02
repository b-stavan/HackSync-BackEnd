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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepositories organizationRepositories;

        public OrganizationController(IOrganizationRepositories organizationRepositories)
        {
            this.organizationRepositories = organizationRepositories;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<OrganizationModel>> RegisterOrg(OrganizationModel organizationModel)
        {
            if (ModelState.IsValid)
            {
                var res = await organizationRepositories.IsOrg_Exist(organizationModel.Organization_Email);


                if (res == true)
                {
                    return Conflict("User Already exist");
                }
                else
                {
                    await organizationRepositories.RegisterOrg(organizationModel);
                }
            }

            return Ok("Registration Successfully");
        }
        [HttpPost("login")]
        public async Task<ActionResult<OrganizationModel>> LoginOrganization(SignUpOrganizationVM organizationModel)
        {
            if (ModelState.IsValid)
            {
                var res = await organizationRepositories.LoginOrg(organizationModel);
                if (res != null)
                {
                    return Ok(res);
                }

            }
            return NotFound("User Not Found");
        }

        [HttpGet("getallteammember/{orgid}")]
        public async Task<ActionResult<List<UserModel>>> GetAllMember(int orgid)
        {
            var result = await organizationRepositories.GetAllTeamMember(orgid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Team Member are not exists");
        }
        [HttpGet("getallteamleader/{orgid}")]
        public async Task<ActionResult<List<UserModel>>> GetAllLeader(int orgid)
        {
            var result = await organizationRepositories.GetAllTeamLeader(orgid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Team Leader are not exists");
        }


        [HttpGet("getallstack/{orgid}")]
        public async Task<ActionResult<List<StackModel>>> GetAllStack(int orgid)
        {
            var result = await organizationRepositories.GetAllStack(orgid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Stack are not exists");
        }

        [HttpGet("getbyteamleadrequest/{TeamLeaderId}")]
        public async Task<ActionResult<MultipleVM>> Getbyteamleadrequest(int TeamLeaderId)
        {
            var result = await organizationRepositories.GetUserDataDefinationStack(TeamLeaderId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }

        [HttpGet("getpendingrequest")]
        public async Task<ActionResult<MultipleVM>> getallpendingrequest()
        {
            var result = await organizationRepositories.FetchAllRequest();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }

        [HttpPut("ApproveRequest")]
        public async Task<ActionResult<MultipleVM>> ApproveRequest(int Leader_Id)
        {
            var result = await organizationRepositories.ApproveRequest(Leader_Id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not Found");
        }
    }
}
