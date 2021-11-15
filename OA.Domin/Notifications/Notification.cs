using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Notifications
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string ImgPath { get; set; }

        public string UserId { get; set; } 

        public bool Seen { get; set; }

    }
}
