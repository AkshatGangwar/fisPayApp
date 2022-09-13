using System.Xml.Linq;

namespace fisPayApp.Models
{
    public class MobileSearch
    {
        public string userName { get; set; }
        public string userId { get; set; }
        public string userType { get; set; }
        public string storeName { get; set; }
        public string Name
        {
            get=> $"{getName()}";
        }
        string getName()
        {
            if (userType == "1")
                return userName;
            else
                return storeName;
        }
    }
}
