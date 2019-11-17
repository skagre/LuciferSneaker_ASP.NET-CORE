using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class ChiTietGioHang
    {
        [Key]
        public int ChiTietGioHangID { get; set; }

        public int SoLuong { get; set; }

        public virtual Giay Giay { get; set; }

        public virtual GioHang GioHang { get; set; }

        public string GioHangID { get; set; }
    }
}
