using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.ViewModel
{
    public class TeamLeaderSigninVM
    {
          [Required]
        public string teamleader_email { get; set; }

        [Required]
        public string teamleader_password { get; set; }
    }
}
