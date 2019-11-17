using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int ChiTietDonHangID { get; set; }
        public int DonHangID { get; set; }
        public int GiayID { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public virtual Giay Giay { get; set; }
        public virtual DonHang DonHang { get; set; }
    }
}
