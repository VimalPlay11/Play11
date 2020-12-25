using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBL
    {
        UserDB objUserDB = new UserDB();
        UserEL objUserEL = new UserEL();
        PlayerBL objPlayerBL = new PlayerBL();
        PlayerDB objPlayerDB = new PlayerDB();
        MatchDB objMatchDB = new MatchDB();
        public int RegisterNewUser(string username, string mail, string password, string phoneno)
        {
            try
            {
                var res = objUserDB.RegisterUserDetails(username, mail, password, phoneno);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEL ValidateUserLogin(string mail, string password)
        {
            try
            {
                ref_UserDetails lstUserDetails = null;

                lstUserDetails = objUserDB.GetUserDetails(mail, password);

                if (lstUserDetails != null)
                {
                    objUserEL.userId = Convert.ToInt32(lstUserDetails.UserId);
                    objUserEL.userName = lstUserDetails.UserName;
                    objUserEL.userRoleId = Convert.ToInt32(lstUserDetails.RoleId);
                }
                return objUserEL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveUserTeam(int userId, List<int> lstPlayerId, int matchId)
        {
            try
            {
                int res = 0;
                res = res + objUserDB.SaveUserTeamDetails(userId, lstPlayerId, matchId);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CheckUserTeam(int userId, int matchId)
        {
            try
            {
                int NoOfTeams = 0;
                var temp = objUserDB.GetMatchDetailsbyMatchId(matchId);
                NoOfTeams = temp.Where(c => c.UserId == userId).Count();
                return NoOfTeams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckMatchTime(int matchId)
        {
            bool result = true;
            var tempMD = objMatchDB.GetMatchDetails();
            var matchdate = tempMD.Where(t => t.MatchId == matchId).Select(t => t.MatchDate).FirstOrDefault();
            var matchtime = tempMD.Where(t => t.MatchId == matchId).Select(t => t.MatchTime).FirstOrDefault();
            var flgCompleted = tempMD.Where(t => t.MatchId == matchId).Select(t => t.IsCompleted).FirstOrDefault();
            DateTime currDT = DateTime.Now.AddHours(1);
            if (flgCompleted == 1)
            {
                return false;
            }
            else if (currDT.Date == matchdate)
            {
                if (currDT.TimeOfDay >= matchtime)
                {
                    result = false;
                }
            }

            return result;
        }
        public decimal GetUserPoints(List<int> lstplayerId, int matchId)
        {
            try
            {
                decimal result = 0;
                PlayerBL objPlayerBL = new PlayerBL();
                for (int i = 0; i < 11; i++)
                {
                    var pid = Convert.ToInt32(lstplayerId[i]);
                    var temp = objPlayerBL.GetPlayerPointsById(pid, matchId);
                    if (temp > 0)
                    {
                        result = result + temp;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PlayerDetailsEL> ViewTeamDetails(int userId, int matchId, int roleId)
        {
            try
            {
                List<PlayerDetailsEL> lstPlayerDetailsEL = new List<PlayerDetailsEL>();
                PlayerDetailsEL objPlayerDetailsEL;
                var tempMD = objUserDB.GetCurrentMatchDetails(userId, matchId);
                var rolePD = (from t in tempMD
                              where t.ref_PlayerDetails.PlayerRoleId == roleId
                              select t).ToList();
                foreach (var pId in rolePD)
                {
                    objPlayerDetailsEL = new PlayerDetailsEL();
                    objPlayerDetailsEL.PlayerName = objPlayerBL.GetPlayerNameById((int)pId.PlayerId, matchId);
                    objPlayerDetailsEL.TeamName = objPlayerDB.GetTeamNameById((int)pId.ref_PlayerDetails.ref_TeamDetails.TeamId).ToString();
                    objPlayerDetailsEL.PlayerPoints = objPlayerBL.GetPlayerPointsById((int)pId.PlayerId, matchId);
                    lstPlayerDetailsEL.Add(objPlayerDetailsEL);
                }
                return lstPlayerDetailsEL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
