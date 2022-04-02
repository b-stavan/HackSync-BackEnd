using HackSyncAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.ViewModel
{
    public class MultipleVM
    {
        public UserModel User { get; set; }
        public DefinationModel DefinationModel { get; set; }
        public StackModel StackModel { get; set; }
        public TeamLeaderModel TeamLeaderModel { get; set; }
    }
}
