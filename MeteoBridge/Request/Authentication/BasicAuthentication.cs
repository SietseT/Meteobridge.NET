using System.Net;

namespace Meteobridge.Request.Authentication
{
    public class BasicAuthentication : IAuthenticationMethod
    {
        string _username;
        string _password;

        public BasicAuthentication(string username, string password)
        {
            _username = username;
            _password = password;
        }

        void IAuthenticationMethod.AddAuthentication(WebRequest request)
        {
            request.Credentials = new NetworkCredential(_username, _password);
        }
    }
}
