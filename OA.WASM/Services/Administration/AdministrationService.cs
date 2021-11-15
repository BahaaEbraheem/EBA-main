using MatBlazor;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using OA.Domin.Administration;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using OA.WASM.Services.JsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly HttpClient httpClient;
        private readonly string endpoint;

        public AdministrationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            endpoint = "api/Administration";
        }

        #region "Users Managment"

        public async Task<PagedResponse<CustomUser>> GetAllUsers(RequestParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
            };

            if (pagingParameters.FilterParams != null)
            {
                int i = 0;
                foreach (var filter in pagingParameters.FilterParams)
                {
                    queryStringParam.Add("FilterParams[" + i + "].ColumnName", filter.ColumnName);
                    queryStringParam.Add("FilterParams[" + i + "].FilterValue", filter.FilterValue);
                    queryStringParam.Add("FilterParams[" + i + "].FilterOption", filter.FilterOption.ToString());

                    i++;
                }
                queryStringParam.Add("Gather", pagingParameters.Gather.ToString());
            }

            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"{endpoint}/GetAllUsers", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();

            var pagedResponce = new PagedResponse<CustomUser>
            {
                Items = JsonConvert.DeserializeObject<List<CustomUser>>(content),
                PagingData = JsonConvert.DeserializeObject<PagingMetaData>(response.Headers.GetValues("X-Pagination").First())
            };

            return pagedResponce;
        }

        public async Task<Response<CustomUser>> AddUser(CustomUser user)
        {
            
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/CreateUser", user);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<CustomUser>>(content);

            return result;

        }

        public async Task DeleteUser(string Id)
        {
            await httpClient.DeleteAsync($"{endpoint}/DeleteUser/{Id}");
        }

        public async Task<Response<CustomUser>> UpdateUser(CustomUser user)
        {
            var response = await httpClient.PutAsJsonAsync($"{endpoint}/UpdateUser", user);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<CustomUser>>(content);

            return result;
        }

        public async Task<CustomUser> GetUser(string id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetUser/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CustomUser>(content);

            return result;
        }

        public async Task<IEnumerable<CustomUser>> GetPosibleManagers(string id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetPosibleManagers/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<CustomUser>>(content);

            return result;
        }

        public async Task<Response<ResetPasswordRequest>> ResetPassword(ResetPasswordRequest resetPassword)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/ResetPassword", resetPassword);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<ResetPasswordRequest>>(content);

            return result;
        }

        public async Task<IEnumerable<CustomUser>> IndexGetAllUsers()
        {
            var response = await httpClient.GetAsync($"{endpoint}/IndexGetAllUser");
            var content = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<IEnumerable<CustomUser>>(content);

            return list;

        }

        public async Task<IEnumerable<SignupRequest>> GetUnProcessedSignupRequests()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetUnProcessedSignupRequests");
            var content = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<IEnumerable<SignupRequest>>(content);

            return list;
        }

        public async Task<SignupRequest> ChangeSignUpRequestState(SignupRequest request)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/ChangeSignUpRequestState", request);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SignupRequest>(content);

            return result;
        }

        #endregion

        #region "Roles Managment"

        public async Task<IEnumerable<CustomRole>> GetAllRoles()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetAllRoles");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<CustomRole>>(content);

            return result;
        }

        public async Task<Response<CustomRole>> AddRole(CustomRole role)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/AddRole", role);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<CustomRole>>(content);

            return result;

        }

        public async Task<Response<CustomRole>> UpdateRole(CustomRole role)
        {
            var response = await httpClient.PutAsJsonAsync($"{endpoint}/UpdateRole", role);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<CustomRole>>(content);

            return result;
        }

        public async Task DeleteRole(string roleId)
        {
            await httpClient.DeleteAsync($"{endpoint}/DeleteRole/{roleId}");
        }

        public async Task<CustomRole> GetRole(string roleId)
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetRole/{roleId}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CustomRole>(content);

            return result;
        }

        public async Task<IEnumerable<PermissionClaim>> GetAllPermissions()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetAllPermissions");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<PermissionClaim>>(content);

            return result;
        }

        #endregion

    }
}
