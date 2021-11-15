using Microsoft.AspNetCore.Identity;
using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.Logging;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Administration
{
    public interface IAdministrationService
    {
        Task<IEnumerable<CustomUser>> GetAllUsers();
        Task<Response<CustomUser>> AddUserAsync(CustomUser user);
        Response<CustomUser> UpdateUser(CustomUser user);
        void DeleteUser(string userId);
        Task<User> GetById(string userId);
        CustomUser GetUserById(string userId);
        IEnumerable<CustomUser> GetClaimUsers(string claim);
        Task<Response<ResetPasswordRequest>> ResetPassword(ResetPasswordRequest reset);
        IEnumerable<SignupRequest> GetUnProcessedSignupRequests();
        SignupRequest ChangeSignUpRequestState(SignupRequest request);
        void AddUserVerificationAnswers(IEnumerable<UserVerificationAnswerCreateRequest> userVerificationAnswers, string userId);
        IEnumerable<VerificationQuestion> GetVerificationQuestions();
        Response<IEnumerable<VerificationQuestion>> GetUserVerificationQuestions(string email);
        Task<Response<string>> ExternalResetPassword(ExternalResetPasswordRequest externalResetPasswordRequest);



        IEnumerable<CustomRole> GetAllRoles();
        CustomRole GetRole(string roleId);        
        CustomRole GetRoleByName(string roleName);
        CustomRole GetClaimRole(string claimVal);
        Response<CustomRole> CreateRole(CustomRole role);
        Response<CustomRole> UpdateRole(CustomRole role);
        void DeleteRole(string roleId);


        IEnumerable<CustomRole> GetUserRoles(string userId);
        void AddRoleToUser(string roleId, string userId);
        void RemoveRoleFromUser(string roleId, string userId);


        IEnumerable<PermissionClaim> GetPermissionClaims();
        string GetUserFilterdClaim(string userId, string filter, Func<string,string, bool> filterFunc);
        
        void AddClaimToRole(string perClaimVal, string roleId);
        void RemoveClaimFromRole(string perClaimVal, string roleId);


        Task<IEnumerable<Claim>> GetUserClaims(string uesrId);
        IEnumerable<PermissionClaim> GetRoleClaims(string roleName);
        Task AddClaimToUser(string claimId, string userId);
        Task RemoveClaimFromUser(string claimId, string userId);      



    }
}
