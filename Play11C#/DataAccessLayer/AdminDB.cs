using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdminDB
    {
        Play11DatabaseEntities objPlay11DB = new Play11DatabaseEntities();
        public void SaveMatchDetails(AdminEL admindetails)
        {
            try
            {
                ref_MatchDetails objMatDetails = new ref_MatchDetails();

                objMatDetails.Venue = admindetails.objMatchDetailsEL.Venue;
                objMatDetails.FirstTeam = admindetails.objMatchDetailsEL.FirstTeam;
                objMatDetails.SecondTeam = admindetails.objMatchDetailsEL.SecondTeam;
                objMatDetails.MatchDate = admindetails.objMatchDetailsEL.MatchDate;
                objMatDetails.MatchTime = admindetails.objMatchDetailsEL.MatchTime;
                objMatDetails.IsCompleted = 0;
                objPlay11DB.ref_MatchDetails.Add(objMatDetails);
                var res = objPlay11DB.SaveChanges();
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
                ref_PlayerDetails objPlayerDetails = new ref_PlayerDetails();

                objPlayerDetails.PlayerName = admindetails.objPlayerDetailsEL.PlayerName;
                objPlayerDetails.PlayerRoleId = admindetails.objPlayerDetailsEL.PlayerRoleId;
                objPlayerDetails.Points = admindetails.objPlayerDetailsEL.PlayerPoints;
                objPlayerDetails.TeamId = admindetails.objPlayerDetailsEL.PlayerTeamId;
                objPlay11DB.ref_PlayerDetails.Add(objPlayerDetails);
                var res = objPlay11DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<trn_ScoreCardDetails> GetSCDetailsbyMatchId(int matchId)
        {
            try
            {
                var res = objPlay11DB.trn_ScoreCardDetails.Where(t => t.MatchId == matchId).ToList();
                return res;
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
                // trn_ScoreCardDetails objSCDetails = new trn_ScoreCardDetails();
                var result = objPlay11DB.trn_ScoreCardDetails;
                var playerData = result.Where(t => t.PlayerId == admindetails.objScoreCardDetailsEL.PlayerId).ToList();
                foreach (var data in playerData)
                {
                    data.MatchId = admindetails.objScoreCardDetailsEL.MatchId;
                    data.PlayerId = admindetails.objScoreCardDetailsEL.PlayerId;
                    data.RunsScored = admindetails.objScoreCardDetailsEL.RunsScored;
                    data.FourCount = admindetails.objScoreCardDetailsEL.FourCount;
                    data.SixCount = admindetails.objScoreCardDetailsEL.SixCount;
                    data.RunOutorCatches = admindetails.objScoreCardDetailsEL.RunOutorCatches;
                    data.WicketsTaken = admindetails.objScoreCardDetailsEL.WicketsTaken;
                    data.MaidenOvers = admindetails.objScoreCardDetailsEL.MaidenOvers;
                }

                //   objPlay11DB.trn_ScoreCardDetails.Add(objSCDetails);
                var res = objPlay11DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
