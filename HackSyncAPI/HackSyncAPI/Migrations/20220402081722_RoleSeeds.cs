using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class RoleSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "094afa8c-69e3-4103-a542-8aee12940f9a", "e04c8f1d-b56f-4c40-a0b1-9a6507ba253d", "Organization", "ORGANIZATION" },
                    { "9f074bba-372c-474e-81a2-92e877a73075", "3a2174a6-da0d-4a99-af51-74f88b20bb68", "TeamMate", "TEAMMATE" },
                    { "24fee6f4-834d-4c45-a3e9-313a175b64b6", "603415a3-2ce5-4156-839b-e5b984c1ffa3", "TeamLeader", "TEAMLEADER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Defination_Id", "Email", "EmailConfirmed", "FirstName", "IsAvailable", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StackId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5b2546a3-3e7a-454e-ac18-52d4cae97b2f", 0, "885853bb-0320-42d0-a00a-6012ae23e270", null, "jariwaladhruvin@gmail.com", true, "Dhruvin", true, "Jariwala", false, null, "JARIWALADHRUVIN@GMAIL.COM", "DHRUVIN", 5, "AQAAAAEAACcQAAAAEG2zK9t1PZ2X9KcBUH6v8ipytojF5Bg8M1u5ZcZNFwM45EmrwF9FvHEO8J+ZJb8kbg==", null, false, "0f3a1c77-caed-4078-be29-23b6d58405d3", 3, false, "Dhruvin" },
                    { "4b2546a3-3e7a-424e-ac18-52d4cae97b2f", 0, "429bdf20-e9cd-4a91-8387-479f9b111a26", null, "user@gmail.com", true, "system", true, "user", false, null, "USER@GMAIL.COM", "SYSTEM", 5, "AQAAAAEAACcQAAAAEPbDhJT8VmUUlkExBl+O4V59mRFlucG4f9TZGV+9yBsdTFvHnwK89Hc5SEob6oSgZg==", null, false, "0caf837a-e380-48f2-a0c9-22a91aa41b7c", 3, false, "system" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f074bba-372c-474e-81a2-92e877a73075", "4b2546a3-3e7a-424e-ac18-52d4cae97b2f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "24fee6f4-834d-4c45-a3e9-313a175b64b6", "5b2546a3-3e7a-454e-ac18-52d4cae97b2f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f074bba-372c-474e-81a2-92e877a73075", "4b2546a3-3e7a-424e-ac18-52d4cae97b2f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "24fee6f4-834d-4c45-a3e9-313a175b64b6", "5b2546a3-3e7a-454e-ac18-52d4cae97b2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f");
        }
    }
}
