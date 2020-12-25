using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Play11.Models
{
    public class PlayerDetails
    {
        public List<PlayerDetailsEL> lstWicketKeeper { get; set; }
        public List<PlayerDetailsEL> lstBatsman { get; set; }
        public List<PlayerDetailsEL> lstBowler { get; set; }
        public List<PlayerDetailsEL> lstAllRounder { get; set; }
    }
}