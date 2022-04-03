using HackSyncAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.ViewModel
{
    public class MyTeamMemberVM
    {
        public UserModel usermodel { get; set; }
        public MyTeamAllocationModel teammodel { get; set; }
        public StackModel StackModel { get; set; }
    }
}
