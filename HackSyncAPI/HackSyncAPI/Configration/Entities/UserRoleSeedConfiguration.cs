using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Configration.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
              new IdentityUserRole<string>
              {
                  RoleId = "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                  UserId = "5b2546a3-3e7a-454e-ac18-52d4cae97b2f"
              },
               new IdentityUserRole<string>
               {
                   RoleId = "9f074bba-372c-474e-81a2-92e877a73075",
                   UserId = "4b2546a3-3e7a-424e-ac18-52d4cae97b2f"
               }
            );
        }
    }
}
