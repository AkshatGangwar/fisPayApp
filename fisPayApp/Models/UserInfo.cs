using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class UserInfo
    {
        public string name { get; set; }
        public string userId { get; set; }
        public string userType { get; set; }
        public string emailId { get; set; }
        public string mobile { get; set; }
        public string token { get; set; }
        public string userImg { get; set; }
        public bool isWalletActivate { get; set; }
        public bool isVendorAccount { get; set; }
        public string walletBal { get;set; }
    }
}
