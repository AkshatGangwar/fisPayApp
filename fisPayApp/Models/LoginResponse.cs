namespace fisPayApp.Models
{
    public class LoginResponse
    {
        public LoginResponseData dataObject { get; set; }
    }
    public class LoginResponseData
    {
        public UserInfo data { get; set; }
    }
}
