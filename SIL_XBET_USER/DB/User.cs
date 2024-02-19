using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIL_XBET_BANK
{
    public partial class User
    {
        public User()
        {
            GameHistory = new HashSet<GameHistory>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? SessionId { get; set; }
        public decimal? Balance { get; set; }

        public virtual ICollection<GameHistory> GameHistory { get; set; }
    }
}
