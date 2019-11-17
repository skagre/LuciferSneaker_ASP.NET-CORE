using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using LuciferSneaker.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuciferSneaker.Controllers
{
    public class AdminController : Controller
    {
        private readonly InterfaceGiay _interfaceGiay;
        private readonly InterfaceLoaiGiay _interfaceLoaiGiay;
        private readonly InterfaceDonHang _interfaceDonHang;
        private readonly InterfaceTaiKhoan _interfaceTaiKhoan;
        public AdminController(InterfaceGiay interfaceGiay, InterfaceLoaiGiay interfaceLoaiGiay, InterfaceDonHang interfaceDonHang, InterfaceTaiKhoan interfaceTaiKhoan)
        {
            _interfaceGiay = interfaceGiay;
            _interfaceLoaiGiay = interfaceLoaiGiay;
            _interfaceDonHang = interfaceDonHang;
            _interfaceTaiKhoan = interfaceTaiKhoan;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TaiKhoan taiKhoan)
        {
            var tk = _interfaceTaiKhoan.DangNhap(taiKhoan);
            if (tk != null)
            {
                return RedirectToAction("Giay");
            }
            else
            {
                ViewBag.SaiTkMk = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }
        public IActionResult DangXuat()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Giay()
        {
            return View(_interfaceGiay.LayTatCaGiay());
        }
        public IActionResult ThemGiay()
        {
            ViewBag.loaiGiay = _interfaceLoaiGiay.LayTatCaLoaiGiay();
            return View();
        }
        [HttpPost]
        public IActionResult ThemGiay(Giay giay, IFormFile Anh)
        {
            _interfaceGiay.ThemGiay(giay, Anh);
            return RedirectToAction("Index");
        }
        public IActionResult ChiTietGiay(int id)
        {
            return View(_interfaceGiay.LayGiayTheoID(id));
        }
        public IActionResult SuaGiay(int id)
        {
            ViewBag.loaiGiay = _interfaceLoaiGiay.LayTatCaLoaiGiay();
            return View(_interfaceGiay.LayGiayTheoID(id));
        }
        [HttpPost]
        public IActionResult SuaGiay(Giay giay, int id, IFormFile Anh)
        {
            _interfaceGiay.SuaGiay(giay, id, Anh);
            return RedirectToAction("Index");
        }
        public IActionResult XoaGiay(int id)
        {
            _interfaceGiay.XoaGiay(id);
            return RedirectToAction("Index");
        }
        public IActionResult LoaiGiay()
        {
            ViewBag.loaiGiay = _interfaceLoaiGiay.LayTatCaLoaiGiay();
            return View();
        }
        [HttpPost]
        public IActionResult ThemLoaiGiay(LoaiGiay loaiGiay)
        {
            _interfaceLoaiGiay.ThemLoaiGiay(loaiGiay);
            return RedirectToAction("LoaiGiay");
        }
        public IActionResult SuaLoaiGiay(int id)
        {
            return View(_interfaceLoaiGiay.LayLoaiGiayTheoID(id));
        }
        [HttpPost]
        public IActionResult SuaLoaiGiay(LoaiGiay loaiGiay, int id)
        {
            _interfaceLoaiGiay.SuaLoaiGiay(loaiGiay, id);
            return RedirectToAction("LoaiGiay");
        }
        public IActionResult XoaLoaiGiay(int id)
        {
            _interfaceLoaiGiay.XoaLoaiGiay(id);
            return RedirectToAction("LoaiGiay");
        }
        public IActionResult DonHang()
        {
            return View(_interfaceDonHang.LayTatCaDonHang());
        }
        public IActionResult ChiTietDonHang(int id)
        {
 
            return View(_interfaceDonHang.LayDonHangTheoID(id));
        }
    }
}