namespace fisPayApp.Models
{
    public class WalletResponse
    {
        public WalletResponseData dataObject { get; set; }   
    }
    public class WalletResponseData
    {
        public WalletData data { get; set; }
    }
    public class WalletData
    {
        public string userId { get; set; }
        public string otp { get; set; }
        public string totalBalance { get; set; }
    }
}
