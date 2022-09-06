using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
   
    public class UserResponse
    {
        public UserResponseData dataObject { get; set; }
    }
    public class UserResponseData
    {
        public UserData data { get; set; }
    }
    public class UserData
    {
        public string userName { get; set; }
        public string userType { get; set; }
        public string storeName { get; set; }
    }

}
