using EF_EX_QLFOOD.Entities;
using EF_EX_QLFOOD.IServices;
using EF_EX_QLFOOD.Services;

void Main()
{
    IMonAnServices monAnServices = new MonAnServices();
    /* MonAn mon1 = new MonAn() { TenMonAn = "Bun bo", GhiChu ="ngon", LoaiMonAnID= 2};
     monAnServices.ThemMonKemCongThuc(mon1);*/
    monAnServices.HienThiCongThucMonAn();
    monAnServices.TimKiemMonAnTheoNguyenLieu();
}
Main();