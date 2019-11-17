using LuciferSneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuciferSneaker.ViewModels
{
    public class Giay_LoaiGiayViewModel
    {
        public IEnumerable<Giay> _Giay { get; set; }

        public IEnumerable<LoaiGiay> _LoaiGiay { get; set; }
    }
}
