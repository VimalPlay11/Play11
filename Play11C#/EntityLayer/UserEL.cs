using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserEL
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmailId { get; set; }
        public string userPhoneNumber { get; set; }
        public string userPassword{ get; set; }
        public int userRoleId { get; set; }
        public decimal UserPoints { get; set; }
        public int userRank { get; set; }
        public List<int> lstPlayerId { get; set; }
    }
}
