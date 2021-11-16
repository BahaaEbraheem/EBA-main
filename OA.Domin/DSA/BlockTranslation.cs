using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class BlockTranslation : BaseEntity
    {

        public BlockTranslation()
        {

        }

        private readonly ILazyLoader LazyLoader;
        public BlockTranslation(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }

        private Language _Language;

        [PropFlag("FK_REF")]
        public Language Language
        {
            get => LazyLoader.Load(this, ref _Language);
            set => _Language = value;
        }
        [PropFlag("FK")]
        [DisplayName("Block")]
        public int BlockId { get; set; }

        private Block _Block;

        [PropFlag("FK_REF")]
        public virtual Block Block
        { 
            get => LazyLoader.Load(this, ref _Block);
            set => _Block = value;
        }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

    }
}
