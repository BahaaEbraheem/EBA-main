using OA.Domin;
using OA.Domin.Reporting;
using OA.Domin.Reporting.TemplateReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Reporting
{
    public interface IReportingService
    {
        Task<IEnumerable<ReportableTable>> GetReportableTables();

        Task<ReportableTable> CreateReportableTable(ReportableTable reportableTable);

        Task<IEnumerable<ReportTemplate>> GetTableTemplates(int reportableTableId);

        Task<ReportTemplate> CreateReportTemplate(ReportTemplate reportTemplate);

        Task<ReportHeader> SaveReportHeader(ReportHeader reportHeader);

        Task<ReportTemplate> GetReportTemplate(int id);

        Task DeleteReportHeader(int id);

        Task<ReportTemplate> SaveReportFields(ReportTemplate reportTemplate);

        Task DeleteReportTemplate(int id);

        Task ChangeTemplateState(int id);

        Task<IEnumerable<IndexData>> GetReportTextTemplates();

        Task<ReportTextTemplate> GetReportTextTemplate(int id);

        Task SaveReportTemplate(ReportTextTemplate reportTextTemplate);

    }
}
