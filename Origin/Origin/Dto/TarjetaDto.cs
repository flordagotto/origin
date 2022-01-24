using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Dto
{
    public class TarjetaDto
    {
        public long Numero { get; set; }
        public byte Bloqueada { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }
        public int Tries { get; set; }
    }
}
