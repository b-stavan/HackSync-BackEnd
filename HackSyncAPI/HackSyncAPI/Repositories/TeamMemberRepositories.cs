using HackSyncAPI.Contract;
using HackSyncAPI.Contstants;
using HackSyncAPI.Data;
using HackSyncAPI.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Repositories
{
    public class TeamMemberRepositories : GenericRepository<UserModel>, ITeamMemberRepositories
    {
        private readonly ApplicationContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public TeamMemberRepositories(ApplicationContext context, UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> LogTeamMate(UserModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            return await signInManager.PasswordSignInAsync(user, model.PasswordHash, false, false);
        }

        public async Task<IdentityResult> RegisterTeamMate(UserModel model)
        {
            var user = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                OrganizationId = model.OrganizationId,
                StackId=model.StackId,
                IsAvailable=true,
            };

            var result = await userManager.CreateAsync(user, model.PasswordHash);

            if (result.Succeeded == true)
            {
                await userManager.AddToRoleAsync(user, Roles.TeamMate);
            }
            return result;
        }

        public async Task<bool> SendRequestForTeamLeader(string uid, string teamname, string problemdefination, int orgId)
        {
            var TeamLeader = new TeamLeaderModel()
            {
                userId = uid,
                OrganizationId = orgId,
                status = false

            };
            await context.Tbl_TeamLeaderModels.AddAsync(TeamLeader);
            await context.SaveChangesAsync();
            int TeamLeaderid = context.Tbl_TeamLeaderModels.Where(x => x.userId == uid).Select(x => x.Id).FirstOrDefault();
            var definationdata = new DefinationModel()
            {
                Defination_Name = problemdefination,
                IsDeleted = false,
                OrganizationId=orgId,
                TeamLeader_Id=TeamLeaderid
            };
            await context.Tbl_Defination_Master.AddAsync(definationdata);
            await context.SaveChangesAsync();
           
            int Defid = context.Tbl_Defination_Master.Where(x => x.TeamLeader_Id==TeamLeaderid).Select(x => x.Id).FirstOrDefault();
            if (TeamLeaderid != 0)
            {
                var teamMaster = new TeamMasterModel()
                {

                    OrganizationId = orgId,
                    Team_Name = teamname,
                    TeamLeader_Id = TeamLeaderid,
                    IsDeleted = true,
                    Defination_Id=Defid
                };
                await context.Tbl_TeamMasterModels.AddAsync(teamMaster);
                await context.SaveChangesAsync();
               /* var myteam = new MyTeam_Allocation()
                {

                    userId = uid,
                    OrganizationId = orgId,
                    TeamId = TeamLeaderid,
                    Status = false
                };
                await context.Tbl_Team_Allocation_Master.AddAsync(myteam);
                await context.SaveChangesAsync();*/
                return true;
            }
            return false;
        }

        public async Task<bool> UserExist(UserModel user)
        {
            var userExist = await userManager.FindByEmailAsync(user.Email);

            if (userExist != null)
            {
                return true;
            }

            return false;
        }
    }
}
