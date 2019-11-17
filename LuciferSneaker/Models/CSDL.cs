using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class CSDL : DbContext
    {
        public CSDL(DbContextOptions<CSDL> options) : base(options)
        {
        }
        public DbSet<Giay> _Giay { get; set; }
        public DbSet<LoaiGiay> _LoaiGiay { get; set; }
        public DbSet<TaiKhoan> _TaiKhoan { get; set; }
        public DbSet<ChiTietGioHang> _ChiTietGioHang { get; set; }
        public DbSet<DonHang> _DonHang { get; set; }
        public DbSet<ChiTietDonHang> _ChiTietDonHang { get; set; }
    }
}
