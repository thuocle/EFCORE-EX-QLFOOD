using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX_QLFOOD.Entities
{
    public class LoaiMonAn
    {
        public int LoaiMonAnID { get; set; }
        [Required(ErrorMessage = "Tên loại món ăn không được để trống")]
        public string TenLoaiMonAn { get; set; }
        public IEnumerable<MonAn> MonAnList { get; set; }
    }
}
