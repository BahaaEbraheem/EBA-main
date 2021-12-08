using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin
{
    [NotMapped]
    public static class StaticIndexes
    {

        public enum Emirate : byte
        {

            AbuDhabi = 1,
            Dubai = 2,
            Ajman=3,
            Sharjah=4,
            Fujairah=5,
            RasAlKhaimah=6,
            UmmAlQuwain = 7
        }
        //public static Dictionary<string, string> Emirate = new Dictionary<string, string>
        //{
        //    {"أبوظبي", "أبوظبي" },
        //    {"دبي", "دبي" },
        //     {"الشارقة", "الشارقة" },
        //      {"عجمان", "عجمان" },
        //       {"إم القيوين", "إم القيوين" }, 
        //       {"رأس الخيمة", "رأس الخيمة" },
        //       {"الفجيرة", "الفجيرة" },
          
        //};
        //public static Dictionary<string, string> LightState = new Dictionary<string, string>
        //{
        //    {"مضاء ليلاً", "مضاء ليلاً" },
        //    {"غير مضاء ليلاً", "غير مضاء ليلاً" }
        //};

        public enum LightState : byte
        {

            LitAtNight = 1,
            NotLitAtLight = 2
        }
        public enum StadiumState : byte
        {

            Available = 1,
            Busy = 2
        }

        //public static Dictionary<string, string> StadiumState = new Dictionary<string, string>
        //{
        //    {"متوفر", "متوفر" },
        //    {"مشغول", "مشغول" }
        //};
        //public enum MemberType : byte
        //{

        //    MemberOfCommission = 1,
        //    MemberOfAdministrationBoard= 2
        //}

        //public static Dictionary<string, string> MemberType = new Dictionary<string, string>
        //{
        //    {"عضو لجنة", "عضو لجنة" },
        //    {"عضو مجلس إدارة" , "عضو مجلس إدارة" }
        //};
        public static Dictionary<string, string> Gender = new Dictionary<string, string>
        {
            {"Male", "Male" },
            {"Female", "Female" }
        };
        //public enum Gender : byte
        //{

        //    Male = 1,
        //    Female = 2
        //}
        //public static Dictionary<string, string> ClubType = new Dictionary<string, string>
        //{
        //    {"نادي", "نادي" },
        //    {"مركز تدريب", "مركز تدريب" }
        //};
        public enum ClubType : byte
        {

            Club = 1,
            TrainingCenter = 2
        }
        public enum CourseType : byte
        {

            Local = 1,
            International = 2,
            Asian=3,
            Olympic=4,
            Arabic=5


        }
        //public static Dictionary<string, string> Type = new Dictionary<string, string>
        //{
        //    {"محلي", "محلي" },
        //    {"دولي", "دولي" },
        //    {"آسيوي", "آسيوي" },
        //    {"أولمبي", "أولمبي" },
        //    {"عربي", "عربي" },
            
        //};
        //public static Dictionary<string, string> CourseType = new Dictionary<string, string>
        //{
        //    {"في الموقع", "في الموقع" },
        //    {"مخفية", "مخفية" }
        //};
        public enum CoursePosition : byte
        {

            InSite = 1,
            Hiden = 2
        }
        public enum Result : byte
        {

            FirstTeam = 1 ,
            SecondTeam = 2 ,
            TeamsAreEqual=3 ,
            FirstTeamWithdrawal=4 ,
            SecondTeamWithdrawal = 5


        }
        //public static Dictionary<string, string> Result = new Dictionary<string, string>
        //{
        //    {"الفريق الأول", "الفريق الأول" },
        //    {"الفريق الثاني", "الفريق الثاني" },
        //     {"تعادل", "تعادل" },
        //    {"انسحاب الفريق الأول", "انسحاب الفريق الأول" },
        //     {"انسحاب الفريق الثاني", "انسحاب الفريق الثاني" },

        //};
        //public static Dictionary<string, string> AlbumType = new Dictionary<string, string>
        //{
        //    {"ألبوم صور ", "ألبوم صور" },
        //    {"ألبوم فيديو ", "ألبوم فيديو" },

        //};
        public enum AlbumType : byte
        {

            PhotoAlbum = 1,
            VideoAlbum = 2
        }
        //public static Dictionary<string, string> AlbumCategory = new Dictionary<string, string>
        //{
        //    {"General", "General" },
        //    {"TriningCourse", "TriningCourse" }
        //};
        public enum AlbumCategory : byte
        {

            General = 1,
            TriningCourse = 2
        }








        public static Dictionary<string, string> BlockCategoryTypes = new Dictionary<string, string>
        {
            { "Main Page", "Main Page" },
            { "Images Galleary", "Images Galleary"},
            { "Videos Galleary", "Videos Galleary"},
            { "Blog", "Blog"},
            { "Link", "Link"}
        };

        public static Dictionary<string, string> PageTypes = new Dictionary<string, string>
        {
            { "Call Us", "Call Us" },
            { "Normal Page", "Normal Page" },
        };

        public static Dictionary<string, string> MenueTypes = new Dictionary<string, string>
        {
            { "Page", "Page"},
            { "DropDown Menu", "DropDown Menu"},
            { "External Link", " External Link"},
            { "Enternal Link", " Enternal Link"},
            { "File", "File"},
        };


        //public static Dictionary<string, string> Language = new Dictionary<string, string>
        //{
        //    { "AR", "Arabic"},
        //    { "EN", "English"}
        //};

        public static Dictionary<string, string> ArticleCategoryTypes = new Dictionary<string, string>
        {
            { "News", "News"},
            { "Sport", "Sport"}
        };

        public static Dictionary<string, string> AttachmentTypes = new Dictionary<string, string>
        {
            { "Image", "Image" },
            { "Video", "Video"},
            { "File", "File"}
        };

        public static Dictionary<string, string> AttachemntReferences = new Dictionary<string, string>
        {
            { nameof(New), "New" },
            { nameof(Block), "Block" },
            { nameof(Event), "Event" },
            { nameof(Menue), "Menu"},
            { nameof(Page), "Page"},
            { nameof(Article), "Article"}
        };

    }
}
