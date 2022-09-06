using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
    public class PersonProfileResponse
    {
        public PersonProfileResponseData dataObject { get; set; }
    }
    public class PersonProfileResponseData
    {
        public PersonProfileData data { get; set; }
    }
}
