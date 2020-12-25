using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MatchBL
    {
        MatchDB objMatchDB = new MatchDB();
        UserDB objUserDB = new UserDB();
        UserBL objUserBL = new UserBL();

        public List<MatchDetailsEL> GetListOfCompletedMatches(int matchStatus)
        {
            try
            {
                MatchDetailsEL objMatchDetailsEL;
                List<MatchDetailsEL> lstMatchDeails = new List<MatchDetailsEL>();
                var temp = objMatchDB.GetMatchDetails();
              //  matchStatus = 0; //for testing
                var lstMatches = temp.Where(t => t.IsCompleted == matchStatus).ToList();
                foreach (var match in lstMatches)
                {
                    objMatchDetailsEL = new MatchDetailsEL();
                    objMatchDetailsEL.MatchId = match.MatchId;
                    objMatchDetailsEL.FirstTeam = ((int)match.FirstTeam);
                    objMatchDetailsEL.SecondTeam = ((int)match.SecondTeam);
                    objMatchDetailsEL.strFirstTeam = GetTeamNameById((int)match.FirstTeam);
                    objMatchDetailsEL.strSecondTeam = GetTeamNameById((int)match.SecondTeam);
                    objMatchDetailsEL.MatchDate = (DateTime)match.MatchDate;
                    objMatchDetailsEL.MatchTime = (TimeSpan)match.MatchTime;
                    objMatchDetailsEL.MatchDuration = SetMatchDuration((DateTime)match.MatchDate, (TimeSpan)match.MatchTime);
                    objMatchDetailsEL.Venue = match.Venue;
                    lstMatchDeails.Add(objMatchDetailsEL);
                }
                return lstMatchDeails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MatchDetailsEL> GetListOfFixturedMatches(int matchStatus)
        {
            try
            {
                MatchDetailsEL objMatchDetailsEL;
                List<MatchDetailsEL> lstMatchDeails = new List<MatchDetailsEL>();
                var temp = objMatchDB.GetMatchDetails();
                var lstMatches = temp.Where(t => t.IsCompleted == matchStatus).ToList();
                foreach (var match in lstMatches)
                {
                    objMatchDetailsEL = new MatchDetailsEL();
                    bool res = objUserBL.CheckMatchTime(match.MatchId);
                    if (res)
                    {
                        objMatchDetailsEL.MatchId = match.MatchId;
                        objMatchDetailsEL.FirstTeam = ((int)match.FirstTeam);
                        objMatchDetailsEL.SecondTeam = ((int)match.SecondTeam);
                        objMatchDetailsEL.strFirstTeam = GetTeamNameById((int)match.FirstTeam);
                        objMatchDetailsEL.strSecondTeam = GetTeamNameById((int)match.SecondTeam);
                        objMatchDetailsEL.MatchDate = (DateTime)match.MatchDate;
                        objMatchDetailsEL.MatchTime = (TimeSpan)match.MatchTime;
                        objMatchDetailsEL.MatchDuration = SetMatchDuration((DateTime)match.MatchDate, (TimeSpan)match.MatchTime);
                        objMatchDetailsEL.Venue = match.Venue;
                    }
                    else
                    {
                        objMatchDetailsEL = null;
                    }
                    if (objMatchDetailsEL != null)
                    {
                        lstMatchDeails.Add(objMatchDetailsEL);
                    }
                }
                return lstMatchDeails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MatchDetailsEL> GetListOfInProgressMatches(int matchStatus)
        {
            try
            {
                MatchDetailsEL objMatchDetailsEL;
                List<MatchDetailsEL> lstMatchDeails = new List<MatchDetailsEL>();
                var temp = objMatchDB.GetMatchDetails();
                var lstMatches = temp.Where(t => t.IsCompleted == matchStatus).ToList();
                foreach (var match in lstMatches)
                {
                    objMatchDetailsEL = new MatchDetailsEL();
                    bool res = objUserBL.CheckMatchTime(match.MatchId);
                    if (!res)
                    {
                        objMatchDetailsEL.MatchId = match.MatchId;
                        objMatchDetailsEL.FirstTeam = ((int)match.FirstTeam);
                        objMatchDetailsEL.SecondTeam = ((int)match.SecondTeam);
                        objMatchDetailsEL.strFirstTeam = GetTeamNameById((int)match.FirstTeam);
                        objMatchDetailsEL.strSecondTeam = GetTeamNameById((int)match.SecondTeam);
                        objMatchDetailsEL.MatchDate = (DateTime)match.MatchDate;
                        objMatchDetailsEL.MatchTime = (TimeSpan)match.MatchTime;
                        objMatchDetailsEL.MatchDuration = SetMatchDuration((DateTime)match.MatchDate, (TimeSpan)match.MatchTime);
                        objMatchDetailsEL.Venue = match.Venue;
                    }
                    else
                    {
                        objMatchDetailsEL = null;
                    }
                    if (objMatchDetailsEL != null)
                    {
                        lstMatchDeails.Add(objMatchDetailsEL);
                    }
                }
                return lstMatchDeails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public double SetMatchDuration(DateTime matchdate, TimeSpan matchtime)
        {
            try
            {
                double temp = 0;
                DateTime current = DateTime.Now;
                var totaldays = (matchdate.Subtract(current)).TotalDays;
                var totalhours = (matchdate.Subtract(current)).TotalHours;
                var totalminutes = (matchdate.Subtract(current)).TotalMinutes;
                var totalseconds = (matchdate.Subtract(current)).TotalSeconds;
                if (totalseconds > 0)
                {
                    return totalminutes;
                }
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetTeamNameById(int teamId)
        {
            try
            {
                var res = objMatchDB.GetTeamName();
                string teamname = (from teamdetails in res
                                   where teamdetails.TeamId == teamId
                                   select teamdetails.TeamName).FirstOrDefault().ToString();
                return teamname;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserEL> CalculateAllUserPoints(int matchId)
        {
            try
            {
                //Display all user with points
                UserEL tmpUserEL;
                List<UserEL> lstUserEL = new List<UserEL>();
                var tempMD = objUserDB.GetMatchDetailsbyMatchId(matchId);
                var listUserId = (tempMD.Select(t => t.UserId).ToList()).Distinct();
                foreach (var a in listUserId)
                {
                    tmpUserEL = new UserEL();
                    tmpUserEL.userId = (int)a.Value;
                    tmpUserEL.userName = tempMD.Where(t => t.UserId == a.Value).Select(t => t.ref_UserDetails.UserName).FirstOrDefault();
                    tmpUserEL.lstPlayerId = tempMD.Where(t => t.UserId == a).Select(t => (int)t.PlayerId).ToList();
                    tmpUserEL.UserPoints = objUserBL.GetUserPoints(tmpUserEL.lstPlayerId, matchId);
                    tmpUserEL.userRank = 1;
                    lstUserEL.Add(tmpUserEL);
                }
                lstUserEL = UserRanking(lstUserEL);

                return lstUserEL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserEL> UserRanking(List<UserEL> lstuserdetails)
        {
            UserEL tmp;
            List<UserEL> lstUser = new List<UserEL>();
            int i = 1;
            int j = 0;

            lstuserdetails = lstuserdetails.OrderByDescending(t => t.UserPoints).ToList();

            foreach (var t in lstuserdetails)
            {
                tmp = new UserEL();
                if (i <= lstuserdetails.Count)
                {
                    if (j > 0 && lstuserdetails[j - 1].UserPoints == lstuserdetails[j].UserPoints)
                    {
                        if (i != 1)
                        {
                            i--;
                        }
                        tmp.userRank = i;
                    }
                    else
                    {

                        tmp.userRank = i;

                    }
                    tmp.userId = t.userId;
                    tmp.userName = t.userName;
                    tmp.lstPlayerId = t.lstPlayerId;
                    tmp.UserPoints = t.UserPoints;
                    i++;
                    j++;
                }
                lstUser.Add(tmp);

            }
            return lstUser;
        }
    }
}
