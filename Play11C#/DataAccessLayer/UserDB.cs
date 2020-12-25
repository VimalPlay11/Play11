using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDB
    {
        //UserEL objUserEL;
        Play11DatabaseEntities objPlay11DB = new Play11DatabaseEntities();
        public int RegisterUserDetails(string UserName, string EmailId, string Password, string PhoneNumber)
        {
            try
            {
                var res = 0;
                var checkMailId = (from userdetails in objPlay11DB.ref_UserDetails
                                   where userdetails.EmailId == EmailId select userdetails).ToList();
                if (checkMailId.Count() == 0)
                {
                    ref_UserDetails objNewUD = new ref_UserDetails();
                    objNewUD.UserName = UserName;
                    objNewUD.Password = Password;
                    objNewUD.EmailId = EmailId;
                    objNewUD.MobileNumber = PhoneNumber;
                    objNewUD.RoleId = 2;
                    objPlay11DB.ref_UserDetails.Add(objNewUD);
                    res = objPlay11DB.SaveChanges();
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ref_UserDetails GetUserDetails(string mailid, string password)
        {
            try
            {
                var res = (from userdetails in objPlay11DB.ref_UserDetails
                           where userdetails.EmailId == mailid && userdetails.Password == password
                           select userdetails).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveUserTeamDetails(int userId, List<int> lstPlayerId, int matchId)
        {
            try
            {
                int rowsAffected=0;
                trn_UserTeamDetails objUTDetails = new trn_UserTeamDetails();
                var res = GetCurrentMatchDetails(userId, matchId);
                int playercount = res.Count();
                if (playercount == 0)
                {
                    foreach (var pid in lstPlayerId)
                    {
                        objUTDetails.UserId = userId;
                        objUTDetails.PlayerId = pid;
                        objUTDetails.MatchId = matchId;
                        objPlay11DB.trn_UserTeamDetails.Add(objUTDetails);
                        rowsAffected = rowsAffected + objPlay11DB.SaveChanges();
                    }

                }
                else if (playercount == 11)
                {
                    int[] arrlst = res.Select(t => (int)t.PlayerId).ToArray<int>();
                    int i = 0;
                    foreach (var EPId in arrlst)
                    {
                        var result = objPlay11DB.trn_UserTeamDetails.FirstOrDefault(b => b.UserId == userId && b.MatchId == matchId && b.PlayerId == EPId);

                        if (result != null && i < 11)
                        {
                            result.PlayerId = lstPlayerId[i];
                            rowsAffected = rowsAffected + objPlay11DB.SaveChanges();
                            i++;
                        }
                    }
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<trn_UserTeamDetails> GetCurrentMatchDetails(int userId, int matchId)
        {
            try
            {
                var res = (from userdetails in objPlay11DB.trn_UserTeamDetails
                           where userdetails.UserId == userId && userdetails.MatchId == matchId
                           select userdetails).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<trn_UserTeamDetails> GetMatchDetailsbyMatchId(int matchId)
        {
            try
            {
                var res = objPlay11DB.trn_UserTeamDetails.Where(t => t.MatchId == matchId).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
