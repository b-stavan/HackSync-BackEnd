using HackSyncAPI.Contract;
using HackSyncAPI.Data;
using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackSyncAPI.Repositories
{
    public class TeamLeaderRepositories : GenericRepository<TeamLeaderModel>, ITeamLeaderRepositories
    {
        private readonly ApplicationContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public TeamLeaderRepositories(ApplicationContext context, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
        
        public async Task<SignInResult> LoginTeamLeader(UserModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var result = await signInManager.PasswordSignInAsync(user, model.PasswordHash, false, false);
            return result;
            
            //model.PasswordHash = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.PasswordHash));
            //var res = await context.Users.Where(a => a.Email == model.Email && a.PasswordHash == model.PasswordHash).FirstOrDefaultAsync();
            //return  res;

        }
       //public async Task<TeamLeaderModel> Registration(UserModel model)
       // {
       //     //model.PasswordHash = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.PasswordHash));
       //     //var result = AddAsync(model);
       //     //return result;
       // }
        //public async Task<TeamLeaderModel> RegisterMember(UserModel model)
        //{
        //    //var register = new UserModel()
        //    //{
        //    //    FirstName = model.FirstName,
        //    //    LastName = model.LastName,
        //    //    Email = model.Email,
        //    //    UserName = model.Email,
        //    //    PhoneNumber = model.PhoneNumber,
        //    //    StackId = model.StackId,
        //    //    OrganizationId = model.OrganizationId,
        //    //    Defination_Id = model.Defination_Id

        //    //};
        //    //return await userManager.CreateAsync(register, model.PasswordHash);
        //    model.PasswordHash = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.PasswordHash));
        //    var result = AddAsync(model);
        //    return result;

        //}
        public Task<bool> SendRequestToTeamMember(int TeamLeader_Id, string user_Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> SwitchToTeamMember(string User_Id)
        {
            throw new NotImplementedException();
        }
    }
}
