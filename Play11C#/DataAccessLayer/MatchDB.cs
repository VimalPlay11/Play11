using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MatchDB
    {
        Play11DatabaseEntities objPlay11DB = new Play11DatabaseEntities();
        public List<ref_MatchDetails> GetMatchDetails()
        {
            try
            {
                var res = (from matchdetails in objPlay11DB.ref_MatchDetails
                           select matchdetails).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ref_TeamDetails> GetTeamName()
        {
            try
            {
                var res = (from teamdetails in objPlay11DB.ref_TeamDetails
                           select teamdetails).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
