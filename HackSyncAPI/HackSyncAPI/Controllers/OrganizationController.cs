using HackSyncAPI.Contract;
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
        public async Task<ActionResult<OrganizationModel>> LoginOrganization(OrganizationModel organizationModel)
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
    }
}
