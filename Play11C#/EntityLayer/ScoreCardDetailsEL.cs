using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ScoreCardDetailsEL
    {
        public int MatchId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
        public int RunsScored { get; set; }
        public int FourCount { get; set; }
        public int SixCount { get; set; }
        public int RunOutorCatches { get; set; }
        public int WicketsTaken { get; set; }
        public int MaidenOvers { get; set; }
    }
}
