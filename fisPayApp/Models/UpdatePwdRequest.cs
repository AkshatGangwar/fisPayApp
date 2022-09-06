using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class UpdatePwdRequest
    {
        public string userID { get; set; }
        public string password { get; set; }
    }
}
