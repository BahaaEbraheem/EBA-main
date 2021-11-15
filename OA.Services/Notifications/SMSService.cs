using OA.Domin.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace OA.Services.Notifications
{
    public class SMSService : ISMSService
    {
        private readonly List<SMSBulk> SMSBulks;
        private readonly IHttpClientFactory ClientFactory;

        public SMSService(List<SMSBulk> SMSBulks, IHttpClientFactory clientFactory)
        {
            this.SMSBulks = SMSBulks;
            ClientFactory = clientFactory;
        }

        public async Task SendMsg(string from, string to, string msg)
        {
            var smsBulk = GetBulk(to);

            var uri = PrepareUrl(smsBulk, from, to, msg);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var client = ClientFactory.CreateClient();

            //var testUri = "https://services.mtnsyr.com:7443/General/MTNSERVICES/ConcatenatedSender.aspx?User=Afk292&Pass=292^AFK&From=Madarat&Gsm=963950008425&Msg=TEST6&Lang=0";
            //var testRequest = new HttpRequestMessage(HttpMethod.Get, testUri);

            _ = await client.SendAsync(request);

        }

        private SMSBulk GetBulk(string number)
        {            
            var numOperator = number.Substring(1, 2);

            foreach(var smsBulk in SMSBulks)
            {
                var bulkOperators = smsBulk.Operators.Split(",");
                if (Array.Exists(bulkOperators, el => el == numOperator))
                    return smsBulk;
            }

            return null;
        }

        private string PrepareUrl(SMSBulk smsBulk, string from, string to, string msg)
        {
            var parameters = smsBulk.Parameters;

            to = to.Substring(1, to.Length - 1);
            to = $"963{to}";

            var url = new StringBuilder(smsBulk.BaseUrl);
            url.Append("?");

            foreach (var param in parameters)
            {
                url.Append(param.Key);

                var value = param.Value;
                value = (value == "FROM") ? from : value;
                value = (value == "TO") ? to : value;
                value = (value == "MSG") ? msg : value;

                url.Append("=");
                url.Append(value);
                url.Append("&");
            }
            url.Remove(url.Length - 1, 1);

            return url.ToString();
        }

    }
}
