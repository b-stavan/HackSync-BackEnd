using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.ViewModel
{
    public class SignUpOrganizationVM
    {

        [Required]
        public string Organization_Email { get; set; }

        [Required]
        public string Organization_Password { get; set; }
    }
}
