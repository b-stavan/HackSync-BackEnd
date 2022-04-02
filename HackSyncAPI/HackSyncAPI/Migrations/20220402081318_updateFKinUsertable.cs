using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class updateFKinUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Defination_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers",
                column: "Defination_Id",
                principalTable: "Tbl_Defination_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Defination_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Defination_Master_Defination_Id",
                table: "AspNetUsers",
                column: "Defination_Id",
                principalTable: "Tbl_Defination_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
