using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Contract
{
    public interface IOrganizationRepositories : IGenericRepository<OrganizationModel>
    {
        Task<OrganizationModel> RegisterOrg(OrganizationModel model);

        Task<OrganizationModel> LoginOrg(OrganizationModel model);
        Task<bool> IsOrg_Exist(string email);
    }
}
