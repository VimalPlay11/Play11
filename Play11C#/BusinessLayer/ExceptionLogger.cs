using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;



namespace BusinessLayer
{
    public static class ExceptionLogger
    {
        public static void LogException(string userId,string innerExec, string execMsg, string source, string stackTrace, DateTime datetime)
        {
            ExceptionDB objExceptionDB = new ExceptionDB();
            objExceptionDB.LogException(userId, innerExec, execMsg, source, stackTrace, datetime);
        }
    }
}
