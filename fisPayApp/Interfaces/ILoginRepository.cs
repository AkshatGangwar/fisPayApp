using fisPayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Interfaces
{
    public interface ILoginRepository
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<OtpResponse> UpdatePwdOtp(string Mobile);
        Task<OtpResponse> RegistrationOtp(string Mobile);
        Task<Response> RegisterVendor(VendorProfileData vendorProfileData);
        Task<Response> RegisterPerson(PersonProfileData personProfileData);
        Task<Response> UpdateVendorProfile(VendorProfileData vendorProfileData);
        Task<Response> UpdatePersonProfile(UpdateUserProfile personProfileData);
        Task<Response> UpdatePwd(UpdatePwdRequest updatePwdRequest);
        Task<WalletResponse> ActivateWallet(WalletRequest walletRequest);
        Task<Response> SetWalletFlag(WalletRequest walletRequest);
        Task<Response> AddWalletAmount(AddWalletRequest addWalletRequest);
        Task<PersonProfileResponse> GetPersonProfile(string UserID);
        Task<VendorProfileResponse> GetVendorProfile(string UserID);
        Task<StoreResponse> GetStoreList(string City);
        Task<Response> Logoff(string UserID);
        Task<UserResponse> GetUserName(string ID);
    }
}
