using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExceptionDB
    {
        Play11DatabaseEntities objPlay11DB = new Play11DatabaseEntities();
        public void LogException(string userId, string innerExec, string execMsg, string source, string stackTrace, DateTime datetime)
        {
            ExecptionLog objExecptionLog = new ExecptionLog();
            objExecptionLog.UserId = userId;
            objExecptionLog.InnerExecption = innerExec;
            objExecptionLog.ExceptionMsg = execMsg;
            objExecptionLog.Source = source;
            objExecptionLog.StackTrace = stackTrace;
            objExecptionLog.DateTime = datetime;
      
            objPlay11DB.ExecptionLogs.Add(objExecptionLog);
            objPlay11DB.SaveChanges();
        }
    }
}
