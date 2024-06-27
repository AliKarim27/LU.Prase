using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LU.Prase.Migrations
{
    /// <inheritdoc />
    public partial class AddingStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EducationalLevel",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supervisor",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "EducationalLevel",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "University",
                table: "AbpUsers");
        }
    }
}
