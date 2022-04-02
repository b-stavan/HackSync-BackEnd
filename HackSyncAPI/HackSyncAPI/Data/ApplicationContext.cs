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

        public DbSet<OrganizationModel> Tbl_Organization_Master { get; set; }
        public DbSet<StackModel> Tbl_Stack_Master { get; set; }
        public DbSet<DefinationModel> Tbl_Defination_Master { get; set; }
    }
}
