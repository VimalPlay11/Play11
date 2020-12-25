using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PlayerDB
    {
        Play11DatabaseEntities objPlay11DB = new Play11DatabaseEntities();
        public List<ref_PlayerDetails> GetPlayerDetails(int matchId)
        {
            try
            {
                var fstteam = (from pd in objPlay11DB.ref_PlayerDetails
                               join md in objPlay11DB.ref_MatchDetails on pd.TeamId equals (md.FirstTeam)
                               where md.MatchId == matchId
                               select pd).ToList<ref_PlayerDetails>();
                var scdteam = (from pd in objPlay11DB.ref_PlayerDetails
                               join md in objPlay11DB.ref_MatchDetails on pd.TeamId equals (md.SecondTeam)
                               where md.MatchId == matchId
                               select pd).ToList<ref_PlayerDetails>();
                var res = fstteam.Concat(scdteam).ToList<ref_PlayerDetails>();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetTeamNameById(int teamid)
        {
            try
            {
                var res = (from teamdetails in objPlay11DB.ref_PlayerDetails
                           where teamdetails.TeamId == teamid
                           select teamdetails.ref_TeamDetails.TeamName).FirstOrDefault().ToString();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<trn_ScoreCardDetails> GetPlayerScore()
        {
            try
            {
                var res = (from playerscore in objPlay11DB.trn_ScoreCardDetails
                           select playerscore).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
