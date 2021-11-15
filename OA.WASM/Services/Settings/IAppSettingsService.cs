using OA.Domin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Settings
{
    public interface IAppSettingsService
    {
        Task<Dictionary<string,string>> GetAppSettings();

        Task<Dictionary<string, string>> SetAppSettings(Dictionary<string, string> appSettingsDic);

    }
}
