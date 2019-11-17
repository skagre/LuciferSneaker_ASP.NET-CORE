using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class DonHang
    {
        [Key]
        public int DonHangID { get; set; }

        public List<ChiTietDonHang> ChiTietDonHang { get; set; }

        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public decimal TongTien { get; set; }

        public DateTime NgayDat { get; set; }
    }
}
