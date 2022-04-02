using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Model
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("OrganizationId")]
        public OrganizationModel OrganizationModel { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey("StackId")]
        public StackModel Stack { get; set; }
        public int StackId { get; set; }

        //[ForeignKey("Defination_Id")]
        //public DefinationModel Defination { get; set; }
        //public int? Defination_Id { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsLeader { get; set; }
   }
}
