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
    [AdminCheck]
    public class AdminController : Controller
    {
        AdminBL objAdminBL = new AdminBL();
        MatchBL objMatchBL = new MatchBL();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            List<TeamDetailsEL> ddlTeamDetails = new List<TeamDetailsEL>();
            ddlTeamDetails = objAdminBL.lstTeamName().ToList();
            ViewData["TeamDetails"] = new SelectList(ddlTeamDetails, "TeamId", "TeamName");

            List<MatchDetailsEL> ddlMatchDetails = new List<MatchDetailsEL>();
            ddlMatchDetails = objMatchBL.GetListOfInProgressMatches(CommonClass.InProgress);
            ViewData["InProgressMD"] = new SelectList(ddlMatchDetails, "MatchId", "MatchId");
            return View();
        }

        public ActionResult GetPlayerDetailsByMatchId(int matchId)
        {
            List<PlayerDetailsEL> ddlPlayerDetailsEL = new List<PlayerDetailsEL>();
            ddlPlayerDetailsEL = objAdminBL.lstPlayerName(matchId).ToList();
            var tempRes = ddlPlayerDetailsEL.Select(c => new
            {
                PlayerId = c.PlayerId,
                PlayerName = c.PlayerName
            });
            string result = Newtonsoft.Json.JsonConvert.SerializeObject(tempRes);
            return Json(tempRes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveMatchDetails(AdminEL admindetails)
        {
            objAdminBL.SaveMatchDetails(admindetails);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SavePlayerDetails(AdminEL admindetails)
        {
            objAdminBL.SavePlayerDetails(admindetails);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SaveScoreCardDetails(AdminEL admindetails)
        {
            objAdminBL.SaveScoreCardDetails(admindetails);
            return RedirectToAction("Index");
        }
    }
}