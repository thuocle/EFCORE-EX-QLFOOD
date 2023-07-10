﻿// <auto-generated />
using EF_EX_QLFOOD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_EX_QLFOOD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.CongThuc", b =>
                {
                    b.Property<int>("CongThucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CongThucID"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonAnID")
                        .HasColumnType("int");

                    b.Property<int>("NguyenLieuID")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.HasKey("CongThucID");

                    b.HasIndex("MonAnID");

                    b.HasIndex("NguyenLieuID");

                    b.ToTable("CongThuc");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.LoaiMonAn", b =>
                {
                    b.Property<int>("LoaiMonAnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiMonAnID"));

                    b.Property<string>("TenLoaiMonAn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiMonAnID");

                    b.ToTable("LoaiMonAn");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.MonAn", b =>
                {
                    b.Property<int>("MonAnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonAnID"));

                    b.Property<string>("CachLam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiMonAnID")
                        .HasColumnType("int");

                    b.Property<string>("TenMonAn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonAnID");

                    b.HasIndex("LoaiMonAnID");

                    b.ToTable("MonAn");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.NguyenLieu", b =>
                {
                    b.Property<int>("NguyenLieuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguyenLieuID"));

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguyenLieuID");

                    b.ToTable("NguyenLieu");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.CongThuc", b =>
                {
                    b.HasOne("EF_EX_QLFOOD.Entities.MonAn", "MonAn")
                        .WithMany("CongThuc")
                        .HasForeignKey("MonAnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_EX_QLFOOD.Entities.NguyenLieu", "NguyenLieu")
                        .WithMany("CongThuc")
                        .HasForeignKey("NguyenLieuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonAn");

                    b.Navigation("NguyenLieu");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.MonAn", b =>
                {
                    b.HasOne("EF_EX_QLFOOD.Entities.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAnList")
                        .HasForeignKey("LoaiMonAnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiMonAn");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.LoaiMonAn", b =>
                {
                    b.Navigation("MonAnList");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.MonAn", b =>
                {
                    b.Navigation("CongThuc");
                });

            modelBuilder.Entity("EF_EX_QLFOOD.Entities.NguyenLieu", b =>
                {
                    b.Navigation("CongThuc");
                });
#pragma warning restore 612, 618
        }
    }
}
