using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class OtpResponse
    {
        public OtpResponseData dataObject { get; set; }
    }
    public class OtpResponseData
    {
        public OtpData data { get; set; }
    }
}
