using EF_EX_QLFOOD.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Entities
{
    public class MonAn
    {
        public int MonAnID { get; set; }
        [Required(ErrorMessage = "Tên món ăn không được để trống")]
        public string TenMonAn { get; set; }
        public string GhiChu { get; set; }
        public int LoaiMonAnID { get; set; }
        public string ? CachLam { get;set; }

        public LoaiMonAn LoaiMonAn { get; set; }
        public IEnumerable<CongThuc> CongThuc { get; set; }
        public MonAn(inputType it)
        {
                if(it == inputType.Them)
            {
                Console.WriteLine("Nhap ten mon:");
                TenMonAn = Console.ReadLine();
                Console.WriteLine("Nhap ghi chu:");
                GhiChu = Console.ReadLine();
                Console.WriteLine("Loai mon ID:");
                LoaiMonAnID = int.Parse(Console.ReadLine());
            }
        }
        public MonAn()
        {
            
        }

    }
}
