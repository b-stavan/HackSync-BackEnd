using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackSyncAPI.Migrations
{
    public partial class Genrate_All_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_TeamLeaderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TeamLeaderModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_TeamLeaderModels_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_TeamLeaderModels_Tbl_Organization_Master_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Tbl_Organization_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TeamMasterModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLeader_Id = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TeamMasterModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_TeamMasterModels_Tbl_Organization_Master_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Tbl_Organization_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_TeamMasterModels_Tbl_TeamLeaderModels_TeamLeader_Id",
                        column: x => x.TeamLeader_Id,
                        principalTable: "Tbl_TeamLeaderModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MyTeamAllocationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MyTeamAllocationModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_MyTeamAllocationModels_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_MyTeamAllocationModels_Tbl_Organization_Master_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Tbl_Organization_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_MyTeamAllocationModels_Tbl_TeamMasterModels_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Tbl_TeamMasterModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MyTeamAllocationModels_OrganizationId",
                table: "Tbl_MyTeamAllocationModels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MyTeamAllocationModels_TeamId",
                table: "Tbl_MyTeamAllocationModels",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MyTeamAllocationModels_userId",
                table: "Tbl_MyTeamAllocationModels",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TeamLeaderModels_OrganizationId",
                table: "Tbl_TeamLeaderModels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TeamLeaderModels_userId",
                table: "Tbl_TeamLeaderModels",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TeamMasterModels_OrganizationId",
                table: "Tbl_TeamMasterModels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TeamMasterModels_TeamLeader_Id",
                table: "Tbl_TeamMasterModels",
                column: "TeamLeader_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_MyTeamAllocationModels");

            migrationBuilder.DropTable(
                name: "Tbl_TeamMasterModels");

            migrationBuilder.DropTable(
                name: "Tbl_TeamLeaderModels");
        }
    }
}
