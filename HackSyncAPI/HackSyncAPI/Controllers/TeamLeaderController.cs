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
    public class TeamLeaderController : ControllerBase
    {
        private readonly ITeamLeaderRepositories teamLeaderRepositories;

        public TeamLeaderController(ITeamLeaderRepositories teamLeaderRepositories)
        {
            this.teamLeaderRepositories = teamLeaderRepositories;
        }
    }
}
