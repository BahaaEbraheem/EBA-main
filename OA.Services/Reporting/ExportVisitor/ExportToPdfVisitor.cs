using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace OA.Services.Reporting.ExportVisitor
{
    public class ExportToPdfVisitor : IExportVisitor
    {
        public byte[] VisitDataList<T>(ExportableDataList<T> data)
        {
            var dataList = data.List;
            var fields = data.Fields;
            var headers = data.Headers;

            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 20, 20);

            try
            {
                //using memory stream to use it in response
                MemoryStream ms = new MemoryStream();
                //itextsharp pdf writer 
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                //_events e = new _events();
                //writer.PageEvent = e;

                document.Open();
                //document.NewPage();

                //Get The Font Form Environment Variable
                string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
                BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);

                //Define Fonts
                Font labelFont = new Font(basefont, 14, Font.NORMAL, BaseColor.DARK_GRAY);
                Font rowFont = new Font(basefont, 10, Font.NORMAL, BaseColor.DARK_GRAY);
                Font headerFont = new Font(basefont, 11, Font.BOLD, BaseColor.DARK_GRAY);
                //Font reportHeaderFont = new Font(basefont, 11, Font.BOLD, BaseColor.DARK_GRAY);

                //Headers table
                var headersTable = new PdfPTable(fields.Count);
                headersTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                //Add Report Headers
                foreach (var header in headers)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(header, labelFont));
                    headerCell.Colspan = fields.Count;
                    //hCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    headerCell.BorderColor = BaseColor.WHITE;
                    headerCell.FixedHeight = 30f;

                    headersTable.AddCell(headerCell);
                }
                PdfPCell spaceCell = new PdfPCell(new Phrase("", headerFont));
                spaceCell.Colspan = fields.Count;
                spaceCell.BorderColor = BaseColor.WHITE;
                spaceCell.MinimumHeight = 30f;
                headersTable.AddCell(spaceCell);


                document.Add(headersTable);


                //Create Data Table
                var table = new PdfPTable(fields.Count);
                //set pdf file direction // depend on culture
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                //data table header
                foreach (var field in fields)
                {
                    PdfPCell hCell = new PdfPCell(new Phrase(10, field.Value, headerFont));
                    hCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    hCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    hCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    hCell.BorderColor = BaseColor.GRAY;
                    hCell.FixedHeight = 40f;

                    table.AddCell(hCell);
                }

                //[TODO]: set header on all apages

                int count = dataList.First().Value.Count();
                //List Data
                for (int i = 0; i < count; i++)
                {
                    foreach (var field in fields)
                    {
                        var fieldData = dataList[field.Key];
                        var value = (fieldData[i] != null) ? fieldData[i].ToString() : "";

                        PdfPCell rCell = new PdfPCell(new Phrase(10, value, rowFont));
                        rCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        rCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        rCell.BorderColor = BaseColor.LIGHT_GRAY;
                        rCell.FixedHeight = 40f;

                        table.AddCell(rCell);
                    }
                }

                document.Add(table);

                document.Close();
                ms.Close();

                var content = ms.ToArray();

                return content;


            }
            catch (DocumentException)
            {
                //this.Message = de.Message;
                return new byte[0];
            }
            catch (IOException)
            {
                //this.Message = ioe.Message;
                return new byte[0];
            }

        }

        public byte[] VisitTemplate(ExportableTemplate templateData)
        {

            throw new NotImplementedException();

            //Document document = new Document(PageSize.TABLOID, 10, 10, 20, 20);

            //try
            //{
            //    //using memory stream to use it in response
            //    MemoryStream ms = new MemoryStream();
            //    //itextsharp pdf writer 
            //    PdfWriter writer = PdfWriter.GetInstance(document, ms);

            //    //_events e = new _events();
            //    //writer.PageEvent = e;

            //    string TemplateContent = templateData.Template;
            //    TemplateContent = TemplateContent.Replace("<br>", "<br></br>");

            //    string TemplateCss = "";

            //    document.Open();
            //    //document.NewPage();

            //    //Get The Font Form Environment Variable
            //    //string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\arial.ttf";
            //    string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
            //    //string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\arabtype.ttf";

            //    BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);

            //    Font bodyFont = new Font(basefont);


            //    PdfPTable table = new PdfPTable(1);
            //    PdfPCell cell = new PdfPCell();
            //    cell.Border = Rectangle.NO_BORDER;
            //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            //    foreach (var e in XMLWorkerHelper.ParseToElementList(TemplateContent, TemplateCss))
            //    {
            //       foreach (var c in e.Chunks)
            //        {
            //            c.Font = bodyFont;
            //        }

            //        cell.AddElement(e);
            //    }
            //    table.AddCell(cell);
            //    document.Add(table);

            //    document.Close();
            //    ms.Close();

            //    var bytes = ms.ToArray();

            //    return bytes;


            //}
            //catch (DocumentException)
            //{
            //    //this.Message = de.Message;
            //    return new byte[0];
            //}
            //catch (IOException)
            //{
            //    //this.Message = ioe.Message;
            //    return new byte[0];
            //}
        }
    }

}
