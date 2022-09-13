using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using Newtonsoft.Json;

namespace fisPayApp.Services
{
    public class PdfService : IPdfCreate
    {
        public async Task<string> getPdf(string from, string to)
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Person/GetPassbookHistoryAsync/";
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    var httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    var client = new HttpClient(httpClientHandler);
                    if (!string.IsNullOrWhiteSpace(App.Token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                    }
                    HttpResponseMessage response = null;
                    var requesturl = url + "/" + from + "/" + to;
                    response = await client.GetAsync(requesturl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content= await response.Content.ReadAsStringAsync();
                        if (content != null)
                        {
                            content = content.Replace("\"", string.Empty);
                            var bytearray = Convert.FromBase64String(content);
                            string fileName = "Statement.pdf";
                            string epath = App.FilePath;
                            String filename_initial = Path.Combine(epath, fileName);
                            String filename_current = filename_initial;
                            int count = 0;
                            while (File.Exists(filename_current))
                            {
                                count++;
                                filename_current = Path.GetDirectoryName(filename_initial)
                                                 + Path.DirectorySeparatorChar
                                                 + Path.GetFileNameWithoutExtension(filename_initial)
                                                 + count.ToString()
                                                 + Path.GetExtension(filename_initial);
                            }
                            File.WriteAllBytes(filename_current, bytearray);
                            string sucessmsg = "File Downloaded At : " + filename_current;
                            Validation.toastmsg(sucessmsg, "L", 18);
                            return "Success";    
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Validation.toastmsg("No Connection", "S", 18);
                    return null;
                }  
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<TxnListResponse> getTXN()
        {
            try
            {
                string url = "https://fispayapi.azurewebsites.net/api/Person/GetWalletHistoryByUserId";
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    var httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    var client = new HttpClient(httpClientHandler);
                    if (!string.IsNullOrWhiteSpace(App.Token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                    }
                    HttpResponseMessage response = null;
                    response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (content != null)
                        {
                            return JsonConvert.DeserializeObject<TxnListResponse>(content.ToString());
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Validation.toastmsg("No Connection", "S", 18);
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
