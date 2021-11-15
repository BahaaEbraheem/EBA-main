using OA.Domin.Administration;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Administration
{
    public interface IAdministrationService
    {
        Task<PagedResponse<CustomUser>> GetAllUsers(RequestParameters PagingParameters);

        Task<IEnumerable<CustomUser>> IndexGetAllUsers();

        Task<Response<CustomUser>> AddUser(CustomUser user);

        Task DeleteUser(string Id);

        Task<Response<CustomUser>> UpdateUser(CustomUser user);

        Task<CustomUser> GetUser(string id);

        Task<IEnumerable<CustomUser>> GetPosibleManagers(string id);

        Task<Response<ResetPasswordRequest>> ResetPassword(ResetPasswordRequest resetPassword);

        Task<IEnumerable<CustomRole>> GetAllRoles();

        Task<IEnumerable<PermissionClaim>> GetAllPermissions();

        Task<CustomRole> GetRole(string roleId);

        Task<Response<CustomRole>> AddRole(CustomRole role);

        Task<Response<CustomRole>> UpdateRole(CustomRole role);

        Task DeleteRole(string roleId);

        Task<IEnumerable<SignupRequest>> GetUnProcessedSignupRequests();

        Task<SignupRequest> ChangeSignUpRequestState(SignupRequest request);
    }
}
