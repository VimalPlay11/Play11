using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PlayerBL
    {
        PlayerDB objPlayerDB = new PlayerDB();

        public List<PlayerDetailsEL> GetPlayerDetailsByRoleId(int matchId, int roleId)
        {
            try
            {
                PlayerDetailsEL objPDEL;
                List<PlayerDetailsEL> lstPD = new List<PlayerDetailsEL>();
                var playerdetails = objPlayerDB.GetPlayerDetails(matchId);
                playerdetails = (from res in playerdetails
                                 where res.PlayerRoleId == roleId
                                 select res).ToList();
                foreach (var a in playerdetails)
                {
                    objPDEL = new PlayerDetailsEL();
                    objPDEL.PlayerId = a.PlayerId;
                    objPDEL.PlayerName = a.PlayerName;
                    objPDEL.PlayerRoleId = a.PlayerRoleId;
                    objPDEL.PlayerTeamId = a.TeamId;
                    objPDEL.TeamName = objPlayerDB.GetTeamNameById((int)a.TeamId);
                    objPDEL.PlayerPoints = a.Points;
                    lstPD.Add(objPDEL);
                }
                lstPD=lstPD.OrderByDescending(t => t.PlayerPoints).ToList();
                return lstPD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPlayerNameById(int playerId, int matchId)
        {
            try
            {
                var playerdetails = objPlayerDB.GetPlayerDetails(matchId);
                var res = (from name in playerdetails
                           where name.PlayerId == playerId
                           select name.PlayerName).FirstOrDefault().ToString();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetPlayerPointsById(int playerid, int matchId)
        {
            try
            {
                var points = GetPlayerPoints(matchId);
                var playeroints = (from temp in points
                                   where temp.PlayerId == playerid
                                   select temp.TotalPlayerPoints).FirstOrDefault();
                return playeroints;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PlayerScoreEL> GetPlayerPoints(int matchId)
        {
            try
            {
                PlayerScoreEL objPlayerScoreEL;
                List<PlayerScoreEL> lstPlayerScore = new List<PlayerScoreEL>();

                var tempres = objPlayerDB.GetPlayerScore();
                var temp = tempres.Where(t => t.MatchId == matchId).ToList();
                //  var temp1 = (from score in temp select score);

                foreach (var s in temp)
                {
                    objPlayerScoreEL = new PlayerScoreEL();
                    objPlayerScoreEL.PlayerId = s.PlayerId;
                    objPlayerScoreEL.Runs = (int)s.RunsScored;
                    objPlayerScoreEL.Fours = (int)s.FourCount;
                    objPlayerScoreEL.Sixes = (int)s.SixCount;
                    objPlayerScoreEL.CatchesOrRunout = (int)s.RunOutorCatches;
                    objPlayerScoreEL.WicketsTaken = (int)s.WicketsTaken;
                    objPlayerScoreEL.MaidenOvers = (int)s.MaidenOvers;
                    objPlayerScoreEL.TotalPlayerPoints = CalculateRun(objPlayerScoreEL.Runs, objPlayerScoreEL.Fours, objPlayerScoreEL.Sixes, objPlayerScoreEL.CatchesOrRunout, objPlayerScoreEL.WicketsTaken, objPlayerScoreEL.MaidenOvers);
                    lstPlayerScore.Add(objPlayerScoreEL);
                }
                return lstPlayerScore;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal CalculateRun(int run, int four, int six, int catches, int wicketstaken, int maidenovers)
        {
            try
            {
                decimal calcrun = 0;
                decimal calcfour = 0;
                decimal calcsix = 0;
                decimal calccatch = 0;
                decimal calcwt = 0;
                decimal calcmo = 0;

                if (run > 0) calcrun = run / 2;
                if (four > 0) calcfour = four * 2;
                if (six > 0) calcsix = six * 3; ;
                if (catches > 0) calccatch = catches * 4;
                if (wicketstaken > 0) calcwt = wicketstaken * 10;
                if (maidenovers > 0) calcmo = maidenovers * 4;

                decimal result = calcrun + calcfour + calcsix + calccatch + calcwt + calcmo;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
