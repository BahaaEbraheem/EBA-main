using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Notifications
{
    public interface ISMSService
    {
        Task SendMsg(string to, string from, string msg);

    }
}
