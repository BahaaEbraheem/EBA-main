using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Requests
{
    public class ProfilePicRequest
    {
        [Required]
        public string userId { get; set; }

        public RequestFileData ImgFile { get; set; }

    }
}
