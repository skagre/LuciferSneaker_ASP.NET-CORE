using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Models
{
    public class GioHang
    {
        private readonly CSDL _csdl;
        private GioHang(CSDL csdl)
        {
            _csdl = csdl;
        }

        public string GioHangID { get; set; }
        public List<ChiTietGioHang> ChiTietGioHang { get; set; }


        public static GioHang LayGioHang(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<CSDL>();
            string id = session.GetString("GHid") ?? Guid.NewGuid().ToString();

            session.SetString("GHid", id);

            return new GioHang(context) { GioHangID = id };
        }

        public void ThemGiayVaoGioHang(Giay giay, int soluong)
        {
            var chitietgiohang =
                    _csdl._ChiTietGioHang.SingleOrDefault(
                        s => s.Giay.GiayID == giay.GiayID && s.GioHangID == GioHangID);

            if (chitietgiohang == null)
            {
                chitietgiohang = new ChiTietGioHang
                {
                    GioHangID = GioHangID,
                    Giay = giay,
                    SoLuong = 1
                };

                _csdl._ChiTietGioHang.Add(chitietgiohang);
            }
            else
            {
                chitietgiohang.SoLuong++;
            }
            _csdl.SaveChanges();
        }
        public int XoaGiayKhoiGioHang(Giay giay)
        {
            var chitietgiohang =
                    _csdl._ChiTietGioHang.SingleOrDefault(
                        s => s.Giay.GiayID == giay.GiayID && s.GioHangID == GioHangID);

            var temp = 0;

            if (chitietgiohang != null)
            {
                if (chitietgiohang.SoLuong > 1)
                {
                    chitietgiohang.SoLuong--;
                    temp = chitietgiohang.SoLuong;
                }
                else
                {
                    _csdl._ChiTietGioHang.Remove(chitietgiohang);
                }
            }

            _csdl.SaveChanges();

            return temp;
        }

        public List<ChiTietGioHang> LayChiTietGioHang()
        {
            return ChiTietGioHang ??
                   (ChiTietGioHang =
                       _csdl._ChiTietGioHang.Where(x => x.GioHangID == GioHangID)
                           .Include(s => s.Giay)
                           .ToList());
        }

        public void XoaGioHang()
        {
            var giohang = _csdl
                ._ChiTietGioHang
                .Where(x => x.GioHangID == GioHangID);

            _csdl._ChiTietGioHang.RemoveRange(giohang);

            _csdl.SaveChanges();
        }

        public decimal TinhTongTienGioHang()
        {
            var tong = _csdl._ChiTietGioHang.Where(x => x.GioHangID == GioHangID)
                .Select(c => c.Giay.Gia * c.SoLuong).Sum();
            return tong;
        }
    }
}
