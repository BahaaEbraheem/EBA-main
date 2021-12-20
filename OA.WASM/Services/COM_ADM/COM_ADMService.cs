//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Vml.Spreadsheet;
//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
//using Microsoft.EntityFrameworkCore.Query.Internal;
//using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.AutoMapper;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using OA.Domin.Logging;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OA.WASM.Services.COM_ADM
{
    public class COM_ADMService : ICOM_ADMService
    {
        private readonly HttpClient httpClient;
        private readonly string endpoint;

        public COM_ADMService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            endpoint = "api/COM_ADM";
        }



        //public async Task<IEnumerable<AdministrationBoard>> GetAllAdministrators()
        //{
        //    var response = await httpClient.GetAsync($"{endpoint}/GetAllAdministrators");

        //    var content = await response.Content.ReadAsStringAsync();

        //    var result = JsonConvert.DeserializeObject<IEnumerable<AdministrationBoard>>(content);

        //    return result;
        //}
        public async Task<IEnumerable<AdministrationBoardVM>> ADDCOM(AdministrationBoardVM Commission_admini_VM)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/CreateCOM", Commission_admini_VM);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<AdministrationBoardVM>>(content);

            return result;
        }
    }
}
