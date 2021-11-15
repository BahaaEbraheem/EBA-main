using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin;
using OA.Domin.Attributes;
using OA.Domin.ComponentFeatures;
using OA.Domin.DataFilter;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class GridFilter<T> : ComponentBase
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; } 

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Theme Theme { get; set; }

        [Parameter]
        public EventCallback<IEnumerable<FilterParams>> SearchSubmit { get; set; }

        [Parameter]
        public EventCallback<string> GetIndexData { get; set; }

        public List<PropertyInfo> Properties { get; set; } = new List<PropertyInfo>();

        public Dictionary<string, string> PropNames { get; set; } = new Dictionary<string, string>();

        public Array Operators { get; set; }

        public Dictionary<string, string> TypeOperator { get; set; } = new Dictionary<string, string>();

        public FilterParams Filter { get; set; } = new FilterParams();

        public List<FilterParams> Filters { get; set; } = new List<FilterParams>();

        public string FilterType { get; set; }

        public string Gather { get; set; } = "AND";

        public List<IndexData> IndexDatas { get; set; } = new List<IndexData>();

        public Dictionary<string, List<IndexData>> IndexDataCache { get; set; } = new Dictionary<string, List<IndexData>>();

        protected override void OnInitialized()
        {
            var allProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var prop in allProps)
                if (!AttributeAccessor.IsForeginKeyRef(prop) && !AttributeAccessor.IsForeginKeyRefColl(prop) && !AttributeAccessor.IsIgnored(prop))
                {
                    var name = AttributeAccessor.GetDisplayNameAttr(prop);
                    PropNames.Add(prop.Name, name);
                }
                    

            Operators = Enum.GetValues(typeof(FilterOptions));
            
        }

        public async Task SetFilterType(string CollName)
        {
            Filter.ColumnName = CollName;

            var prop = typeof(T).GetProperty(CollName);
            var propType = typeof(T).GetProperty(CollName).PropertyType;

            if (AttributeAccessor.IsForeginKey(prop))
            {
                FilterType = "FK_REF";
                if (prop.Name.EndsWith("Id"))
                {
                    var IndexName = prop.Name.Substring(0, prop.Name.Length - 2);

                    if (IndexDataCache.ContainsKey(IndexName))
                        IndexDatas = IndexDataCache[IndexName];
                    else
                    {
                        await GetIndexData.InvokeAsync(IndexName);
                        IndexDataCache[IndexName] = IndexDatas;
                    }
                }

                propType = typeof(object);
            }
            else
            {
                if (propType == typeof(int) || propType == typeof(int?) || propType == typeof(decimal) || propType == typeof(decimal?))
                    FilterType = "INT";
                else if (propType == typeof(DateTime) || propType == typeof(DateTime?))
                    FilterType = "DATETIME";
                else if (propType == typeof(bool) || propType == typeof(bool?))
                    FilterType = "BOOLEAN";
                else
                    FilterType = "STRING";
            }

            TypeOperator = TypeOperators.GetTypeOperators(propType);

        }


        public string GetIndexValue(string val)
        {
            var valId = Convert.ToInt32(val);
            return IndexDatas.Where(id => id.Id == valId).FirstOrDefault().Name;
        }

        public void SetGather(int g)
        {
            Gather = (g == 0) ? "AND" : "OR";
            StateHasChanged();
        }

        public void AddFilter()
        {
            Filters.Add(Filter);
            Filter = new FilterParams();
        }

        public void RemoveFilter(FilterParams filter)
        {
            Filters.Remove(filter);
        }

        public async Task ClearFilters()
        {
            Filters.Clear();
            await Search();
        }

        public async Task Search()
        {
            await SearchSubmit.InvokeAsync(Filters);
        }

    }
}
