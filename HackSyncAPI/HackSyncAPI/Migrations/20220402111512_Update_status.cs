using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class Update_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Tbl_TeamLeaderModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Tbl_MyTeamAllocationModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Tbl_TeamLeaderModels");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Tbl_MyTeamAllocationModels");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a",
                column: "ConcurrencyStamp",
                value: "e44c7592-3ec7-4782-b2e4-738785162359");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fee6f4-834d-4c45-a3e9-313a175b64b6",
                column: "ConcurrencyStamp",
                value: "d63c3411-ea62-4ae0-8008-94136ca028c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075",
                column: "ConcurrencyStamp",
                value: "18705ccc-4764-4d29-ab3c-79339e8b8598");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13647b1b-c439-4d83-98d1-654f677a277f", "AQAAAAEAACcQAAAAEPoVDHqb1317lcFSUuvo4mwTV2A7jYGHmiexJaTkisy9JgBICF7qEiHdRofRAXmOcA==", "52315fe9-8526-4c16-8667-2e156c84893a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaca6ef3-838b-4b79-b082-ccf1af895bad", "AQAAAAEAACcQAAAAEItMSyy1BXsVbUDalcmLX3cxxz1gr/CZuRM2eBbJGpx8KBYjaYRCru8nGlfN2XaPTQ==", "f8af9b59-cc8e-441c-80e3-dbe82f003844" });
        }
    }
}
