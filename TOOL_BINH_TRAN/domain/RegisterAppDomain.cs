using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    return "Đăng ký ứng dụng thất bại. Vui lòng kiểm tra lại.";

                }
            }
            else
            {
                return "Đăng ký ứng dụng thất bại. Vui lòng kiểm tra lại.";
            }

        }

        public async static Task<string> sendSMSCodeAction(string cookie, string fb_dtsg, string? proxy = null)
        {
            string uid = HelperUtils.ExtractUserIdFromCookie(cookie);

            var options = new RestClientOptions("https://developers.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);

            var client = new RestClient(options);
            var request = new RestRequest("/account/verify/send/?source=dev_onboarding&verification_type=code_sms", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://developers.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://developers.facebook.com/async/registration/dialog/?src=default");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("country", "VN");
            request.AddParameter("contact_point", "922778469");
            request.AddParameter("state", "1");
            request.AddParameter("used_in_registration", "true");
            request.AddParameter("__aaid", "0");
            request.AddParameter("__user", uid);
            request.AddParameter("__a", "1");
            request.AddParameter("__req", "2");
            request.AddParameter("dpr", "1");
            request.AddParameter("__ccg", "EXCELLENT");
            request.AddParameter("fb_dtsg", fb_dtsg);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
            {
                // Kiểm tra xem phản hồi có chứa thông tin thành công hay không
                if (response.Content.Contains("Vietnam"))
                {
                    return "Mã xác minh đã được gửi thành công.";
                }
                else
                {
                    return "Gửi mã xác minh thất bại. Vui lòng kiểm tra lại.";
                }
            }
            return "Gửi mã xác minh thất bại. Vui lòng kiểm tra lại.";
        }
    }
}
