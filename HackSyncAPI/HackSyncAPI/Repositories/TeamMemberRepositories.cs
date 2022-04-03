using HackSyncAPI.Contract;
using HackSyncAPI.Contstants;
using HackSyncAPI.Data;
using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ApproveRequestForJoinTeam(int orgId, string userid)
        {
            var res =await context.Tbl_MyTeamAllocationModels.Where(x => x.OrganizationId == orgId && x.userId == userid).FirstOrDefaultAsync();
            res.status =true;
            context.Tbl_MyTeamAllocationModels.Update(res);
            await context.SaveChangesAsync();
            var deletedata= context.Tbl_MyTeamAllocationModels.Where(x => x.status == false && x.userId == userid).ToList();
            context.Tbl_MyTeamAllocationModels.RemoveRange(deletedata);
         
            var user =  await userManager.FindByIdAsync(userid);
            user.IsAvailable = false;
            context.Users.Update(user);
            var result=await context.SaveChangesAsync();

            if (result != null)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> CancelRequestForJoinTeam(int orgId, string userid)
        {
            var res = await context.Tbl_MyTeamAllocationModels.Where(x => x.OrganizationId == orgId && x.userId == userid).FirstOrDefaultAsync();
            res.IsDeleted = true;
            context.Tbl_MyTeamAllocationModels.Update(res);
            var result= context.SaveChanges();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<CustomDataFetchModel>> GetTeamMemberRequest(int orgId, string userId)
        {
            var result = (from mt in context.Tbl_MyTeamAllocationModels.Where(x => x.userId == userId && x.OrganizationId==orgId && x.IsDeleted==false && x.status==false).ToList()
                          join tm in context.Tbl_TeamMasterModels.ToList() on mt.TeamId equals tm.Id
                          join tl in context.Tbl_TeamLeaderModels.ToList() on tm.TeamLeader_Id equals tl.Id
                          join user in context.Users.ToList() on tl.userId equals user.Id
                          select new CustomDataFetchModel
                          {
                              Leader_id=tl.Id,
                              Leader_Name=user.UserName,
                              User_id=user.Id
                          }).ToList();
            return result;
                          

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
                    IsDeleted = false,
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

        public async Task<bool> SendRequestToTeamLeaderForJoinTeam(int TeamLeader_Id, string user_Id, int org_id)
        {
            int Team_id = await context.Tbl_TeamMasterModels.Where(x => x.TeamLeader_Id == TeamLeader_Id).Select(x => x.Id).FirstOrDefaultAsync();

            var myTeamModel = new MyTeamAllocationModel()
            {
                TeamId = Team_id,
                IsDeleted = false,
                userId = user_Id,
                OrganizationId = org_id,
                status = false

            };
            context.Tbl_MyTeamAllocationModels.Add(myTeamModel);
            var res = await context.SaveChangesAsync();
            if (res != null)
            {
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
