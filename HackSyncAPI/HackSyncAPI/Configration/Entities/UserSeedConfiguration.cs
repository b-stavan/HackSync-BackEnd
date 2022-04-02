using HackSyncAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackSyncAPI.Configration.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            var haser = new PasswordHasher<UserModel>();
            builder.HasData(
                new UserModel
                {
                    Id = "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                    Email = "jariwaladhruvin@gmail.com",
                    NormalizedEmail = "JARIWALADHRUVIN@GMAIL.COM",
                    UserName = "Dhruvin",
                    NormalizedUserName = "DHRUVIN",
                    FirstName = "Dhruvin",
                    LastName = "Jariwala",
                    PasswordHash = haser.HashPassword(null, "Jdhruvin@5042"),
                    EmailConfirmed = true,
                    OrganizationId=5,
                    StackId=3,
                  
                    IsAvailable=true
                    

                },
                 new UserModel
                 {
                     Id = "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                     Email = "user@gmail.com",
                     NormalizedEmail = "USER@GMAIL.COM",
                     UserName = "system",
                     NormalizedUserName = "SYSTEM",
                     FirstName = "system",
                     LastName = "user",
                     PasswordHash = haser.HashPassword(null, "Jdhruvin@5042"),
                     EmailConfirmed = true,
                     OrganizationId=5,
                     StackId = 3,
                     
                     IsAvailable = true
                 }
            );
        }
    }
}
