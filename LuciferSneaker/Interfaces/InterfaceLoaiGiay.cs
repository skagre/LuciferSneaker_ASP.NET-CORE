using LuciferSneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Interfaces
{
    public interface InterfaceLoaiGiay
    {
        LoaiGiay LayLoaiGiayTheoID(int id);
        IEnumerable<LoaiGiay> LayTatCaLoaiGiay();
        LoaiGiay ThemLoaiGiay(LoaiGiay loaiGiay);
        LoaiGiay SuaLoaiGiay(LoaiGiay loaiGiay, int id);
        LoaiGiay XoaLoaiGiay(int id);
        
    }
}
