using HackSyncAPI.Configration.Entities;
using HackSyncAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Data
{
    public class ApplicationContext : IdentityDbContext<UserModel>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        public DbSet<OrganizationModel> Tbl_Organization_Master { get; set; }
        public DbSet<StackModel> Tbl_Stack_Master { get; set; }
        public DbSet<DefinationModel> Tbl_Defination_Master { get; set; }
        public DbSet<TeamLeaderModel> Tbl_TeamLeaderModels { get; set; }
        public DbSet<TeamMasterModel> Tbl_TeamMasterModels { get; set; }
        public DbSet<MyTeamAllocationModel> Tbl_MyTeamAllocationModels { get; set; }
    }
}
