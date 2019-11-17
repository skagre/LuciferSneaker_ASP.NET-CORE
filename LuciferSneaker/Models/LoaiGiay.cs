using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class LoaiGiay
    {
        [Key]
        public int LoaiGiayID { get; set; }
        public string TenLoaiGiay { get; set; }
    }
}
