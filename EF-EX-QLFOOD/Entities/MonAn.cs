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
        public string CachLam { get;set; }

        public LoaiMonAn LoaiMonAn { get; set; }
        public IEnumerable<CongThuc> CongThuc { get; set; }

    }
}
