using HackSyncAPI.Model;
using HackSyncAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Contract
{
   public interface ITeamMemberRepositories : IGenericRepository<UserModel>
    {
        Task<IdentityResult> RegisterTeamMate(UserModel model);
        Task<SignInResult> LogTeamMate(UserModel model);
        Task<bool> UserExist(UserModel employee);
        Task<bool> SendRequestForTeamLeader(string uid, string teamname, string problemdefination, int orgId);
        Task<List<CustomDataFetchModel>> GetTeamMemberRequest(int orgId,string userid);
        Task<bool> ApproveRequestForJoinTeam(int orgId,string userid);
        Task<bool> CancelRequestForJoinTeam(int orgId,string userid);
        Task<bool> SendRequestToTeamLeaderForJoinTeam(int TeamLeader_Id, string user_Id, int org_id);

    }
}
