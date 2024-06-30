using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LU.Prase.Migrations
{
    /// <inheritdoc />
    public partial class addingmultipleUsersDepartement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Departements_DepartementId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Sections_SectionId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_DepartementId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_SectionId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "AbpUsers");

            migrationBuilder.CreateTable(
                name: "DepartementUser",
                columns: table => new
                {
                    DepartementsId = table.Column<long>(type: "bigint", nullable: false),
                    ResponsiblesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartementUser", x => new { x.DepartementsId, x.ResponsiblesId });
                    table.ForeignKey(
                        name: "FK_DepartementUser_AbpUsers_ResponsiblesId",
                        column: x => x.ResponsiblesId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartementUser_Departements_DepartementsId",
                        column: x => x.DepartementsId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionUser",
                columns: table => new
                {
                    ResponsiblesId = table.Column<long>(type: "bigint", nullable: false),
                    SectionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionUser", x => new { x.ResponsiblesId, x.SectionsId });
                    table.ForeignKey(
                        name: "FK_SectionUser_AbpUsers_ResponsiblesId",
                        column: x => x.ResponsiblesId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionUser_Sections_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartementUser_ResponsiblesId",
                table: "DepartementUser",
                column: "ResponsiblesId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionUser_SectionsId",
                table: "SectionUser",
                column: "SectionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartementUser");

            migrationBuilder.DropTable(
                name: "SectionUser");

            migrationBuilder.AddColumn<long>(
                name: "DepartementId",
                table: "AbpUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "AbpUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DepartementId",
                table: "AbpUsers",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_SectionId",
                table: "AbpUsers",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Departements_DepartementId",
                table: "AbpUsers",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Sections_SectionId",
                table: "AbpUsers",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }
    }
}
