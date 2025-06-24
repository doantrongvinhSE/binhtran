using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TOOL_BINH_TRAN.helper;

namespace TOOL_BINH_TRAN.domain
{
    public class RegisterAppDomain
    {
        public async static Task<string> RegisterAppAsync(string cookie, string fb_dtsg, string? proxy = null)
        {
            string uid = HelperUtils.ExtractUserIdFromCookie(cookie);
            var options = new RestClientOptions("https://developers.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);

            var client = new RestClient(options);
            var request = new RestRequest("/account/step/", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://developers.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://developers.facebook.com/async/registration/dialog/?src=default");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("current_step", "registration");
            request.AddParameter("__aaid", "0");
            request.AddParameter("__user", uid);
            request.AddParameter("__a", "1");
            request.AddParameter("__req", "1");
            request.AddParameter("dpr", "1");
            request.AddParameter("__ccg", "EXCELLENT");
            request.AddParameter("fb_dtsg", fb_dtsg);
            RestResponse response = await client.ExecuteAsync(request);

            string content = response.Content ?? string.Empty;
            if (response.IsSuccessful && !string.IsNullOrWhiteSpace(content) && content.Contains("success"))
            {
                // Kiểm tra xem phản hồi có chứa thông tin thành công hay không
                if (content.Contains("accounts_verification"))
                {
                    return "Đăng ký ứng dụng thành công.";

                }
                else
                {
                    return "Đăng ký ứng dụng thất bại.";

                }
            }
            else
            {
                return "Đăng ký ứng dụng thất bại.";
            }

        }

        public static async Task<string> sendEmail(string cookie, string fb_dtsg, string email, string? proxy = null)
        {
            string uid = HelperUtils.ExtractUserIdFromCookie(cookie);

            var options = new RestClientOptions("https://developers.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);

            var client = new RestClient(options);
            var request = new RestRequest($"/developer/profile_email/send_confirmation_email/?email={email}&referrer=DeveloperRegistrationEmailContactUpdateDialog", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://developers.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://developers.facebook.com/async/registration/dialog/?src=default");
            request.AddHeader("sec-ch-prefers-color-scheme", "light");
            request.AddHeader("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"132\", \"Google Chrome\";v=\"132\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("__aaid", "0");
            request.AddParameter("__user", uid);
            request.AddParameter("__a", "1");
            request.AddParameter("dpr", "1");
            request.AddParameter("__ccg", "EXCELLENT");
            request.AddParameter("fb_dtsg", fb_dtsg);
            RestResponse response = await client.ExecuteAsync(request);

            try
            {
                if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content) && response.Content.Contains("success"))
                {
                    string jsData = response.Content;
                    // Loại bỏ phần for (;;);{ ... }
                    string jsonPart = jsData.Substring(jsData.IndexOf("{"));

                    // Phân tích cú pháp JSON
                    JObject jsonObject = JObject.Parse(jsonPart);

                    // Lấy giá trị "success" trong phần "payload"
                    bool success = (bool)jsonObject["payload"]["success"];


                    return success ? "Đã gửi email thành công!" : "Gửi email thất bại!.";


                }
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";

            }
                return "Lỗi gửi email";
        }


    }
}
