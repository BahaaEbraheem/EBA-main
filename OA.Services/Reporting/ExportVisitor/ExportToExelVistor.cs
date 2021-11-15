using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using OA.Domin.Attributes;
using OA.Services.Reporting.ExportVisitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace OA.Services.Reporting
{
    public class ExportToExelVistor : IExportVisitor
    {

        public byte[] VisitDataList<T>(ExportableDataList<T> data)
        {
            var dataList = data.List;
            var fields = data.Fields;

            using (var workbook = new XLWorkbook())
            {               
                var name = typeof(T).Name;
                IXLWorksheet worksheet = workbook.Worksheets.Add(name);


                int row = 1;
                int col = 1;
                //Sheet Header
                foreach (var header in data.Headers)
                {
                    worksheet.Cell(row, 1).Value = header;

                    //Megge Header Cells
                    worksheet.Range(worksheet.Cell(row, 1), worksheet.Cell(row, fields.Count)).Merge();

                    //Header Cell Style
                    worksheet.Row(row).Height = 20;
                    worksheet.Row(row).Style.Font.SetBold();
                    
                    row++;
                }
                
                //List Header
                foreach (var field in fields)
                {

                    worksheet.Cell(row, col).Value = field.Value;

                    worksheet.Cell(row, col).Style.Fill.SetBackgroundColor(XLColor.Gray);
                    worksheet.Cell(row, col).Style.Font.SetFontColor(XLColor.White);
                    worksheet.Cell(row, col).Style.Font.SetBold();
                    worksheet.Cell(row, col).Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                    worksheet.Row(row).Height = 30;

                    col++;
                }
                row++;

                int count = dataList.First().Value.Count();
                //List Data
                for (int i = 0; i < count; i++)
                {
                    col = 1;
                    foreach(var field in fields)
                    {
                        var fieldData = dataList[field.Key];
                        var value = fieldData[i];
                        worksheet.Cell(row, col).Value = (value != null) ? value.ToString() : "";

                        col++;
                    }
                    row++;
                }

                //Adjust Width
                worksheet.Columns().AdjustToContents();
                //Alignment
                worksheet.Cells().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cells().Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                //Borders
                worksheet.Cells().Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
                worksheet.Cells().Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
                worksheet.Cells().Style.Border.SetBottomBorderColor(XLColor.DarkGray);
                worksheet.Cells().Style.Border.SetTopBorderColor(XLColor.DarkGray);
                worksheet.Cells().Style.Border.SetLeftBorderColor(XLColor.DarkGray);


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }

        }

        public byte[] VisitTemplate(ExportableTemplate templateData)
        {
            throw new NotImplementedException();
        }
    }
}
