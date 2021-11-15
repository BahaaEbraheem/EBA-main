using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class AttachmentsServices : ServiceBase<Attachment>
    {
        public AttachmentsServices(HttpClient client) : base(client, "Attachments")
        {

        }


        public async Task<IEnumerable<Attachment>> GetItemAttachments(string refName, int refId)
        {

            var response = await httpClient.GetAsync($"{endpoint}/GetItemAttachments/{refName}/{refId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Attachment>>(content);
        }
    }
}
