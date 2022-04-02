using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class Update_teamleaderidindeftable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamLeader_Id",
                table: "Tbl_Defination_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a",
                column: "ConcurrencyStamp",
                value: "e6e7f9c8-a0d6-4cd7-af3d-ac7027f7af1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                column: "ConcurrencyStamp",
                value: "1fed9dbe-a434-477e-b909-2caafbb98b8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075",
                column: "ConcurrencyStamp",
                value: "800c563e-d24a-449e-b012-dbfee94a5356");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c41754-e36d-42be-b063-7b0e7f8a48c7", "AQAAAAEAACcQAAAAEItOet+B/wjN5Lm0U+Udwd3TzQO5cI46sOZKApOCq85CKS1tUB2h66Z/FfWyyHDfMg==", "c95b5a97-ea7a-431f-a3fe-ce1636323b91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8e77b77-49e0-455c-8625-2b0b386d8311", "AQAAAAEAACcQAAAAEBN2rPgUKUbvYvZGn5GOsC868vauZPUMxHUnEqF9GXrsDfJul30sYb0ZwQ0yNSwHcw==", "1f513eb2-f985-4cff-b599-f37b016fffe7" });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Defination_Master_TeamLeader_Id",
                table: "Tbl_Defination_Master",
                column: "TeamLeader_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Defination_Master_Tbl_TeamLeaderModels_TeamLeader_Id",
                table: "Tbl_Defination_Master",
                column: "TeamLeader_Id",
                principalTable: "Tbl_TeamLeaderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Defination_Master_Tbl_TeamLeaderModels_TeamLeader_Id",
                table: "Tbl_Defination_Master");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Defination_Master_TeamLeader_Id",
                table: "Tbl_Defination_Master");

            migrationBuilder.DropColumn(
                name: "TeamLeader_Id",
                table: "Tbl_Defination_Master");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a",
                column: "ConcurrencyStamp",
                value: "fda95185-806a-4add-a737-54569989bcd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                column: "ConcurrencyStamp",
                value: "2022b189-cb71-46a7-9091-58ef9ea05d82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075",
                column: "ConcurrencyStamp",
                value: "cec09d84-8715-4939-8cd3-e38e8ef9ec88");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec846784-2561-43bc-b940-6830b180c36e", "AQAAAAEAACcQAAAAEP49ZgQai9ndcWZ3EGxehQbv76eKDuJ+irFy/Yp1O7M8yujJ0Ij7TMIwSjy5kW6KMg==", "365188fc-05a8-420c-b9b6-28ac81e4d7fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6184f2f3-d49d-4529-af2f-0c7d32f79131", "AQAAAAEAACcQAAAAEGZ/YkQKloDq2psUoHgu5ArkEvfW2Yz75SBegCfU5HXxsTOhvoj2Aa3eroHIXSBSqw==", "88825d44-4492-46d8-a2aa-d00878dc04e7" });
        }
    }
}
