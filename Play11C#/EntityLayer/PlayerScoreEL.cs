using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class PlayerScoreEL
    {
        public int? PlayerId;
        public int Runs;
        public int Fours;
        public int Sixes;
        public int CatchesOrRunout;
        public int WicketsTaken;
        public int MaidenOvers;

        public decimal TotalPlayerPoints;
    }
}
