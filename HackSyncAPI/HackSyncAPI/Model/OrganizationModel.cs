using HackSyncAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI
{
    public class OrganizationModel:BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Organization_Name { get; set; }
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Organization_Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Organization_Password { get; set; }

        [Required]
        [StringLength(255)]

        public string Organization_EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]

        public DateTime Organization_EventDate { get; set; }


        public string Organization_EventKey { get; set; }


        [Required]
        [StringLength(11)]
        public string Organization_PhoneNo { get; set; }

        [Required]
        [StringLength(11)]
        public string Organization_TelNo { get; set; }
  
        [Required]
        public int Team_Size { get; set; }

        public bool Is_Exist { get; set; }
    }
}
