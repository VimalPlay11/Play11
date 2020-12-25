using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminBL
    {

        AdminDB objAdminDB = new AdminDB();
        MatchDB objMatchDB = new MatchDB();
        
        public void SaveMatchDetails(AdminEL admindetails)
        {
            try
            {
                objAdminDB.SaveMatchDetails(admindetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SavePlayerDetails(AdminEL admindetails)
        {
            try
            {
                objAdminDB.SavePlayerDetails(admindetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveScoreCardDetails(AdminEL admindetails)
        {
            try
            {
                objAdminDB.SaveScoreCardDetails(admindetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TeamDetailsEL> lstTeamName()
        {
            try
            {
                TeamDetailsEL objTeamDetailsEL;
                List<TeamDetailsEL> lstteam = new List<TeamDetailsEL>();
                var res = objMatchDB.GetTeamName();
                foreach (var team in res)
                {
                    objTeamDetailsEL = new TeamDetailsEL();
                    objTeamDetailsEL.TeamId = team.TeamId;
                    objTeamDetailsEL.TeamName = team.TeamName;
                    lstteam.Add(objTeamDetailsEL);
                }
                return lstteam;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PlayerDetailsEL> lstPlayerName(int matId)
        {
            try
            {
                PlayerDetailsEL objPlayerDetailsEL;
                List<PlayerDetailsEL> lstPlayerName = new List<PlayerDetailsEL>();
                var res = objAdminDB.GetSCDetailsbyMatchId(matId);
                foreach (var player in res)
                {
                    objPlayerDetailsEL = new PlayerDetailsEL();
                    objPlayerDetailsEL.PlayerId = (int)player.PlayerId;
                    objPlayerDetailsEL.PlayerName = player.ref_PlayerDetails.PlayerName;
                    lstPlayerName.Add(objPlayerDetailsEL);
                }
                return lstPlayerName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
