using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<CongThuc> CongThuc { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = THUOCLE\\THUOCLE; Database = QuanLyFOOD; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}
