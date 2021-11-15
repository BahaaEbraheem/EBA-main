using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.ComponentFeatures
{
    public class Theme
    {
        public string MainColor { get; set; }
        public string SecondaryColor { get; set; }
        public string MainBackground { get; set; }
        public string SecondaryBackground { get; set; }
        public string Direction { get; set; }
        public string Align { get; set; }

        public Theme()
        {
            MainColor = "#6f6565";
            SecondaryColor = "gray";

            MainBackground = "#00828F";
            SecondaryBackground = "white";

            Direction = "ltr";
            Align = "left";
        }

    }
}
