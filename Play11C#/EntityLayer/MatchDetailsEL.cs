using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class MatchDetailsEL
    {
        public int MatchId { get; set; }
        public int FirstTeam { get; set; }
        public int SecondTeam { get; set; }

        public string strFirstTeam { get; set; }
        public string strSecondTeam { get; set; }

        public DateTime MatchDate { get; set; }
        public TimeSpan MatchTime { get; set; }
        public string Venue { get; set; }

        public double MatchDuration { get; set; }
    }
}
