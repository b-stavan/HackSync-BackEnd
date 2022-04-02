using HackSyncAPI.Contract;
using HackSyncAPI.Contstants;
using HackSyncAPI.Data;
using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
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

        public Task<UserModel> GetAvailableMember(int org_id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetMyTeamMember(int Team_Id)
        {
            throw new NotImplementedException();
        }

 

        public Task<bool> SendRequestToTeamMember(int TeamLeader_Id, string user_Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> SwitchToTeamMember(string User_Id)
        {
            throw new NotImplementedException();
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
