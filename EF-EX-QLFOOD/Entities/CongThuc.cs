using EF_EX_QLFOOD.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Entities
{
    public class CongThuc
    {
        public int CongThucID { get; set; }
        public int MonAnID { get; set; }
        public MonAn MonAn { get; set; }
        public int NguyenLieuID { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        /* public IEnumerable<NguyenLieu> NguyenLieu { get; set; }*/
        [Required(ErrorMessage = "Tên So luong không được để trống")]
        public int Soluong { get; set; }
        [Required(ErrorMessage = "Tên Don Vi Tinh không được để trống")]
        public string DonViTinh { get; set; }
        public CongThuc(inputType it)
        {
            if (it == inputType.Them)
            {
                Console.WriteLine("Nhap nguyen lieu:");
                NguyenLieuID = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap So luong:");
                Soluong = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap Don Vi Tinh:");
                DonViTinh = Console.ReadLine();
            }
        }
        public CongThuc()
        {
            
        }
        public void HienThi() 
        {
            
        }
    }
}
