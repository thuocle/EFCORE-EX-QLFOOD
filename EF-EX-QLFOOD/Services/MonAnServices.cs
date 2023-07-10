using EF_EX_QLFOOD.Entities;
using EF_EX_QLFOOD.Helper;
using EF_EX_QLFOOD.IServices;

namespace EF_EX_QLFOOD.Services
{
    public class MonAnServices : IMonAnServices
    {
        private readonly AppDbContext dbContext;

        public MonAnServices()
        {
            this.dbContext = new AppDbContext();
        }
        #region Private Method
        private LoaiMonAn isLoaiMon(int loaiID)
        {
            return dbContext.LoaiMonAn.FirstOrDefault(x => x.LoaiMonAnID == loaiID);
        }
        private MonAn isMon(int monID)
        {
            return dbContext.MonAn.FirstOrDefault(x => x.MonAnID == monID);
        }
        private NguyenLieu isNguyenLieu(int nglieuID)
        {
            return dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == nglieuID);
        }
        private bool CongThucDaTonTai(CongThuc ct)
        {
            return dbContext.CongThuc.Any(x=>x.MonAnID==ct.MonAnID && x.NguyenLieuID == ct.NguyenLieuID);

        }
        #endregion
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
                            CongThucs = gMonAn.Select(x => new
                            {
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

        public void TimKiemMonAnTheoNguyenLieu()
        {
            var query2 = from MonAn in dbContext.MonAn
                         join CongThuc in dbContext.CongThuc
                             on MonAn.MonAnID equals CongThuc.MonAnID
                         join NguyenLieu in dbContext.NguyenLieu
                             on CongThuc.NguyenLieuID equals NguyenLieu.NguyenLieuID
                         where CongThuc.NguyenLieu.TenNguyenLieu.Contains("Hanh")
                         group new { MonAn, CongThuc, NguyenLieu } by new { MonAn.MonAnID, MonAn.TenMonAn } into g
                         select new
                         {
                             TenMon = g.Key.TenMonAn,
                             CongThucs = g.Select(x => new
                             {
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

        public void ThemMon(MonAn mon)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (isLoaiMon == null)
                    {
                        Console.WriteLine("Loai mon an " + Res.ChuaTonTai);
                        return;
                    }
                    dbContext.Add(mon);
                    dbContext.SaveChanges();
                    Console.WriteLine(Res.ThanhCong);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void ThemCongThuc(int monID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var mon = isMon(monID);
                    if (mon == null)
                    {
                        Console.WriteLine("Mon an" + Res.ChuaTonTai);
                        return;
                    }
                    Console.WriteLine("Nhap so nguyen lieu cho cong thuc mon an!");
                    int num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++)
                    {
                        CongThuc congThuc = new CongThuc(inputType.Them);
                        var nglieu = isNguyenLieu(congThuc.NguyenLieuID);
                        if (nglieu == null)
                        {
                            Console.WriteLine("Nguyen lieu " + Res.ChuaTonTai);
                            return;
                        }
                        if (CongThucDaTonTai(congThuc))
                        {
                            Console.WriteLine("Nguyen lieu cong thuc mon an nay: " + Res.DaTonTai);
                            return;
                        }
                        congThuc.MonAnID = mon.MonAnID;
                        dbContext.Add(congThuc);
                        dbContext.SaveChanges();
                        mon.CachLam = mon.CachLam + $"{nglieu.TenNguyenLieu}: {congThuc.Soluong} {congThuc.DonViTinh} \n";
                        dbContext.MonAn.Update(mon);
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ThanhCong);
                    }
                    // Commit transaction
                    trans.Commit();
                }
                catch (Exception)
                {
                    // Nếu có lỗi xảy ra, rollback transaction và ném ra ngoại lệ
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void ThemMonKemCongThuc(MonAn mon)
        {
            throw new NotImplementedException();
        }
    }
}
