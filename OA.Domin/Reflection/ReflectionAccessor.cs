using OA.Domain;
using OA.Domin.Attributes;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
//using OA.Domin.DSA.Indexes;
using OA.Domin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OA.Domin.Reflection
{
    public class ReflectionAccessor
    {
        public static Dictionary<string, string> GetEntityTypes()
        {
            return new Dictionary<string, string> {
                { nameof(Block), "Block" },
                { nameof(BlockCategory), "Block Category" },
                { nameof(BlockTranslation), "Block Translation" },
                { nameof(Event), "Event" },
                { nameof(EventCategory), "Event Category" },
                { nameof(EventCategoryTranslation), "Event Category Translation" },
                { nameof(EventTranslation), "Event Translation" },

                { nameof(New), "News" },
                { nameof(NewCategory), "New Category" },
                { nameof(NewCategoryTranslation), "New Category Translation" },
                { nameof(NewTranslation), "New Translation" },

                { nameof(Page), "Page" },
                { nameof(PageTranslation), "Page Translation" },
                { nameof(Menue), "Menue" },
                { nameof(MenueCategory), "Menue Category" },
                { nameof(MenueTranslation), "Menue Translation" },
                { nameof(Article), "Article" },
                { nameof(ArticleTranslation), "Article Translation" },
                { nameof(ArticleCategory), "Article Category" },
                { nameof(Attachment), "Attachment" },


                { nameof(Language), "Language" },
                { nameof(Nationality), "Nationality" },
                { nameof(Adjective), "Adjective" },
                { nameof(AgeCategory), "AgeCategory" },
                { nameof(ArrowType), "ArrowType" },
                
                { nameof(ChampionshipRanking), "ChampionshipRanking" },
                 { nameof(TrainingCourseType), "TrainingCourseType" },
            };

            //typeof(BaseEntity).GetNestedTypes();
        }

        public static Dictionary<string, Type> EntityTypes = new Dictionary<string, Type>()
        {
            { nameof(Block),  typeof(Block) },
            { nameof(BlockCategory),  typeof(BlockCategory) },
            { nameof(BlockTranslation), typeof(BlockTranslation) },
            { nameof(Event), typeof(Event) },
            { nameof(EventCategory), typeof(EventCategory) },
            { nameof(EventCategoryTranslation), typeof(EventCategoryTranslation) },
            { nameof(EventTranslation), typeof(EventTranslation) },

            { nameof(New), typeof(New) },
            { nameof(NewCategory), typeof(NewCategory) },
            { nameof(NewCategoryTranslation), typeof(NewCategoryTranslation) },
            { nameof(NewTranslation), typeof(NewTranslation) },

            { nameof(Page), typeof(Page) },
            { nameof(PageTranslation),typeof(PageTranslation) },
            { nameof(Menue), typeof(Menue) },
            { nameof(MenueCategory), typeof(MenueCategory) },
            { nameof(MenueTranslation), typeof(MenueTranslation) },
            { nameof(Article), typeof(Article) },
            { nameof(ArticleTranslation), typeof(ArticleTranslation) },
            { nameof(ArticleCategory), typeof(ArticleCategory) },
            { nameof(Attachment), typeof(Attachment) },



            { nameof(Language), typeof(Language) },
            { nameof(Nationality), typeof(Nationality) },
            { nameof(Adjective), typeof(Adjective) },
            { nameof(AgeCategory), typeof(AgeCategory) },
            { nameof(ArrowType), typeof(ArrowType) },
            { nameof(ChampionshipRanking), typeof(ChampionshipRanking) },
            { nameof(TrainingCourseType), typeof(TrainingCourseType) },
          

            { nameof(ExceptionLog), typeof(ExceptionLog)}
        };

        public static Type GetType(string name, string nameSpace = "OA.Domin")
        {
            if (EntityTypes.Keys.Contains(name))
                return EntityTypes[name];

            return null;
            //var asemblies = AppDomain.CurrentDomain.GetAssemblies();
            //foreach (var assymbly in asemblies)
            //{
            //    var type = assymbly.GetType($"{nameSpace}.{name}");
            //    if (type != null)
            //        return type;
            //}
            //return null;
        }

        public static object GetPropertyValue(string typeName, string propName, object prop)
        {
            var getter = DynamicModuleLambdaCompiler.GetPropertyGetter(typeName, propName);

            return getter(prop);
        }

        public static class FastActivator<T> where T : new()
        {
            public static readonly Func<T> Create = DynamicModuleLambdaCompiler.GenerateFactory<T>();

            public static T SeedCreate(int i)
            {
                var t = Create();

                if (!(t is BaseEntity))
                    return t;

                var props = t.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var prop in props)
                {
                    if (AttributeAccessor.IsForeginKey(prop) || AttributeAccessor.IsForeginKeyRef(prop) || AttributeAccessor.IsForeginKeyRefColl(prop) || !prop.CanWrite)
                        continue;
                    
                    var propType = prop.PropertyType;

                    if (propType == typeof(int) || propType == typeof(int?))
                        prop.SetValue(t, i);
                    else if (propType == typeof(DateTime) || propType == typeof(DateTime?))
                        prop.SetValue(t, DateTime.Now);
                    else if(propType == typeof(string))
                        prop.SetValue(t, $"Seed_{i}__O-o");
                }

                return t;
            }

        }


    }
}
