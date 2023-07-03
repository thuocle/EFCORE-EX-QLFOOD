using EF_EX_QLFOOD.Entities;
using EF_EX_QLFOOD.Helper;
using EF_EX_QLFOOD.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Services
{
    public class MonAnServices : IMonAnServices
    {
        private readonly AppDbContext dbContext;

        public MonAnServices()
        {
            this.dbContext = new AppDbContext();
        }
        public void HienThiCongThucMonAn()
        {
                var query = from MonAn in dbContext.MonAn
                            join CongThuc in dbContext.CongThuc
                                on MonAn.MonAnID equals CongThuc.MonAnID
                            join NguyenLieu in dbContext.NguyenLieu
                                on CongThuc.NguyenLieuID equals NguyenLieu.NguyenLieuID
                            group new { MonAn, CongThuc, NguyenLieu }
                                by new { MonAn.MonAnID, MonAn.TenMonAn }
                                into gMonAn
                            select new
                            {
                                TenMon = gMonAn.Key.TenMonAn,
                                CongThucs = gMonAn.Select(x => new {
                                    NguyenLieu = x.NguyenLieu.TenNguyenLieu,
                                    SoLuong = x.CongThuc.Soluong,
                                    donvitinh = x.CongThuc.DonViTinh
                                })
                            };

                foreach (var item in query)
                {
                    
                    Console.WriteLine($"Món ăn [{item.TenMon}]:");
                    foreach (var ct in item.CongThucs)
                    {
                        Console.WriteLine($"- {ct.NguyenLieu}: {ct.SoLuong} {ct.donvitinh}");
                    }
                }
        }

        private void ThemTrans(MonAn mon)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.MonAn.Add(mon);
                    dbContext.SaveChanges();
                    Console.WriteLine("Nhap so nguyen lieu can lam mon an:");
                    int soNglieu = int.Parse(Console.ReadLine());
                    for (int i = 0; i < soNglieu; i++)
                    {
                        CongThuc ct = new CongThuc(inputType.Them);
                        ct.MonAnID = mon.MonAnID;
                        var ctpos = dbContext.CongThuc.FirstOrDefault(x=> x.NguyenLieuID == ct.NguyenLieuID);
                        if(ctpos == null)
                        {
                            dbContext.CongThuc.Add(ct);
                            dbContext.SaveChanges();
                        }
                        else
                            Console.WriteLine("Cong thuc mon an " + Res.DaTonTai);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    Console.WriteLine(Res.ThatBai);
                }
            }
        }
        public void ThemMonKemCongThuc(MonAn mon)
        {
            if(dbContext.MonAn.Count() == 0)
            {
               ThemTrans(mon);
            }
            else
            {
                var monan = dbContext.MonAn.FirstOrDefault(x => x.MonAnID == mon.MonAnID);
                if(monan == null)
                {
                    ThemTrans(mon);
                }
                else
                    Console.WriteLine("Mon an " + Res.DaTonTai);
            }
        }

        public void TimKiemMonAnTheoNguyenLieu()
        {

            var query = from MonAn in dbContext.MonAn
                        join CongThuc in dbContext.CongThuc
                            on MonAn.MonAnID equals CongThuc.MonAnID
                        join NguyenLieu in dbContext.NguyenLieu
                            on CongThuc.NguyenLieuID equals NguyenLieu.NguyenLieuID
                        where NguyenLieu.TenNguyenLieu.Contains("Hanh") || NguyenLieu.TenNguyenLieu.Contains("Toi")
                        group new { MonAn } by new { MonAn.MonAnID, MonAn.TenMonAn } into g
                        select new
                        {
                            IDMon = g.Key.MonAnID
                        };

            var query2 = from MonAn in dbContext.MonAn
                        join CongThuc in dbContext.CongThuc
                            on MonAn.MonAnID equals CongThuc.MonAnID
                        join NguyenLieu in dbContext.NguyenLieu
                            on CongThuc.NguyenLieuID equals NguyenLieu.NguyenLieuID
                        group new { MonAn, CongThuc, NguyenLieu } by new { MonAn.MonAnID, MonAn.TenMonAn } into g
                        select new
                        {
                            TenMon = g.Key.TenMonAn,
                            CongThucs = g.Select(x => new {
                                NguyenLieu = x.NguyenLieu.TenNguyenLieu,
                                SoLuong = x.CongThuc.Soluong,
                                DonViT = x.CongThuc.DonViTinh
                            })
                        };

            foreach (var item in query2)
            {
                Console.WriteLine($"Món ăn [{item.TenMon}]:");
                foreach (var ct in item.CongThucs)
                {
                    Console.WriteLine($"- {ct.NguyenLieu}: {ct.SoLuong} {ct.DonViT}");
                }
            }

        }
    }
}
