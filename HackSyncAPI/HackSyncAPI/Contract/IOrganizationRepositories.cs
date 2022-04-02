using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Contract
{
    public interface IOrganizationRepositories : IGenericRepository<OrganizationModel>
    {
        Task<OrganizationModel> RegisterOrg(OrganizationModel model);

        Task<OrganizationModel> LoginOrg(SignUpOrganizationVM model);
        Task<bool> IsOrg_Exist(string email);

        Task<List<UserModel>> GetAllTeamMember(int orgid);
        Task<List<UserModel>> GetAllTeamLeader(int orgid);

        Task<List<StackModel>> GetAllStack(int orgid);

        Task<List<TeamLeaderModel>> FetchAllRequest();

        Task<bool> ApproveRequest(int TL_id);

        Task<MultipleVM> GetUserDataDefinationStack(int TeamLeaderId);
    }
}
