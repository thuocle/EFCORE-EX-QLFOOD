using EF_EX_QLFOOD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.IServices
{
    public interface IMonAnServices
    {
        void HienThiCongThucMonAn();
        void TimKiemMonAnTheoNguyenLieu();
        void ThemMonKemCongThuc(MonAn mon);
        void ThemMon(MonAn mon);
        void ThemCongThuc(int monID);
    }
}
