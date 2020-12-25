using BusinessLayer;
using EntityLayer;
using Play11.Action_Files;
using Play11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Play11.Controllers
{
    [UserSessionCheck]
    public class MatchController : Controller
    {
        MatchBL objMatchBL = new MatchBL();
        UserBL objUserBL = new UserBL();
        PlayerDetails objPlayerDetails = new PlayerDetails();
        // GET: Match

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                MatchDetails lstmatchdetails = new MatchDetails();
                lstmatchdetails.lstFixtures = objMatchBL.GetListOfFixturedMatches(CommonClass.Fixtures);
                lstmatchdetails.lstInProgress = objMatchBL.GetListOfInProgressMatches(CommonClass.InProgress);
                lstmatchdetails.lstCompleted = objMatchBL.GetListOfCompletedMatches(CommonClass.Completed);
                return View(lstmatchdetails);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return View("error");
            }
        }
        [HttpPost]
        public ActionResult Index(int matchId)
        {
            return RedirectToAction("Index", "Match");
        }
        public ActionResult LeaderBoard()
        {
            try
            {
                //  var a =  objUserBL.GetUserPoints(teamdetails);
                List<UserEL> lstUserEL = new List<UserEL>();
                var matchId = (int)Session["MatchId"];
                lstUserEL = objMatchBL.CalculateAllUserPoints(matchId);
                return View(lstUserEL);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return View("error");
            }
        }
        public ActionResult ViewTeam(int userId)
        {
            try
            {
                // decimal currentUserPoint = objUserBL.GetUserPoints(teamdetails, matchId);
                var matchId = (int)Session["MatchId"];

                objPlayerDetails.lstWicketKeeper = objUserBL.ViewTeamDetails(userId, matchId, CommonClass.WKRoleID);
                objPlayerDetails.lstBatsman = objUserBL.ViewTeamDetails(userId, matchId, CommonClass.BatRoleID);
                objPlayerDetails.lstAllRounder = objUserBL.ViewTeamDetails(userId, matchId, CommonClass.ARRoleID);
                objPlayerDetails.lstBowler = objUserBL.ViewTeamDetails(userId, matchId, CommonClass.BowlRoleID);

                return PartialView("_ViewTeam", objPlayerDetails);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(Convert.ToString(Session["UserId"]), Convert.ToString(ex.InnerException), Convert.ToString(ex.Message), Convert.ToString(ex.Source), Convert.ToString(ex.StackTrace), DateTime.Now);
                return View("error");
            }
        }
    }
}