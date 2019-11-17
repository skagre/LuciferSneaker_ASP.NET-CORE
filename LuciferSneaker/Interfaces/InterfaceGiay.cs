using LuciferSneaker.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Interfaces
{
    public interface InterfaceGiay
    {
        Giay LayGiayTheoID(int id);
        IEnumerable<Giay> LayTatCaGiay();
        void ThemAnh(Giay giay, IFormFile anh);
        Giay ThemGiay(Giay giay, IFormFile anh);
        Giay SuaGiay(Giay giay, int id, IFormFile anh);
        Giay XoaGiay(int id);
    }
}
