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
    public class TeamLeaderRepositories : GenericRepository<TeamLeaderModel>, ITeamLeaderRepositories
    {
        private readonly ApplicationContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public TeamLeaderRepositories(ApplicationContext context, UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> LoginTeamLeader(TeamLeaderSigninVM model)
        {
            var user = await userManager.FindByEmailAsync(model.teamleader_email);

            if (await userManager.IsInRoleAsync(user, Roles.TeamLeader))
            {
                return await signInManager.PasswordSignInAsync(user, model.teamleader_password, false, false);
            }
            return null;
        }

        public Task<bool> ApproveTeamMemberRequest(int TeamLeader_Id, string user_Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAvailableMember(int org_id)
        {
                var result = await context.Users.Where(x => x.OrganizationId == org_id && x.IsLeader == false && x.IsAvailable==true).ToListAsync();
                return result; 
        }

        public Task<UserModel> GetMyTeamMember(int Team_Id)
        {
            throw new NotImplementedException();
        }

 

        public async Task<bool> SendRequestToTeamMember(int TeamLeader_Id, string user_Id,int org_id)
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
            var res=await context.SaveChangesAsync();
            if(res!=null)
            {
                return true;
            }
            return false;
        }

        public async Task<UserModel> SwitchToTeamMember(int TL_id)
        {
            var user_id = context.Tbl_TeamLeaderModels.Where(x=> x.Id==TL_id).Select(x => x.userId).FirstOrDefault();
            var user = await userManager.FindByIdAsync(user_id);
            if (user != null)
            {
                await userManager.RemoveFromRoleAsync(user, Roles.TeamLeader);
                await userManager.AddToRoleAsync(user, Roles.TeamMate);
                await context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<bool> UserExist(UserModel employee)
        {
            var userExist = await userManager.FindByEmailAsync(employee.Email);

            if (userExist != null)
            {
                return true;
            }

            return false;
        }
    }
}
