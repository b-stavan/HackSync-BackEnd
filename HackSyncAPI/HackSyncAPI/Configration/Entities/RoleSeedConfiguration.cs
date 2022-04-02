using HackSyncAPI.Contstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Configration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "094afa8c-69e3-4103-a542-8aee12940f9a",
                    Name = Roles.Organization,
                    NormalizedName = Roles.Organization.ToUpper()
                },
                new IdentityRole
                {
                    Id = "9f074bba-372c-474e-81a2-92e877a73075",
                    Name = Roles.TeamMate,
                    NormalizedName = Roles.TeamMate.ToUpper()
                },
                 new IdentityRole
                 {
                     Id = "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                     Name = Roles.TeamLeader,
                     NormalizedName = Roles.TeamLeader.ToUpper()
                 }
            );
        }
    }
}
