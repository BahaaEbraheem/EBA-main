using AutoMapper.Internal;
using Newtonsoft.Json;
using OA.Domin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Settings
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly HttpClient httpClient;
        private readonly string endpoint;
        public AppSettingsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            endpoint = "api/AppSettings";
        }

        public async Task<Dictionary<string, string>> GetAppSettings()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetAppSettings");
            var content = await response.Content.ReadAsStringAsync();

            var resultList = JsonConvert.DeserializeObject<IEnumerable<AppSetting>>(content);

            var resultDic = new Dictionary<string, string>();
            resultList.ForAll(s => resultDic.Add(s.Key, s.Value));

            return resultDic;
        }

        public async Task<Dictionary<string, string>> SetAppSettings(Dictionary<string, string> appSettingsDic)
        {
            List<AppSetting> appSettings = new List<AppSetting>();
            appSettingsDic.ForAll(a => appSettings.Add(new AppSetting() { Key = a.Key, Value = a.Value }));

            var response = await httpClient.PostAsJsonAsync($"{endpoint}/SetAppSettings", appSettings);
            var content = await response.Content.ReadAsStringAsync();

            var resultList = JsonConvert.DeserializeObject<IEnumerable<AppSetting>>(content);

            var resultDic = new Dictionary<string, string>();
            resultList.ForAll(s => resultDic.Add(s.Key, s.Value));

            return resultDic;

        }

    }
}
