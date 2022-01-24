using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Dto
{
    public class BalanceDto
    {
        public int IdOperacion { get; set; }
        public long IdTarjeta { get; set; }
        public DateTime Hora { get; set; }
    }
}
