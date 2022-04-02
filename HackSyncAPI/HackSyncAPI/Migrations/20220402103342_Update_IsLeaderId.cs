using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class Update_IsLeaderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLeader",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLeader",
                table: "AspNetUsers");

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
        }
    }
}
