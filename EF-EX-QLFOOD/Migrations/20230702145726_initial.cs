using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX_QLFOOD.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiMonAn",
                columns: table => new
                {
                    LoaiMonAnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiMonAn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMonAn", x => x.LoaiMonAnID);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieu",
                columns: table => new
                {
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguyenLieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenLieu", x => x.NguyenLieuID);
                });

            migrationBuilder.CreateTable(
                name: "MonAn",
                columns: table => new
                {
                    MonAnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiMonAnID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAn", x => x.MonAnID);
                    table.ForeignKey(
                        name: "FK_MonAn_LoaiMonAn_LoaiMonAnID",
                        column: x => x.LoaiMonAnID,
                        principalTable: "LoaiMonAn",
                        principalColumn: "LoaiMonAnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongThuc",
                columns: table => new
                {
                    CongThucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonAnID = table.Column<int>(type: "int", nullable: false),
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThuc", x => x.CongThucID);
                    table.ForeignKey(
                        name: "FK_CongThuc_MonAn_MonAnID",
                        column: x => x.MonAnID,
                        principalTable: "MonAn",
                        principalColumn: "MonAnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongThuc_NguyenLieu_NguyenLieuID",
                        column: x => x.NguyenLieuID,
                        principalTable: "NguyenLieu",
                        principalColumn: "NguyenLieuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MonAnID",
                table: "CongThuc",
                column: "MonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_NguyenLieuID",
                table: "CongThuc",
                column: "NguyenLieuID");

            migrationBuilder.CreateIndex(
                name: "IX_MonAn_LoaiMonAnID",
                table: "MonAn",
                column: "LoaiMonAnID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongThuc");

            migrationBuilder.DropTable(
                name: "MonAn");

            migrationBuilder.DropTable(
                name: "NguyenLieu");

            migrationBuilder.DropTable(
                name: "LoaiMonAn");
        }
    }
}
