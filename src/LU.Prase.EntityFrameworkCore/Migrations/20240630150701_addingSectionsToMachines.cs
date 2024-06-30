using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LU.Prase.Migrations
{
    /// <inheritdoc />
    public partial class addingSectionsToMachines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "Machines",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_SectionId",
                table: "Machines",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Sections_SectionId",
                table: "Machines",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Sections_SectionId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_SectionId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Machines");
        }
    }
}
