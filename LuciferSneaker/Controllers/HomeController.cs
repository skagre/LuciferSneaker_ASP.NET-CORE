using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using LuciferSneaker.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuciferSneaker.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly InterfaceGiay _interfaceGiay;
        private readonly InterfaceLoaiGiay _interfaceLoaiGiay;
        private readonly GioHang _gioHang;
        private readonly InterfaceDonHang _interfaceDonHang;

        public HomeController(InterfaceGiay interfaceGiay, InterfaceLoaiGiay interfaceLoaiGiay, GioHang gioHang, InterfaceDonHang interfaceDonHang)
        {
            _interfaceGiay = interfaceGiay;
            _interfaceLoaiGiay = interfaceLoaiGiay;
            _gioHang = gioHang;
            _interfaceDonHang = interfaceDonHang;
        }
        public IActionResult Index()
        {
            Giay_LoaiGiayViewModel x = new Giay_LoaiGiayViewModel();
            x._Giay = _interfaceGiay.LayTatCaGiay();
            x._LoaiGiay = _interfaceLoaiGiay.LayTatCaLoaiGiay();
            return View(x);
        }
        public IActionResult ChiTietGiay(int id)
        {
            return View(_interfaceGiay.LayGiayTheoID(id));
        }
        public IActionResult GioHang()
        {
            var items = _gioHang.LayChiTietGioHang();
            _gioHang.ChiTietGioHang = items;

            var x = new GioHangViewModel
            {
                GioHang = _gioHang,
                TongTienGioHang = _gioHang.TinhTongTienGioHang()
            };
            return View(x);
        }
        public IActionResult ThemGiayVaoGioHang(int id)
        {
            var x = _interfaceGiay.LayTatCaGiay().FirstOrDefault(p => p.GiayID == id);
            if (x != null)
            {
                _gioHang.ThemGiayVaoGioHang(x, 1);
            }
            return RedirectToAction("GioHang");
        }
        public IActionResult XoaGiayKhoiGioHang(int id)
        {
            var x = _interfaceGiay.LayTatCaGiay().FirstOrDefault(p => p.GiayID == id);
            if (x != null)
            {
                _gioHang.XoaGiayKhoiGioHang(x);
            }
            return RedirectToAction("GioHang");
        }
        public IActionResult XoaGioHang(int id)
        {
            _gioHang.XoaGioHang();
            return RedirectToAction("GioHang");
        }
        public IActionResult DatHang()
        {
            var items = _gioHang.LayChiTietGioHang();
            _gioHang.ChiTietGioHang = items;

            var x = new GioHangViewModel
            {
                GioHang = _gioHang,
                TongTienGioHang = _gioHang.TinhTongTienGioHang()
            };
            return View(x);
        }
        [HttpPost]
        public IActionResult ThanhToan(DonHang donHang)
        {
            var x = _gioHang.LayChiTietGioHang();
            _gioHang.ChiTietGioHang = x;

            _interfaceDonHang.TaoDonHang(donHang);
            _gioHang.XoaGioHang();
            return View("DatHangThanhCong");
        }
    }
}