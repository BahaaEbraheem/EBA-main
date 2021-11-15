using MatBlazor;
using Newtonsoft.Json;
using OA.Domin;
using OA.Domin.Reporting;
using OA.Domin.Reporting.TemplateReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Reporting
{
    public class ReportingService : IReportingService
    {
        protected readonly HttpClient httpClient;
        protected string endpoint;

        public ReportingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.endpoint = "api/Reporting";
        }

        public async Task<IEnumerable<ReportableTable>> GetReportableTables()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetReportableTables");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ReportableTable>>(content);

            return result;

        }

        public async Task<ReportableTable> CreateReportableTable(ReportableTable reportableTable)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/CreateReportableTable", reportableTable);
            return await response.Content.ReadFromJsonAsync<ReportableTable>();

        }

        public async Task<IEnumerable<ReportTemplate>> GetTableTemplates(int reportableTableId)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetTableTemplates/{reportableTableId}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ReportTemplate>>(content);

            return result;
        }

        public async Task<ReportTemplate> CreateReportTemplate(ReportTemplate reportTemplate)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/CreateReportTemplate", reportTemplate);
            return await response.Content.ReadFromJsonAsync<ReportTemplate>();
        }

        public async Task<ReportHeader> SaveReportHeader(ReportHeader reportHeader)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/SaveReportHeader", reportHeader);
            return await response.Content.ReadFromJsonAsync<ReportHeader>();
        }

        public async Task<ReportTemplate> GetReportTemplate(int id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetReportTemplate/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReportTemplate>(content);

            return result;
        }

        public async Task DeleteReportHeader(int id)
        {
            await httpClient.DeleteAsync($"{endpoint}/DeleteReportHeader/{id}");
        }

        public async Task<ReportTemplate> SaveReportFields(ReportTemplate reportTemplate)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/SaveReportFields", reportTemplate);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReportTemplate>(content);

            return result;
        }

        public async Task DeleteReportTemplate(int id)
        {
            var response = await httpClient.DeleteAsync($"{endpoint}/DeleteReportTemplate/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task ChangeTemplateState(int id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/ChangeTemplateState/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<IndexData>> GetReportTextTemplates()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetReportTextTemplates");
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<IndexData>>(content);

            return result;

        }

        public async Task<ReportTextTemplate> GetReportTextTemplate(int id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetReportTextTemplate/{id}");
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ReportTextTemplate>(content);

            return result;
        }

        public async Task SaveReportTemplate(ReportTextTemplate reportTextTemplate)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/SaveReportTemplate", reportTextTemplate);
            response.EnsureSuccessStatusCode();

        }
    }
}
