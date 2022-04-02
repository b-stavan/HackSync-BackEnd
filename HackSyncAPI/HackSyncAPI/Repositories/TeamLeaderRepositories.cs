using HackSyncAPI.Contract;
using HackSyncAPI.Data;
using HackSyncAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Repositories
{
    public class TeamLeaderRepositories : GenericRepository<TeamLeaderModel>, ITeamLeaderRepositories
    {
        private readonly ApplicationContext context;

        public TeamLeaderRepositories(ApplicationContext context) : base(context)
        {
            this.context = context;
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

        public Task<TeamLeaderModel> LoginTeamLeader(TeamLeaderModel model)
        {
            throw new NotImplementedException();
        }

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
