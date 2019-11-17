using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class TaiKhoan
    {
        [Key]
        public int TaiKhoanID { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }  
    }
}
