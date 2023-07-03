using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Entities
{
    public class NguyenLieu
    {
        public int NguyenLieuID { get; set; }
        [Required(ErrorMessage = "Tên Nguyen Lieu không được để trống")]
        public string TenNguyenLieu { get; set; }
        public IEnumerable<CongThuc> CongThuc { get; set; }
    }
}
