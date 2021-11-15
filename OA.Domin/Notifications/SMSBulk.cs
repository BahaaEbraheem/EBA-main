using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Notifications
{
    [NotMapped]
    public class SMSBulk
    {
        public string Name { get; set; }

        public string BaseUrl { get; set; }

        public string Operators { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

    }
}
