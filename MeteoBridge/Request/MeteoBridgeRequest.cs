using MeteoBridge.Models;
using MeteoBridge.Request.Authentication;
using MeteoBridge.Xml;
using System;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace MeteoBridge.Request
{
    public class MeteoBridgeRequest
    {  
        public MeteoBridgeRequest(Uri uri)
        {
            Uri = uri;
        }

        public Uri Uri { get; set; }
        public MeteoBridgeRequestType Type { get; set; } = MeteoBridgeRequestType.Xml;
        public IAuthenticationMethod Authentication { get; set; }
        public Exception Exception { get; set; }

        public WeatherMeasurement GetWeatherMeasurement()
        {
            var webRequest = CreateRequest();            

            //Perform request
            WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
            }
            catch(WebException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                Exception = ex;
                return null;
            }

            //Read response
            using (var responseStream = response.GetResponseStream())
            {
                return GetMeasurementFromResponse(responseStream);
            }
        }

        internal WeatherMeasurement GetTestWeatherMeasurement()
        {
            string xml = "<logger>" +
                "<RAIN date=\"20170411205625\" id=\"rain0\" rate=\"0.0\" total=\"162.0\" delta=\"0.0\" lowbat=\"0\" /> " +
                "<THB date=\"20170411205625\" id=\"thb0\" temp=\"24.5\" hum=\"41\" dew=\"10.4\" press=\"1021.8\" seapress=\"1022.6\" fc=\"-1\" lowbat=\"0\" /> " +
                "<WIND date=\"20170411205625\" id=\"wind0\" dir=\"90\" gust=\"1.0\" wind=\"0.3\" chill=\"9.3\" lowbat=\"0\" /> " +
                "<TH date=\"20170411205625\" id=\"th0\" temp=\"9.3\" hum=\"68\" dew=\"3.7\" lowbat=\"0\" />" +
                "</logger>";

            //Read response
            using (Stream responseStream = new MemoryStream(System.Text.Encoding.Unicode.GetBytes(xml)))
            {
                return GetMeasurementFromResponse(responseStream);
            }
        }

        internal WebRequest CreateRequest()
        {
            var url = Uri.GetLeftPart(UriPartial.Authority);

            if (Type == MeteoBridgeRequestType.Xml)
            {
                url += "/cgi-bin/livedataxml.cgi";
            }

            var webRequest = WebRequest.Create(url);

            //Add authentication
            if (Authentication != null)
                webRequest.AddAuthentication(Authentication);

            return webRequest;
        }

        private WeatherMeasurement GetMeasurementFromResponse(Stream responseStream)
        {
            XDocument doc = XDocument.Load(responseStream);
            if(!XmlValidator.ValidMeteoBridgeData(doc))
                throw new FormatException("MeteoBridge response is not in correct format.");

            return XmlConverter.Convert(doc);
        }
    }
}
