using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class AddWalletRequest
    {
        public string amount { get; set; }
        public string comment { get; set; }
    }
}
