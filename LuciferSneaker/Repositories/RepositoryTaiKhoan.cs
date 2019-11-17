using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Repositories
{
    public class RepositoryTaiKhoan : InterfaceTaiKhoan
    {
        private readonly CSDL _csdl;
        public RepositoryTaiKhoan(CSDL csdl)
        {
            _csdl = csdl;
        }


        public TaiKhoan DangNhap(TaiKhoan taiKhoan)
        {
            var tk = _csdl._TaiKhoan.Where(t => t.TenTaiKhoan == taiKhoan.TenTaiKhoan && t.MatKhau == taiKhoan.MatKhau).FirstOrDefault();
            if (tk != null)
            {
                return tk;
            }
            return null;
        }
    }
}
