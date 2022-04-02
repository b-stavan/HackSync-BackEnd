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
     
        Task<SignInResult> LoginTeamLeader(UserModel model);
        Task<UserModel> GetAvailableMember(int org_id);
        Task<UserModel> SwitchToTeamMember(string User_Id);
        Task<bool> SendRequestToTeamMember(int  TeamLeader_Id,string user_Id);
        Task<bool> ApproveTeamMemberRequest(int  TeamLeader_Id,string user_Id);
        Task<UserModel> GetMyTeamMember(int  Team_Id);

    }
}
