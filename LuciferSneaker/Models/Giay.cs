using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class Giay
    {
        [Key]
        public int GiayID { get; set; }
        public string TenGiay { get; set; }
        public string Style { get; set; }
        public string MauSac { get; set; }
        public decimal Gia { get; set; }
        public bool TrangThai { get; set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }

        public int LoaiGiayID { get; set; }
        public virtual LoaiGiay LoaiGiay { get; set; }
    }
}
