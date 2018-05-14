using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpPacks
{
    [Serializable]
    public class UdpPack
    {
        public int id { get; set; }
        public int count { get; set; }
        public byte[] pack { get; set; }
        public long bl { get; set; }
        public byte[] packname { get; set; }
    }
}
