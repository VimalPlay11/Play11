using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Play11.Models
{
    public class MatchDetails
    {
        //public int UserId { get; set; }
        //public int MatchId { get; set; }
        //public List<int> lstPlayerId { get; set; }
        public List<MatchDetailsEL> lstFixtures { get; set; }
        public List<MatchDetailsEL> lstInProgress { get; set; }
        public List<MatchDetailsEL> lstCompleted { get; set; }
    }
}