using System.Net;

namespace Meteobridge.Request.Authentication
{
    internal static class AuthenticationExtensionMethods
    {
        internal static void AddAuthentication(this WebRequest webRequest, IAuthenticationMethod authentication)
        {
            authentication.AddAuthentication(webRequest);
        }
    }
}
