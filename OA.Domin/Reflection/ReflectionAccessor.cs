using OA.Domain;
using OA.Domin.Attributes;
using OA.Domin.DSA;
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
                { nameof(Page), "Page" },
                { nameof(PageTranslation), "Page Translation" },
                { nameof(Menue), "Menue" },
                { nameof(MenueCategory), "Menue Category" },
                { nameof(MenueTranslation), "Menue Translation" },
                { nameof(Article), "Article" },
                { nameof(ArticleTranslation), "Article Translation" },
                { nameof(ArticleCategory), "Article Category" },
                { nameof(Attachment), "Attachment" },

                //{ nameof(Donation), "Donation" },
                //{ nameof(Person), "Person" },
                //{ nameof(CorporateDonator), "Corporate Donator" },
                //{ nameof(PersonDonator), "Person Donator" },
                //{ nameof(Beneficiary), "Beneficiary" },
                //{ nameof(CorporateBeneficiary), "Corporate Beneficiary" },

                //{ nameof(Activity), "Activity" },
                //{ nameof(AcademicQualification), "Academic Qualification" },
                //{ nameof(JobType), "JobType" },
                //{ nameof(Governorate), "Governorate" },
                //{ nameof(City), "City" },
                //{ nameof(Nationality), "Nationality" },
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
            { nameof(Page), typeof(Page) },
            { nameof(PageTranslation),typeof(PageTranslation) },
            { nameof(Menue), typeof(Menue) },
            { nameof(MenueCategory), typeof(MenueCategory) },
            { nameof(MenueTranslation), typeof(MenueTranslation) },
            { nameof(Article), typeof(Article) },
            { nameof(ArticleTranslation), typeof(ArticleTranslation) },
            { nameof(ArticleCategory), typeof(ArticleCategory) },
            { nameof(Attachment), typeof(Attachment) },

            //{ nameof(Donation), typeof(Donation) },
            //{ nameof(Person), typeof(Person) },
            //{ nameof(CorporateDonator), typeof(CorporateDonator) },
            //{ nameof(PersonDonator), typeof(PersonDonator) },
            //{ nameof(Beneficiary), typeof(Beneficiary) },            
            //{ nameof(CorporateBeneficiary), typeof(CorporateBeneficiary) },            

            //{ nameof(Activity), typeof(Activity) },
            //{ nameof(AcademicQualification), typeof(AcademicQualification) },
            //{ nameof(JobType), typeof(JobType) },
            //{ nameof(Governorate), typeof(Governorate) },
            //{ nameof(City), typeof(City) },
            //{ nameof(Nationality), typeof(Nationality) },
            //{ nameof(DonationType), typeof(DonationType) },

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
