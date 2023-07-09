using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX_QLFOOD.Migrations
{
    /// <inheritdoc />
    public partial class update_v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CachLam",
                table: "MonAn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CachLam",
                table: "MonAn");
        }
    }
}
