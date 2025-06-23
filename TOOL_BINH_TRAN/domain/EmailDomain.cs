using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TOOL_BINH_TRAN.helper;
using TOOL_BINH_TRAN.model;

namespace TOOL_BINH_TRAN.domain
{
    public class EmailDomain
    {
        public static async Task<List<ContactInfo>> GetAllEmailFromCookie(string cookie, string? proxy = null)
        {
            var result = new List<ContactInfo>();

            var options = new RestClientOptions("https://accountscenter.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy); // Nếu bạn dùng proxy

            var client = new RestClient(options);
            var request = new RestRequest("/personal_info/contact_points", Method.Get);
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("Cookie", cookie);

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
            {
                Console.WriteLine("❌ Không nhận được phản hồi hợp lệ.");
                return result;
            }

            string html = response.Content;

            // 1. Dò tất cả <script type="application/json">...</script>
            var matches = Regex.Matches(html, @"<script[^>]*type=['""]application/json['""][^>]*>(.*?)</script>", RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                string jsonText = match.Groups[1].Value;

                try
                {
                    var root = JObject.Parse(jsonText);

                    // 2. Dò xem JSON này có all_contact_points không
                    var tokens = root.SelectTokens("$..all_contact_points");

                    foreach (var token in tokens)
                    {
                        if (token is JArray array)
                        {
                            foreach (var cp in array)
                            {
                                string type = cp["contact_point_type"]?.ToString() ?? "";
                                if (type != "EMAIL") continue; // Chỉ lấy EMAIL

                                result.Add(new ContactInfo
                                {
                                    ContactPointType = type,
                                    NormalizedContactPoint = cp["normalized_contact_point"]?.ToString() ?? "",
                                    HasAnyPendingStatus = cp["has_any_pending_status"]?.ToObject<bool>() ?? false
                                });
                            }
                        }
                    }
                }
                catch
                {
                    // Bỏ qua nếu JSON lỗi
                }
            }

            return result;
        }
    }
}
