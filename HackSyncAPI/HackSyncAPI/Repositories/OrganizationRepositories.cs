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

        public OrganizationRepositories(ApplicationContext context
            ) : base(context)
        {
            this.context = context;
          /*  UserManager = userManager;*/
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
