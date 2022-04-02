using HackSyncAPI.Contract;
using HackSyncAPI.Data;
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

        public OrganizationRepositories(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> IsOrg_Exist(string email)
        {
            var result = context.Tbl_Organization_Master.Any(x => x.Organization_Email == email);
            if(result)
            {
                return true;
            }
            return false;
        }

        public async Task<OrganizationModel> LoginOrg(OrganizationModel model)
        {
            model.Organization_Password = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.Organization_Password));
            var res = await context.Tbl_Organization_Master.Where(a => a.Organization_Email == model.Organization_Email && a.Organization_Password == model.Organization_Password).FirstOrDefaultAsync();
            return res;
        }

        public Task<OrganizationModel> RegisterOrg(OrganizationModel model)
        {
            model.Organization_Password = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.Organization_Password));
            var result = AddAsync(model);
            return result;
        }
    }
}
