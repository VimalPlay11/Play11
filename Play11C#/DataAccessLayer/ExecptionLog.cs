//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExecptionLog
    {
        public int LogId { get; set; }
        public string UserId { get; set; }
        public string InnerExecption { get; set; }
        public string ExceptionMsg { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}
