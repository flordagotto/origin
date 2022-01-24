using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Origin.DataContext
{
    public partial class Balance
    {
        [Key]
        public int IdOperacion { get; set; }
        public long IdTarjeta { get; set; }
        public DateTime Hora { get; set; }
    }
}
