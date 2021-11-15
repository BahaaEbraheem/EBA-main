using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.Upload
{
    public interface IUploadService
    {

        Task<string> UploadProfilePic(ProfilePicRequest profilePicRequest);

    }
}
