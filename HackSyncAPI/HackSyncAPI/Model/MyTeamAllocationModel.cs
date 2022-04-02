using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Model
{
    public class MyTeamAllocationModel:BaseEntity
    {
        [ForeignKey("TeamId")]
        public TeamMasterModel TeamMaster { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("OrganizationId")]
        public OrganizationModel OrganizationModel { get; set; }
        public int OrganizationId { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public UserModel User { get; set; }

        public bool status { get; set; }
    }
}
