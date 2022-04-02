using HackSyncAPI.Contract;
using HackSyncAPI.Contstants;
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
    public class OrganizationRepositories : GenericRepository<OrganizationModel>, IOrganizationRepositories
    {
        private readonly ApplicationContext context;
        private readonly UserManager<UserModel> userManager;

        public OrganizationRepositories(ApplicationContext context, UserManager<UserModel> userManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            /*  UserManager = userManager;*/
        }

        public async Task<bool> ApproveRequest(int TL_id)
        {

            TeamLeaderModel model = context.Tbl_TeamLeaderModels.Where(x => x.Id == TL_id).Include(x=> x.User).FirstOrDefault();
            model.status = true;
            model.User.IsLeader = true;
            context.Tbl_TeamLeaderModels.Update(model);
            var user = await userManager.FindByEmailAsync(model.User.Email);
            await userManager.RemoveFromRoleAsync(user, Roles.TeamMate);
            await userManager.AddToRoleAsync(user, Roles.TeamLeader);
            var res=await context.SaveChangesAsync();
            if (res != null)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> CancelRequestForTeamLeader(int TL_id)
        {
            TeamLeaderModel model = context.Tbl_TeamLeaderModels.Where(x => x.Id == TL_id).Include(x => x.User).FirstOrDefault();
            model.IsDeleted=true;
            DefinationModel DefModel = context.Tbl_Defination_Master.Where(x => x.TeamLeader_Id == TL_id).FirstOrDefault();
            DefModel.IsDeleted = true;
            TeamMasterModel TeamModel = context.Tbl_TeamMasterModels.Where(x => x.TeamLeader_Id == TL_id).FirstOrDefault();
            TeamModel.IsDeleted = true;
            var res = await context.SaveChangesAsync();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<TeamLeaderModel>> FetchAllRequest()
        {
            var result = await context.Tbl_TeamLeaderModels.Where(x => x.status == false && x.IsDeleted == false).Include(x=> x.User).ToListAsync();
            return result;
        }

        public async Task<List<StackModel>> GetAllStack(int orgid)
        {
            var allstack = await context.Tbl_Stack_Master.Where(x=> x.OrganizationId==orgid).ToListAsync();
            return allstack;
        }

        public async Task<List<UserModel>> GetAllTeamLeader(int orgid)
        {
            var teamleader = await context.Tbl_TeamLeaderModels.Where(x=> x.IsDeleted==false && x.OrganizationId==orgid).Join(context.Users,tl=> tl.userId,tm=> tm.Id ,(tl,tm)=> new UserModel{ 
              Id=tm.Id,
              UserName=tm.UserName,
              FirstName=tm.FirstName,
              LastName=tm.LastName,
              Email=tm.Email,
              OrganizationId=tm.OrganizationId,
              PhoneNumber=tm.PhoneNumber,
              StackId=tm.StackId
              

            }).ToListAsync();
            return teamleader;
        }

        public async Task<List<UserModel>> GetAllTeamMember(int orgid)
        {
            var teammember = await context.Users.Where(x=> x.OrganizationId==orgid && x.IsLeader==false).ToListAsync();
            return teammember;
        }

        public async Task<MultipleVM> GetUserDataDefinationStack(int TeamLeaderId)
        {
            var data = (from leader in context.Tbl_TeamLeaderModels.ToList()
                        join
 user in context.Users.ToList() on leader.userId equals user.Id
                        join def in context.Tbl_Defination_Master.ToList() on leader.Id equals def.TeamLeader_Id
                        join team in context.Tbl_TeamMasterModels.ToList() on leader.Id equals team.TeamLeader_Id
                        join stack in context.Tbl_Stack_Master.ToList() on leader.User.StackId equals stack.Id
                        select new MultipleVM()
                        {
                            User = user,
                            DefinationModel = def,
                            TeamLeaderModel = leader,
                            StackModel = stack
                        }).Where(x => x.TeamLeaderModel.Id == TeamLeaderId).FirstOrDefault();
            return data;
        }

        /*   public UserManager<OrganizationModel> UserManager { get; }*/

        public async Task<bool> IsOrg_Exist(string email)
        {
            var result = context.Tbl_Organization_Master.Any(x => x.Organization_Email == email);
            if(result)
            {
                return true;
            }
            return false;
        }

        public async Task<OrganizationModel> LoginOrg(SignUpOrganizationVM model)
        {
            model.Organization_Password = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.Organization_Password));
            var res = await context.Tbl_Organization_Master.Where(a => a.Organization_Email == model.Organization_Email && a.Organization_Password == model.Organization_Password).FirstOrDefaultAsync();
            return res;
        }

        public Task<OrganizationModel> RegisterOrg(OrganizationModel model)
        {
            model.Organization_Password = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.Organization_Password));
            //var organizationModel = new OrganizationModel()
            //{
            //    Organization_Name=model.Organization_Name,
            //    Organization_Email=model.Organization_Email,
            //    Organization_EventName=model.Organization_EventName,
            //    Organization_EventDate=model.Organization_EventDate,
            //    Organization_EventKey=model.Organization_EventKey,
            //    Organization_PhoneNo=model.Organization_PhoneNo,
            //    Organization_TelNo=model.Organization_TelNo,
            //    Team_Size=model.Team_Size,
            //    Is_Exist=true

            //};

            var result = AddAsync(model);
            return result;
        }
    }
}
