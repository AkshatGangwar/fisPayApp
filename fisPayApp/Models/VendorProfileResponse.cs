using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class VendorProfileResponse
    {
        public VendorProfileResponseData dataObject { get; set; }
    }
    public class VendorProfileResponseData
    {
        public VendorProfileData data { get; set; }
    }
}
