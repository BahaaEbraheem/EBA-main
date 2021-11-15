using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Settings
{
    public class FileSettings
    {

        public static Dictionary<string, string> FileMemeTypes = new Dictionary<string, string>()
        {
            {"Exel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            {"Word", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"}, //For OpenXml Generated Word Docs
            {"Pdf", "application/pdf" }
        };

        public static Dictionary<string, List<string>> MimeTypes = new Dictionary<string, List<string>>()
        {
            { "Image", new List<string>(){
                            "image/png",
                            "image/webp",
                            "image/bmp",
                            "image/gif",
                            "image/jpeg",
                            "image/vnd.microsoft.icon",
                            "image/tiff",
                        }
            },
            { "ImageUpload", new List<string>(){
                            "image/png",
                            "image/webp",
                            "image/bmp",
                            "image/jpeg",
                        }
            },
            {"Pdf", new List<string>{
                            "application/pdf" 
                        } 
            },
            { "HTML", new List<string>{
                            "text/html"
                        }
            }
        };

    }

    public class FileValidation
    {
        public List<string> AllowedTypes { get; set; }

        public long MaxSize { get; set; }
    }
}
