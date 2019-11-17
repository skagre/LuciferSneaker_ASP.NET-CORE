using LuciferSneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.Interfaces
{
    public interface InterfaceDonHang
    {
        IEnumerable<DonHang> LayTatCaDonHang();
        DonHang LayDonHangTheoID(int id);    
        void TaoDonHang(DonHang donHang);
    }
}
