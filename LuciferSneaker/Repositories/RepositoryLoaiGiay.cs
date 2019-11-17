using LuciferSneaker.Interfaces;
using LuciferSneaker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Repositories
{
    public class RepositoryLoaiGiay : InterfaceLoaiGiay
    {
        private readonly CSDL _csdl;

        public RepositoryLoaiGiay(CSDL csdl)
        {
            _csdl = csdl;
        }

        public LoaiGiay LayLoaiGiayTheoID(int id)
        {
            return _csdl._LoaiGiay.Find(id);
        }

        public IEnumerable<LoaiGiay> LayTatCaLoaiGiay()
        {
            return _csdl._LoaiGiay;
        }

        public LoaiGiay ThemLoaiGiay(LoaiGiay loaiGiay)
        {
            _csdl._LoaiGiay.Add(loaiGiay);
            _csdl.SaveChanges();
            return loaiGiay;
        }

        public LoaiGiay SuaLoaiGiay(LoaiGiay loaiGiay, int id)
        {
            LoaiGiay lg = _csdl._LoaiGiay.Find(id);
            if (lg != null)
            {
                lg.TenLoaiGiay = loaiGiay.TenLoaiGiay;
                _csdl.SaveChanges();
            }
            return lg;
        }

        public LoaiGiay XoaLoaiGiay(int id)
        {
            LoaiGiay lg = _csdl._LoaiGiay.Find(id);
            if (lg != null)
            {
                _csdl._LoaiGiay.Remove(lg);
                _csdl.SaveChanges();
            }
            return lg;
        }
    }
}
