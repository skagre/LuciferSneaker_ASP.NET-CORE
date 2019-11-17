using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Repositories
{
    public class RepositoryDonHang : InterfaceDonHang
    {
        private readonly CSDL _csdl;
        private readonly GioHang _gioHang;

        public RepositoryDonHang(CSDL csdl, GioHang gioHang)
        {
            _csdl = csdl;
            _gioHang = gioHang;
        }

        public IEnumerable<DonHang> LayTatCaDonHang()
        {
            return _csdl._DonHang;
        }

        public DonHang LayDonHangTheoID(int id)
        {
            return _csdl._DonHang.Find(id);
        }

        public void TaoDonHang(DonHang donHang)
        {
            donHang.NgayDat = DateTime.Now;

            donHang.TongTien = _gioHang.TinhTongTienGioHang();

            _csdl._DonHang.Add(donHang);

            var chitietgiohang = _gioHang.ChiTietGioHang;

            foreach (var c in chitietgiohang)
            {
                var chitietdonhang = new ChiTietDonHang()
                {
                    SoLuong = c.SoLuong,
                    GiayID = c.Giay.GiayID,
                    DonHangID = donHang.DonHangID,
                    Gia = c.Giay.Gia
                };

                _csdl._ChiTietDonHang.Add(chitietdonhang);
            }

            _csdl.SaveChanges();
        }
    }
}
