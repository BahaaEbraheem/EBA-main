using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OA.DataAccess;
using OA.Domin.Attributes;
using OA.Domin.Reflection;
using OA.Domin.Reporting;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.Services.Reporting.ExportVisitor;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;
using OA.Domin.Reporting.TemplateReporting;
using OA.Domin;
using System.Text;

namespace OA.Services.Reporting
{
    public class ReportingService
    {
        private readonly AppDbContext Context;
        private readonly IStringLocalizer<CommonResources> Localizer;

        public ReportingService(AppDbContext context, IStringLocalizer<CommonResources> localizer)
        {
            this.Context = context;
            this.Localizer = localizer;
        }

        public byte[] ExportReport<T>(IEnumerable<T> data, ExportRequest exportRequest)
        {

            ExportableDataList<T> exportableData = new ExportableDataList<T>();
            exportableData.Fields = GetReportFields(exportRequest.TypeName);
            exportableData.List = PrepareData(data, exportableData.Fields);
            exportableData.Headers = GetReportHeaders(exportRequest.TypeName);

            byte[] reportBytes;
            IExportVisitor vistor;

            switch (exportRequest.ExportAs)
            {
                case "Exel":
                    vistor = new ExportToExelVistor();
                    break;
                case "Pdf":
                    vistor = new ExportToPdfVisitor();
                    break;
                case "Word":
                    vistor = new ExportToWordVisitor();
                    break;
                default:
                    vistor = new ExportToPdfVisitor();
                    break;
            }


            reportBytes = exportableData.Accept(vistor);
            return reportBytes;

        }

        public byte[] ExportTemplate(TemplateExportRequest exportRequest)
        {
            ExportableTemplate exportableTemplate = new ExportableTemplate
            {
                Template = exportRequest.Body,
                data = exportRequest.Data,
            };

            byte[] reportBytes;
            IExportVisitor visitor;

            switch (exportRequest.ExportAs)
            {
                case "Exel":
                    visitor = new ExportToExelVistor();
                    break;
                case "Pdf":
                    visitor = new ExportToPdfVisitor();
                    break;
                case "Word":
                    visitor = new ExportToWordVisitor();
                    break;
                default:
                    visitor = new ExportToPdfVisitor();
                    break;
            }

            reportBytes = exportableTemplate.Accept(visitor);

            return reportBytes;
        }

        public IEnumerable<IndexData> GetReportTextTemplates()
        {
            return Context.ReportTextTemplates.Select(r => new IndexData { Id = r.Id, Name = r.Name }).ToList();
        }

        public ReportTextTemplate GetReportTextTemplate(int id)
        {
            return Context.ReportTextTemplates.Find(id);
        }

        public void SaveReportTextTemplate(ReportTextTemplate reportTextTemplate)
        {
            var report = Context.ReportTextTemplates.Find(reportTextTemplate.Id);
            report.Content = reportTextTemplate.Content;
            Context.Entry(report).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public string GenerateHtmlTable(List<string> header, List<List<string>> rows)
        {

            var result = new StringBuilder();

            result.Append("<table>");

            result.Append("<thead>");
            result.Append("<tr>");

            foreach (var item in header)
                result.Append($"<td> {item} </td>");

            result.Append("</tr>");
            result.Append("</thead>");

            foreach (var row in rows)
            {
                result.Append("<tr>");

                foreach (var item in row)
                    result.Append($"<td> {item} </td>");

                result.Append("</tr>");
            }


            result.Append("</table>");

            return result.ToString();
        }

        public Dictionary<string, string> GetReportFields(string typeName)
        {
            Dictionary<string, string> Fields = new Dictionary<string, string>();

            var table = Context.ReportableTables.Where(t => t.TypeName == typeName).FirstOrDefault();
            if (table != null)
            {
                var template = table.ReportTemplates.Where(r => r.Status).FirstOrDefault();
                if (template != null)
                {
                    foreach (var field in template.FieldsOrder.Split(','))
                    {
                        var key = field.Split(':')[0];
                        var val = field.Split(':')[1]; // Localize
                        Fields.Add(key, Localizer[val].Value);
                    }
                    return Fields;
                }
            }

            //Default Template 
            var type = ReflectionAccessor.GetType(typeName);
            Fields = AttributeAccessor.GetPropsWithNames(type, new List<string>() { typeName });

            return Fields;
        }

        public List<string> GetReportHeaders(string typeName)
        {
            List<string> headers = new List<string>();

            var table = Context.ReportableTables.Where(t => t.TypeName == typeName).FirstOrDefault();
            if (table != null)
            {
                var template = table.ReportTemplates.Where(r => r.Status).FirstOrDefault();
                if (template != null)
                    foreach (var header in template.ReportHeaders)
                        headers.Add(header.Header);
            }

            return headers;
        }

        public Dictionary<string, List<object>> PrepareData<T>(IEnumerable<T> data, Dictionary<string, string> fields)
        {
            var list = data.ToList();

            var reportData = new Dictionary<string, List<object>>();
            foreach (var field in fields)
            {
                var fieldData = list.Select(x => GetVal(x, field.Key)).ToList();

                reportData.Add(field.Key, fieldData);
            }

            return reportData;

        }

        public object GetVal<T>(T x, string propName)
        {
            //var prop = 
            if (propName.Contains("."))
            {
                var refAttrs = propName.Substring(propName.IndexOf('.') + 1);
                var refName = propName.Split('.').First();

                var refProp = x.GetType().GetProperty(refName);
                return GetVal(refProp.GetValue(x, null), refAttrs);
            }

            if (x != null)
            {
                var prop = x.GetType().GetProperty(propName);
                return prop.GetValue(x, null);
            }
            return "";
        }



    }

}
