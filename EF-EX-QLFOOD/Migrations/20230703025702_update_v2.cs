using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX_QLFOOD.Migrations
{
    /// <inheritdoc />
    public partial class update_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguyenLieu_CongThuc_CongThucID",
                table: "NguyenLieu");

            migrationBuilder.DropIndex(
                name: "IX_NguyenLieu_CongThucID",
                table: "NguyenLieu");

            migrationBuilder.DropColumn(
                name: "CongThucID",
                table: "NguyenLieu");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_NguyenLieuID",
                table: "CongThuc",
                column: "NguyenLieuID");

            migrationBuilder.AddForeignKey(
                name: "FK_CongThuc_NguyenLieu_NguyenLieuID",
                table: "CongThuc",
                column: "NguyenLieuID",
                principalTable: "NguyenLieu",
                principalColumn: "NguyenLieuID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongThuc_NguyenLieu_NguyenLieuID",
                table: "CongThuc");

            migrationBuilder.DropIndex(
                name: "IX_CongThuc_NguyenLieuID",
                table: "CongThuc");

            migrationBuilder.AddColumn<int>(
                name: "CongThucID",
                table: "NguyenLieu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguyenLieu_CongThucID",
                table: "NguyenLieu",
                column: "CongThucID");

            migrationBuilder.AddForeignKey(
                name: "FK_NguyenLieu_CongThuc_CongThucID",
                table: "NguyenLieu",
                column: "CongThucID",
                principalTable: "CongThuc",
                principalColumn: "CongThucID");
        }
    }
}
