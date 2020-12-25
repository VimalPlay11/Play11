using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AdminEL
    {
        public List<TeamDetailsEL> lstTeamDetailsEL { get; set; }
        public List<MatchDetailsEL> lstMatchDetailsEL { get; set; }
        public List<PlayerDetailsEL> lstPlayerDetailsEL { get; set; }
        public List<ScoreCardDetailsEL> lstScoreCardDetailsEL { get; set; }
        public TeamDetailsEL objTeamDetailsEL { get; set; }
        public MatchDetailsEL objMatchDetailsEL { get; set; }
        public PlayerDetailsEL objPlayerDetailsEL { get; set; }
        public ScoreCardDetailsEL objScoreCardDetailsEL { get; set; }

    }
}
