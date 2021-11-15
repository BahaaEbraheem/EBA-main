using Newtonsoft.Json;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Upload
{
    public class UploadService : IUploadService
    {

        private readonly HttpClient httpClient;
        private readonly string endpoint;

        public UploadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.endpoint = "api/Upload";
        }

        public async Task<string> UploadProfilePic(ProfilePicRequest profilePicRequest)
        {

            var response = await httpClient.PostAsJsonAsync($"{endpoint}/UploadProfilePic", profilePicRequest);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<string>>(content);

            if (result.HasErrors)
                return "";

            var path = Path.Combine(httpClient.BaseAddress.ToString(), result.Result);
            return path;

        } 

    }
}
