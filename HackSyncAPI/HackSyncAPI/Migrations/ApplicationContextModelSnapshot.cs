﻿// <auto-generated />
using System;
using HackSyncAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HackSyncAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HackSyncAPI.Model.DefinationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("Defination_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Tbl_Defination_Master");
                });

            modelBuilder.Entity("HackSyncAPI.Model.MyTeamAllocationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("TeamId");

                    b.HasIndex("userId");

                    b.ToTable("Tbl_MyTeamAllocationModels");
                });

            modelBuilder.Entity("HackSyncAPI.Model.StackModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Stack_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Tbl_Stack_Master");
                });

            modelBuilder.Entity("HackSyncAPI.Model.TeamLeaderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("userId");

                    b.ToTable("Tbl_TeamLeaderModels");
                });

            modelBuilder.Entity("HackSyncAPI.Model.TeamMasterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Defination_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("TeamLeader_Id")
                        .HasColumnType("int");

                    b.Property<string>("Team_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Defination_Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("TeamLeader_Id");

                    b.ToTable("Tbl_TeamMasterModels");
                });

            modelBuilder.Entity("HackSyncAPI.Model.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StackId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("StackId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eaca6ef3-838b-4b79-b082-ccf1af895bad",
                            Email = "jariwaladhruvin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Dhruvin",
                            IsAvailable = true,
                            IsLeader = false,
                            LastName = "Jariwala",
                            LockoutEnabled = false,
                            NormalizedEmail = "JARIWALADHRUVIN@GMAIL.COM",
                            NormalizedUserName = "DHRUVIN",
                            OrganizationId = 5,
                            PasswordHash = "AQAAAAEAACcQAAAAEItMSyy1BXsVbUDalcmLX3cxxz1gr/CZuRM2eBbJGpx8KBYjaYRCru8nGlfN2XaPTQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8af9b59-cc8e-441c-80e3-dbe82f003844",
                            StackId = 3,
                            TwoFactorEnabled = false,
                            UserName = "Dhruvin"
                        },
                        new
                        {
                            Id = "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "13647b1b-c439-4d83-98d1-654f677a277f",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "system",
                            IsAvailable = true,
                            IsLeader = false,
                            LastName = "user",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "SYSTEM",
                            OrganizationId = 5,
                            PasswordHash = "AQAAAAEAACcQAAAAEPoVDHqb1317lcFSUuvo4mwTV2A7jYGHmiexJaTkisy9JgBICF7qEiHdRofRAXmOcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "52315fe9-8526-4c16-8667-2e156c84893a",
                            StackId = 3,
                            TwoFactorEnabled = false,
                            UserName = "system"
                        });
                });

            modelBuilder.Entity("HackSyncAPI.OrganizationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Exist")
                        .HasColumnType("bit");

                    b.Property<string>("Organization_Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Organization_EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization_EventKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_EventName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Organization_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Organization_Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Organization_PhoneNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Organization_TelNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Team_Size")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_On")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Organization_Master");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "094afa8c-69e3-4103-a542-8aee12940f9a",
                            ConcurrencyStamp = "e44c7592-3ec7-4782-b2e4-738785162359",
                            Name = "Organization",
                            NormalizedName = "ORGANIZATION"
                        },
                        new
                        {
                            Id = "9f074bba-372c-474e-81a2-92e877a73075",
                            ConcurrencyStamp = "18705ccc-4764-4d29-ab3c-79339e8b8598",
                            Name = "TeamMate",
                            NormalizedName = "TEAMMATE"
                        },
                        new
                        {
                            Id = "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                            ConcurrencyStamp = "d63c3411-ea62-4ae0-8008-94136ca028c5",
                            Name = "TeamLeader",
                            NormalizedName = "TEAMLEADER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                            RoleId = "24fee6f4-834d-4c45-a3e9-313a175b64b6"
                        },
                        new
                        {
                            UserId = "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                            RoleId = "9f074bba-372c-474e-81a2-92e877a73075"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HackSyncAPI.Model.DefinationModel", b =>
                {
                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationModel");
                });

            modelBuilder.Entity("HackSyncAPI.Model.MyTeamAllocationModel", b =>
                {
                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.TeamMasterModel", "TeamMaster")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("OrganizationModel");

                    b.Navigation("TeamMaster");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HackSyncAPI.Model.StackModel", b =>
                {
                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationModel");
                });

            modelBuilder.Entity("HackSyncAPI.Model.TeamLeaderModel", b =>
                {
                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("OrganizationModel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HackSyncAPI.Model.TeamMasterModel", b =>
                {
                    b.HasOne("HackSyncAPI.Model.DefinationModel", "Defination")
                        .WithMany()
                        .HasForeignKey("Defination_Id");

                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.TeamLeaderModel", "TeamLeader")
                        .WithMany()
                        .HasForeignKey("TeamLeader_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defination");

                    b.Navigation("OrganizationModel");

                    b.Navigation("TeamLeader");
                });

            modelBuilder.Entity("HackSyncAPI.Model.UserModel", b =>
                {
                    b.HasOne("HackSyncAPI.OrganizationModel", "OrganizationModel")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.StackModel", "Stack")
                        .WithMany()
                        .HasForeignKey("StackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationModel");

                    b.Navigation("Stack");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HackSyncAPI.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HackSyncAPI.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackSyncAPI.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HackSyncAPI.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
