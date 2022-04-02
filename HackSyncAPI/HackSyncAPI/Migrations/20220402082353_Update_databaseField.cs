using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class Update_databaseField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Defination_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Defination_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Defination_Id",
                table: "Tbl_TeamMasterModels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a",
                column: "ConcurrencyStamp",
                value: "8068a4a1-80e6-4d36-aded-d2a28e700d6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                column: "ConcurrencyStamp",
                value: "d356de46-ff02-4a4a-973d-923d4f11c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075",
                column: "ConcurrencyStamp",
                value: "df0cada7-2960-4a32-a11d-dbae4dc5ef1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52cc9c7d-7b9a-4f4b-aba6-501cbcffe255", "AQAAAAEAACcQAAAAEP8/C+8oT/GQjjRZlHmZ454CzYbI3ijbvwrRP2GsUvqdjS3z6haT3JnrOzEFmRFwCQ==", "956c742f-648b-4237-afd0-29483e9bbc8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9bb71c-30db-4b87-a0b0-bd8e66914579", "AQAAAAEAACcQAAAAEKYaohz/geUEiSty/0Ldor5/7Ox6cZAIRLAU84jRvyQ4nSnZLnkdCrtm0hlvtk8GmQ==", "22e418d7-bfba-45b5-8296-4870280ac7bf" });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TeamMasterModels_Defination_Id",
                table: "Tbl_TeamMasterModels",
                column: "Defination_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_TeamMasterModels_Tbl_Defination_Master_Defination_Id",
                table: "Tbl_TeamMasterModels",
                column: "Defination_Id",
                principalTable: "Tbl_Defination_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_TeamMasterModels_Tbl_Defination_Master_Defination_Id",
                table: "Tbl_TeamMasterModels");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_TeamMasterModels_Defination_Id",
                table: "Tbl_TeamMasterModels");

            migrationBuilder.DropColumn(
                name: "Defination_Id",
                table: "Tbl_TeamMasterModels");

            migrationBuilder.AddColumn<int>(
                name: "Defination_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a",
                column: "ConcurrencyStamp",
                value: "e04c8f1d-b56f-4c40-a0b1-9a6507ba253d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                column: "ConcurrencyStamp",
                value: "603415a3-2ce5-4156-839b-e5b984c1ffa3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075",
                column: "ConcurrencyStamp",
                value: "3a2174a6-da0d-4a99-af51-74f88b20bb68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "429bdf20-e9cd-4a91-8387-479f9b111a26", "AQAAAAEAACcQAAAAEPbDhJT8VmUUlkExBl+O4V59mRFlucG4f9TZGV+9yBsdTFvHnwK89Hc5SEob6oSgZg==", "0caf837a-e380-48f2-a0c9-22a91aa41b7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "885853bb-0320-42d0-a00a-6012ae23e270", "AQAAAAEAACcQAAAAEG2zK9t1PZ2X9KcBUH6v8ipytojF5Bg8M1u5ZcZNFwM45EmrwF9FvHEO8J+ZJb8kbg==", "0f3a1c77-caed-4078-be29-23b6d58405d3" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Defination_Id",
                table: "AspNetUsers",
                column: "Defination_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers",
                column: "Defination_Id",
                principalTable: "Tbl_Defination_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
