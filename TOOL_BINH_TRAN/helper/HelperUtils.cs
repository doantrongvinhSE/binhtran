using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TOOL_BINH_TRAN.helper
{
    public class HelperUtils
    {
        public static string ExtractUserIdFromCookie(string cookie)
        {
            string pattern = @"c_user=(\d+);";
            Match match = Regex.Match(cookie, pattern);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }


        public async static Task<string> getFbDtsg(string cookie, string? proxy = null)
        {
            string result = "";

            try
            {
                var options = new RestClientOptions("https://www.facebook.com")
                {
                    MaxTimeout = -1,
                };

                if (proxy != null)
                {
                    ProxyHelper.SetProxy(options, proxy);
                }

                var client = new RestClient(options);
                var request = new RestRequest("/", Method.Get);
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);


                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    string pattern = @"""token"":""([^""]+?)""";
                    Regex regex = new Regex(pattern);
                    MatchCollection matches = regex.Matches(response.Content);

                    foreach (Match match in matches)
                    {
                        string token = match.Groups[1].Value;
                        if (token.Length > 40)
                        {
                            result = token;
                            break;
                        }
                    }
                }
                else
                {
                    return "Lỗi";
                }
            }
            catch
            {
                return "Lỗi";
            }

            return result;

        }


    }
}
