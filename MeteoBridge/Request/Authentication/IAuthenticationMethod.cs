using System.Net;

namespace MeteoBridge.Request
{
    public interface IAuthenticationMethod
    {
        void AddAuthentication(WebRequest request);
    }
}
