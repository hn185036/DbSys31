using System;
using System.ComponentModel;

namespace Dbsys
{
    public class UserAccount
    {
        [DisplayName("UserId")]  // Update Display Name 
        public int? userId { get; set; }
        [DisplayName("Username")]
        public String userName { get; set; }
        [DisplayName("Password")]
        public String userPassword { get; set; }
        [DisplayName("Status")]
        public String userStatus { get; set; }
    }
}
