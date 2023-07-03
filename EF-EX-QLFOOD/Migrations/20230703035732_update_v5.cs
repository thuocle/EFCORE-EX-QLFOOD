using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX_QLFOOD.Migrations
{
    /// <inheritdoc />
    public partial class update_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongThucNguyenLieu");

            migrationBuilder.DropIndex(
                name: "IX_CongThuc_MonAnID",
                table: "CongThuc");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MonAnID",
                table: "CongThuc",
                column: "MonAnID");

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
                name: "IX_CongThuc_MonAnID",
                table: "CongThuc");

            migrationBuilder.DropIndex(
                name: "IX_CongThuc_NguyenLieuID",
                table: "CongThuc");

            migrationBuilder.CreateTable(
                name: "CongThucNguyenLieu",
                columns: table => new
                {
                    CongThucID = table.Column<int>(type: "int", nullable: false),
                    NguyenLieusNguyenLieuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThucNguyenLieu", x => new { x.CongThucID, x.NguyenLieusNguyenLieuID });
                    table.ForeignKey(
                        name: "FK_CongThucNguyenLieu_CongThuc_CongThucID",
                        column: x => x.CongThucID,
                        principalTable: "CongThuc",
                        principalColumn: "CongThucID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongThucNguyenLieu_NguyenLieu_NguyenLieusNguyenLieuID",
                        column: x => x.NguyenLieusNguyenLieuID,
                        principalTable: "NguyenLieu",
                        principalColumn: "NguyenLieuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MonAnID",
                table: "CongThuc",
                column: "MonAnID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CongThucNguyenLieu_NguyenLieusNguyenLieuID",
                table: "CongThucNguyenLieu",
                column: "NguyenLieusNguyenLieuID");
        }
    }
}
