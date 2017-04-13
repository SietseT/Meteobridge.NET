using System.Net;

namespace Meteobridge.Request
{
    public interface IAuthenticationMethod
    {
        void AddAuthentication(WebRequest request);
    }
}
