using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Model
{
    public class TeamLeaderModel:BaseEntity
    {
        public string userId { get; set; }
        [ForeignKey("userId")]
        public UserModel User { get; set; }
        [ForeignKey("OrganizationId")]
        public OrganizationModel OrganizationModel { get; set; }
        public int OrganizationId { get; set; }

        public bool status { get; set; }
    }
}
