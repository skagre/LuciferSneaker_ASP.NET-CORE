using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LuciferSneaker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_DonHang",
                columns: table => new
                {
                    DonHangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    TongTien = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DonHang", x => x.DonHangID);
                });

            migrationBuilder.CreateTable(
                name: "_LoaiGiay",
                columns: table => new
                {
                    LoaiGiayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoaiGiay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiGiay", x => x.LoaiGiayID);
                });

            migrationBuilder.CreateTable(
                name: "_TaiKhoan",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatKhau = table.Column<string>(nullable: true),
                    TenTaiKhoan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaiKhoan", x => x.TaiKhoanID);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    GioHangID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.GioHangID);
                });

            migrationBuilder.CreateTable(
                name: "_Giay",
                columns: table => new
                {
                    GiayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anh = table.Column<string>(nullable: true),
                    Gia = table.Column<decimal>(nullable: false),
                    LoaiGiayID = table.Column<int>(nullable: false),
                    MauSac = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    TenGiay = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Giay", x => x.GiayID);
                    table.ForeignKey(
                        name: "FK__Giay__LoaiGiay_LoaiGiayID",
                        column: x => x.LoaiGiayID,
                        principalTable: "_LoaiGiay",
                        principalColumn: "LoaiGiayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_ChiTietDonHang",
                columns: table => new
                {
                    ChiTietDonHangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonHangID = table.Column<int>(nullable: false),
                    Gia = table.Column<decimal>(nullable: false),
                    GiayID = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietDonHang", x => x.ChiTietDonHangID);
                    table.ForeignKey(
                        name: "FK__ChiTietDonHang__DonHang_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "_DonHang",
                        principalColumn: "DonHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ChiTietDonHang__Giay_GiayID",
                        column: x => x.GiayID,
                        principalTable: "_Giay",
                        principalColumn: "GiayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_ChiTietGioHang",
                columns: table => new
                {
                    ChiTietGioHangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GiayID = table.Column<int>(nullable: true),
                    GioHangID = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietGioHang", x => x.ChiTietGioHangID);
                    table.ForeignKey(
                        name: "FK__ChiTietGioHang__Giay_GiayID",
                        column: x => x.GiayID,
                        principalTable: "_Giay",
                        principalColumn: "GiayID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ChiTietGioHang_GioHang_GioHangID",
                        column: x => x.GioHangID,
                        principalTable: "GioHang",
                        principalColumn: "GioHangID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX__ChiTietDonHang_DonHangID",
                table: "_ChiTietDonHang",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX__ChiTietDonHang_GiayID",
                table: "_ChiTietDonHang",
                column: "GiayID");

            migrationBuilder.CreateIndex(
                name: "IX__ChiTietGioHang_GiayID",
                table: "_ChiTietGioHang",
                column: "GiayID");

            migrationBuilder.CreateIndex(
                name: "IX__ChiTietGioHang_GioHangID",
                table: "_ChiTietGioHang",
                column: "GioHangID");

            migrationBuilder.CreateIndex(
                name: "IX__Giay_LoaiGiayID",
                table: "_Giay",
                column: "LoaiGiayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "_ChiTietGioHang");

            migrationBuilder.DropTable(
                name: "_TaiKhoan");

            migrationBuilder.DropTable(
                name: "_DonHang");

            migrationBuilder.DropTable(
                name: "_Giay");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "_LoaiGiay");
        }
    }
}
