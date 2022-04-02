using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Model
{
    public class TeamMasterModel:BaseEntity
    {
        public string Team_Name { get; set; }
        [ForeignKey("TeamLeader_Id")]
        public TeamLeaderModel TeamLeader { get; set; }
        public int TeamLeader_Id { get; set; }
        [ForeignKey("OrganizationId")]
        public OrganizationModel OrganizationModel { get; set; }
        public int OrganizationId { get; set; }
    }
}
