using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Updated_On { get; set; }

        public bool IsDeleted { get; set; }
    }
}
