using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OA.Services.Reporting.ExportVisitor
{
    public class ExportToWordVisitor : IExportVisitor
    {

        
        private const int EMUPerInche = 914400;
        private const int DXAPerInche = 1440;
        private (UInt32Value, UInt32Value) TabloidPageSize = (11 * DXAPerInche, 17 * DXAPerInche);
        //private (UInt32Value, UInt32Value) NormalPageSize = (8500, 11000);

        public byte[] VisitDataList<T>(ExportableDataList<T> data)
        {
            throw new NotImplementedException();
        }

        public byte[] VisitTemplate(ExportableTemplate templateData)
        {
            string htmlValue = templateData.Template;

            var fixedHtml = $"<!DOCTYPE html> <html dir='rtl'> <head> <title></title> </head> <body> {htmlValue} </body> </html>";
            fixedHtml = fixedHtml.Replace("<table", "<table width='100%'");
            fixedHtml = fixedHtml.Replace("<td", "<td style='height:100px'");

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {                    
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        PageSize PSize = new PageSize();
                        PSize.Width = TabloidPageSize.Item1;
                        PSize.Height = TabloidPageSize.Item2 ;

                        SectionProperties SecPro = new SectionProperties();
                        SecPro.Append(PSize);

                        mainPart = package.AddMainDocumentPart();

                        DocumentProtection documentProtection = new DocumentProtection();
                        documentProtection.Edit = DocumentProtectionValues.ReadOnly;
                        documentProtection.Enforcement = true;

                        mainPart.AddNewPart<DocumentSettingsPart>();
                        mainPart.DocumentSettingsPart.Settings = new Settings();
                        mainPart.DocumentSettingsPart.Settings.AppendChild(documentProtection);

                        new Document(new Body(SecPro)).Save(mainPart);

                        //var sectionProp = new SectionProperties();
                        //var pageSetUp = new PageSetup();
                        //pageSetUp.PaperSize = 3;



                        //mainPart.Document.Body.Append(PSize);
                        //body.Append(SecPro);

                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    converter.ParseHtml(fixedHtml);

                    mainPart.Document.Save();
                }

                return generatedDocument.ToArray();
            }

        }
    }
}
