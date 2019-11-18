using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Repositories
{
    public class RepositoryGiay : InterfaceGiay
    {
        private readonly CSDL _csdl;
        public RepositoryGiay(CSDL csdl)
        {
            _csdl = csdl;
        }

        public Giay LayGiayTheoID(int id)
        {
            return _csdl._Giay.Find(id);
        }
        public IEnumerable<Giay> LayTatCaGiay()
        {
            return _csdl._Giay;
        }

        public IEnumerable<Giay> LayTatCaGiayTheoID(int id)
        {
            return _csdl._Giay.Where(x => x.LoaiGiayID == id).Select(x => x);
        }

        public IEnumerable<Giay> TimKiemGiay(string search)
        {
            return _csdl._Giay.Where(x => x.TenGiay.Contains(search)).Select(x => x);
        }

        public void ThemAnh(Giay giay, IFormFile anh)
        {
            Random r = new Random();
            string random = r.Next(1, 100000000).ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", random + anh.FileName);
            var stream = new FileStream(path, FileMode.Create);
            anh.CopyToAsync(stream).Wait();
            giay.Anh = random + anh.FileName;
            stream.Close();
        }

        public Giay ThemGiay(Giay giay, IFormFile anh)
        {
            ThemAnh(giay, anh);

            _csdl._Giay.Add(giay);
            _csdl.SaveChanges();
            return giay;
        }

        public Giay SuaGiay(Giay giay, int id, IFormFile anh)
        {
            Giay g = _csdl._Giay.Find(id);
            if (g != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", g.Anh);

                g.TenGiay = giay.TenGiay;
                g.Style = giay.Style;
                g.MauSac = giay.MauSac;
                g.Gia = giay.Gia;
                g.TrangThai = giay.TrangThai;
                ThemAnh(giay, anh);
                g.Anh = giay.Anh;
                g.MoTa = giay.MoTa;

                _csdl.SaveChanges();

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            return g;
        }

        public Giay XoaGiay(int id)
        {
            Giay g = _csdl._Giay.Find(id);
            if (g != null)
            {
                _csdl._Giay.Remove(g);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", g.Anh);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                _csdl.SaveChanges();
            }
            return g;
        }
    }
}
