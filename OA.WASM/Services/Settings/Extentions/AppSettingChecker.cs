using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Settings.Extentions
{
    public static class AppSettingChecker
    {

        public static bool Check(this Dictionary<string, string> appSettings, string key, string val)
        {

            return (!appSettings.ContainsKey(key) || (appSettings.ContainsKey(key) && appSettings[key] == val));
        }

    }
}
