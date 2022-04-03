using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Contract
{
   public interface ITeamLeaderRepositories : IGenericRepository<TeamLeaderModel>
    {
        Task<SignInResult> LoginTeamLeader(TeamLeaderSigninVM model);

        Task<bool> UserExist(UserModel employee);

        Task<List<UserModel>> GetAvailableMember(int org_id);
        Task<UserModel> SwitchToTeamMember(int TL_id);
        Task<bool> SendRequestToTeamMember(int  TeamLeader_Id,string user_Id, int org_id);
        Task<bool> ApproveTeamMemberRequest(string user_Id, int orgId);
        Task<bool> CancelTeamMemberRequest(int orgId, string user_Id);
        Task<List<MyTeamMemberVM>> GetMyTeamMember(int Org_Id, int Team_Id);
        Task<List<MyTeamAllocationModel>> GetTeamMemberRequest(int orgId);
        Task<List<TeamMateDataWhileRequestVM>> TeamMateDataByid(string userid);

    }
}
