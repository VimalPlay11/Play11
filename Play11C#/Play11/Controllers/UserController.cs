using BusinessLayer;
using EntityLayer;
using Play11.Action_Files;
using Play11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Play11.Controllers
{
    [UserSessionCheck]
    public class UserController : Controller
    {
        PlayerBL objPlayerBL = new PlayerBL();
        UserBL objUserBL = new UserBL();
        PlayerDetails objPlayerDetails = new PlayerDetails();
        [HttpGet]
        public ActionResult Index(int matchId)
        {
            try
            {
                Session["MatchId"] = matchId;
                objPlayerDetails.lstWicketKeeper = objPlayerBL.GetPlayerDetailsByRoleId(matchId, CommonClass.WKRoleID);
                objPlayerDetails.lstBatsman = objPlayerBL.GetPlayerDetailsByRoleId(matchId, CommonClass.BatRoleID);
                objPlayerDetails.lstAllRounder = objPlayerBL.GetPlayerDetailsByRoleId(matchId, CommonClass.ARRoleID);
                objPlayerDetails.lstBowler = objPlayerBL.GetPlayerDetailsByRoleId(matchId, CommonClass.BowlRoleID);

                return View(objPlayerDetails);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return View("error");
            }
        }
        [HttpPost]
        public int Index(int[] teamdetails)
        {
            try
            {
                int resultFlag = 0;
                List<int> list = new List<int>(teamdetails);

                int userId = Convert.ToInt32(Session["UserId"]);
                int matchId = Convert.ToInt32(Session["MatchId"]);

                if (list.Count == 11)
                {
                    bool resMT = objUserBL.CheckMatchTime(matchId);
                    if (resMT)
                    {
                        int res = objUserBL.SaveUserTeam(userId, list, matchId);
                        resultFlag = 1;
                        // alert("Team Saved Successfully");
                    }
                    else
                    {
                        int count = objUserBL.CheckUserTeam(userId, matchId);
                        if (count == 0)
                        {
                            resultFlag = 2;
                            // alert("Deadline Passed!! play other matches");                   
                        }
                        else if (count > 0)
                        {
                            resultFlag = 3;
                            //  alert("Deadline Passed!!");
                            //return RedirectToAction("LeaderBoard", "Match");
                        }

                    }
                }
                return resultFlag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return -1;
                // return View("error");
            }
        }
        public int CheckUserJoinedContest(int matchId)
        {
            try
            {
                Session["MatchId"] = matchId;

                int userId = Convert.ToInt32(Session["UserId"]);
                int teamCount = 0;
                teamCount = objUserBL.CheckUserTeam(userId, matchId);
                return teamCount;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return -1;
                // return View("error");
            }
        }

    }
}