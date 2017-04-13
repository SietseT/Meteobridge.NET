using Should;
using Xunit;
using MeteoBridge.Request;
using MeteoBridge.Request.Authentication;
using System;

namespace MeteoBridge.Tests
{
    public class MeteoBridgeRequestTests
    {
        [Fact]
        public void WebRequestUrlShouldBeCorrect()
        {
            //Arrange
            var request = new MeteoBridgeRequest(new Uri("http://127.0.0.1"));

            //Act
            var webRequest = request.CreateRequest();

            //Asset
            webRequest.RequestUri.ToString().ShouldEqual("http://127.0.0.1/cgi-bin/livedataxml.cgi");
        }

        [Fact]
        public void RequestShouldHaveBasicAuthentication()
        {
            //Arrange
            var request = new MeteoBridgeRequest(new Uri("http://127.0.0.1"));
            request.Authentication = new BasicAuthentication("user", "password");

            //Act
            var webRequest = request.CreateRequest();
            var networkCredentials = webRequest.Credentials.GetCredential(webRequest.RequestUri, "BasicAuthentication");

            //Assert
            networkCredentials.ShouldNotBeNull();
            networkCredentials.UserName.ShouldEqual("user");
            networkCredentials.Password.ShouldEqual("password");
        }

        [Fact]
        public void RequestShouldReturnResponse()
        {
            //Arrange
            var request = new MeteoBridgeRequest(new Uri("http://127.0.0.1"));

            //Act
            var response = request.GetTestWeatherMeasurement();

            //Assert
            response.ShouldNotBeNull();
            response.Temperature.ShouldEqual(9.3);
        }
    }
}
