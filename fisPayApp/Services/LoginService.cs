using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using Newtonsoft.Json;
using System.Text;


namespace fisPayApp.Services
{
    public class LoginService : ILoginRepository
    {
        private async Task<string> ServiceRequest(string url, string data, string type, MultipartFormDataContent parms)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                var client = new HttpClient(httpClientHandler);
                HttpResponseMessage response = null;
                if (!string.IsNullOrWhiteSpace(App.Token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                }
                if (type == "Post")
                {
                    StringContent body = new StringContent(data, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(url, body);
                }
                else if (type == "Put")
                {
                    response = await client.PutAsync(url, parms);
                }
                else
                {
                    var requesturl = url + "/" + data;
                    response = await client.GetAsync(requesturl);
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("No Connection", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
                return null;
            }
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                    string loginRequestStr = JsonConvert.SerializeObject(loginRequest);
                    string url = "https://fispayapi.azurewebsites.net/api/Authentication/Login";
                    var content = await ServiceRequest(url, loginRequestStr, "Post",null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<LoginResponse>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PersonProfileResponse> GetPersonProfile(string UserID)
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Authentication/GetPersonProfile";
                var content = await ServiceRequest(url, UserID, "Get", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<PersonProfileResponse>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<VendorProfileResponse> GetVendorProfile(string UserID)
        {
            try
            {
                 string url = "https://fispayapi.azurewebsites.net/api/Authentication/GetVendorProfile";
                    var content = await ServiceRequest(url, UserID, "Get", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<VendorProfileResponse>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<StoreResponse> GetStoreList(string City)
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Vendor/GetStoreByCity";
                var content = await ServiceRequest(url, City, "Get", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<StoreResponse>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> Logoff(string UserID)
        {
            try
            {
              string url = "https://fispayapi.azurewebsites.net/api/Authentication/Logoff";
                    var content = await ServiceRequest(url, UserID, "Get", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<Response>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<UserResponse> GetUserName(string ID)
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Authentication/GetUserAssociateWIthStore";
                var content = await ServiceRequest(url, ID, "Get", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<UserResponse>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> RegisterPerson(PersonProfileData personProfileData)
        {
            try
            {
             string personProfileDataStr = JsonConvert.SerializeObject(personProfileData);
                    string url = "https://fispayapi.azurewebsites.net/api/Authentication/RegisterPerson";
                    var content = await ServiceRequest(url, personProfileDataStr, "Post", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<Response>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> RegisterVendor(VendorProfileData vendorProfileData)
        {
            try
            {
                string vendorProfileDataStr = JsonConvert.SerializeObject(vendorProfileData);
                    string url = "https://fispayapi.azurewebsites.net/api/Authentication/RegisterVendor";
                    var content = await ServiceRequest(url, vendorProfileDataStr, "Post", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<Response>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OtpResponse> RegistrationOtp(string Mobile)
        {
            try
            {
               string url = "https://fispayapi.azurewebsites.net/api/Authentication/GetOTP";
                    var content = await ServiceRequest(url, Mobile, "Get", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<OtpResponse>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<WalletResponse> ActivateWallet(WalletRequest walletRequest)
        {
            try
            {
                string walletRequestStr = JsonConvert.SerializeObject(walletRequest);
                string url = "https://fispayapi.azurewebsites.net/api/Person/WalletRegistration";
                var content = await ServiceRequest(url, walletRequestStr, "Post", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<WalletResponse>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Response> SetWalletFlag(WalletRequest walletRequest)
        {
            try
            {
                var WalletFlag = new MultipartFormDataContent
                {
                    { new StringContent(walletRequest.isActivate.ToString()), "isActivate" }
                };
                string url = "https://fispayapi.azurewebsites.net/api/Person/WalletActivation";
                var content = await ServiceRequest(url, "", "Put", WalletFlag);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<Response>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Response> AddWalletAmount(AddWalletRequest addWalletRequest)
        {
            try
            {
                string walletRequestStr = JsonConvert.SerializeObject(addWalletRequest);
                string url = "https://fispayapi.azurewebsites.net/api/Person/AddWalletAmount";
                var content = await ServiceRequest(url, walletRequestStr, "Post", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<Response>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Response> Pay(AddWalletRequest addWalletRequest)
        {
            try
            {
                string walletRequestStr = JsonConvert.SerializeObject(addWalletRequest);
                string url = "https://fispayapi.azurewebsites.net/api/Person/UserPayment";
                var content = await ServiceRequest(url, walletRequestStr, "Post", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<Response>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Response> UpdatePersonProfile(UpdateUserProfile personProfileData)
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Authentication/UpdatePersonProfile";
                var personProfileDataStr = new MultipartFormDataContent
                {
                    { new StringContent(personProfileData.Id), "Id" },
                    { new StringContent(personProfileData.Name), "Name" },
                    { new StringContent(personProfileData.Email), "Email" }
                };
                var content = await ServiceRequest(url, "", "Put", personProfileDataStr);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<Response>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> UpdatePwd(UpdatePwdRequest updatePwdRequest)
        {
            try
            {
                string updatePwdRequestStr = JsonConvert.SerializeObject(updatePwdRequest);
                string url = "https://fispayapi.azurewebsites.net/api/Authentication/ForgetPassword";
                var content = await ServiceRequest(url, updatePwdRequestStr, "Post", null);
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<Response>(content.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OtpResponse> UpdatePwdOtp(string Mobile)
        {
            try
            {
               string url = "https://fispayapi.azurewebsites.net/api/Authentication/UpdatePasswordOTP";
                    var content = await ServiceRequest(url, Mobile, "Get", null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<OtpResponse>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> UpdateVendorProfile(VendorProfileData vendorProfileData)
        {
            try
            {
                string vendorProfileDataStr = JsonConvert.SerializeObject(vendorProfileData);

                    string url = "https://fispayapi.azurewebsites.net/api/Authentication/UpdateVendorProfile";
                    var content = await ServiceRequest(url, vendorProfileDataStr, "Put",null);
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<Response>(content.ToString());
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
