using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PlayerDetailsEL
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public int? PlayerTeamId { get; set; }
        public string TeamName { get; set; }
        public int? PlayerRoleId { get; set; }
        public decimal? PlayerPoints { get; set; }
    }
}
