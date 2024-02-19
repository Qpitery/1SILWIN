using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIL_XBET_BANK
{
    public partial class GameHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string GameType { get; set; }
        public decimal? Price { get; set; }
        public string Result { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual User User { get; set; }
    }
}
