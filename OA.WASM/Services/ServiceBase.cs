using AutoMapper.QueryableExtensions.Impl;
using MatBlazor;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OA.Domain;
using OA.Domin;
using OA.Domin.DataFilter;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using OA.WASM.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services
{
    public class ServiceBase<T> where T: class
    {
        protected readonly HttpClient httpClient;
        protected string endpoint;

        public ServiceBase(HttpClient httpClient, string endpoint)
        {
            this.httpClient = httpClient;
            this.endpoint = "api/" + endpoint;

        }

        public virtual async Task<PagedResponse<T>> Get(RequestParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string> {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
            };

            if (pagingParameters.FilterParams != null)
            {
                int i = 0;
                foreach (var filter in pagingParameters.FilterParams)
                {
                    queryStringParam.Add("FilterParams["+ i +"].ColumnName", filter.ColumnName);
                    queryStringParam.Add("FilterParams["+ i +"].FilterValue", filter.FilterValue);
                    queryStringParam.Add("FilterParams["+ i +"].FilterOption", filter.FilterOption.ToString());

                    i++;
                }
                queryStringParam.Add("Gather", pagingParameters.Gather.ToString());
            }

            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(endpoint, queryStringParam));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var pagedResponce = new PagedResponse<T>
            {
                Items = JsonConvert.DeserializeObject<List<T>>(content),
                PagingData = JsonConvert.DeserializeObject<PagingMetaData>(response.Headers.GetValues("X-Pagination").First())
            };

            return pagedResponce;
        }

        public async Task<List<IndexData>> IndexGet()
        {
            var response = await httpClient.GetAsync($"{endpoint}/IndexGet");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var items = JsonConvert.DeserializeObject<List<IndexData>>(content);
            return items;
        }

        public async Task<T> Get(int id)
        {
            return await httpClient.GetJsonAsync<T>($"{endpoint}/{id}");
        }

        public async Task<Response<T>> Update(T item)
        {
            var response =  await httpClient.PutAsJsonAsync(endpoint, item);

            return await response.Content.ReadFromJsonAsync<Response<T>>();
        }

        public async Task<Response<T>> Create(T item)
        {
            var response = await httpClient.PostAsJsonAsync(endpoint, item);

            return await response.Content.ReadFromJsonAsync<Response<T>>();

        }

        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync($"{endpoint}/{id}");
        }

        public async Task<byte[]> Export(ExportRequest exportRequest)
        {
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("ar-SY"));
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/Export", exportRequest);

            var bytes = await response.Content.ReadAsByteArrayAsync();

            return bytes;
        }

    }
}
