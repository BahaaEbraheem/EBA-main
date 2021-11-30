using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class AlbumContent : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public AlbumContent(ILazyLoader loader)
        {
            Loader = loader;
        }

        public AlbumContent()
        {

        }
        /// <summary>
        /// اسم الصورة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }

        /// <summary>
        ///  معرف الألبوم 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Album")]
        public int? AlbumId { get; set; }

        private Album _Album;

        [PropFlag("FK_REF")]
        public Album Album
        {
            get => Loader.Load(this, ref _Album);
            set => _Album = value;
        }
        /// <summary>
        /// مسار الصورة أو الفيديو
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// هل هو YouTube
        /// </summary>
        public bool? IsYoutube { get; set; }
        /// <summary>
        /// وصف 
        /// </summary>
        public string Description_Ar { get; set; }

        /// <summary>
        /// تاريخ انشاء  
        /// </summary>
        [DisplayName("Created Date")]

        public string CreatedDate { get; set; }


    }
}
