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
    
    public partial class ref_PlayerRole
    {
        public ref_PlayerRole()
        {
            this.ref_PlayerDetails = new HashSet<ref_PlayerDetails>();
        }
    
        public int PlayerRoleId { get; set; }
        public string PlayerRoleName { get; set; }
    
        public virtual ICollection<ref_PlayerDetails> ref_PlayerDetails { get; set; }
    }
}
