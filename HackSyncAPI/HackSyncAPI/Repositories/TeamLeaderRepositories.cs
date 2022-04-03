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



        public async Task<List<UserModel>> GetAvailableMember(int org_id)
        {
                var result = await context.Users.Where(x => x.OrganizationId == org_id && x.IsLeader == false && x.IsAvailable==true).ToListAsync();
                return result; 
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

        public async Task<List<MyTeamAllocationModel>> GetTeamMemberRequest(int orgId)
        {
            var res =await context.Tbl_MyTeamAllocationModels.Where(x=>x.OrganizationId == orgId&&x.status==false && x.IsDeleted==false).Include(x => x.User).ToListAsync();
            return res;
        }

        public async Task<bool> CancelTeamMemberRequest(string user_Id, int orgId)
        {
            var res = await context.Tbl_MyTeamAllocationModels.Where(x => x.OrganizationId == orgId && x.userId == user_Id).FirstOrDefaultAsync();
            res.IsDeleted = true;
            context.Tbl_MyTeamAllocationModels.Update(res);
            var result = context.SaveChanges();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ApproveTeamMemberRequest(string user_Id, int orgId)
        {
            var res = await context.Tbl_MyTeamAllocationModels.Where(x => x.OrganizationId == orgId && x.userId == user_Id).FirstOrDefaultAsync();
            res.status = true;
            context.Tbl_MyTeamAllocationModels.Update(res);
            var user = await userManager.FindByIdAsync(user_Id);
            user.IsAvailable = false;
            context.Users.Update(user);
            var result = await context.SaveChangesAsync();

            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CancelTeamMemberRequest(int orgId, string user_Id)
        {
            var res = await context.Tbl_MyTeamAllocationModels.Where(x => x.OrganizationId == orgId && x.userId == user_Id).FirstOrDefaultAsync();
            res.IsDeleted = true;
            context.Tbl_MyTeamAllocationModels.Update(res);
            var result = context.SaveChanges();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<MyTeamMemberVM>> GetMyTeamMember(int Org_Id, int Team_Id)
        {
            var result = await context.Tbl_MyTeamAllocationModels.Where(x => x.TeamId == Team_Id && x.status == true && x.IsDeleted == false && x.OrganizationId == Org_Id).Join(context.Users, team => team.userId, user => user.Id, (team, user) => new {
                user,
                team
            }).Join(context.Tbl_Stack_Master, users => users.user.StackId, stack => stack.Id, (users, stack) => new MyTeamMemberVM
            {
                usermodel = users.user,
                teammodel = users.team,
                StackModel = stack

            }).ToListAsync();

            return result;
        }

        public async Task<List<TeamMateDataWhileRequestVM>> TeamMateDataByid(string userid)
        {
            var result = (from def in context.Tbl_Defination_Master.ToList() 
                          join tl in context.Tbl_TeamLeaderModels.ToList() on 
                          def.TeamLeader_Id equals tl.Id
                          join user in context.Users.Where(x=> x.Id==userid).ToList() on
                          tl.userId equals user.Id
                          join stack in context.Tbl_Stack_Master.ToList() on
                          user.StackId equals stack.Id
                          select new TeamMateDataWhileRequestVM
                          {
                              User_id=user.Id,
                              User_Name=user.UserName,
                              Stack_Name=stack.Stack_Name,
                              Problem_Defination=def.Defination_Name
                          }).ToList();
            return result;
        }
    }
}
