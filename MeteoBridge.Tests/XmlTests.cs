using Meteobridge.Xml;
using Should;
using System.Xml.Linq;
using Xunit;

namespace Meteobridge.Tests
{
    public class XmlTests
    {
        [Fact]
        public void ValidateXml()
        {
            //Arrange
            string xml = "<logger>" +
                "<RAIN date=\"20170411205625\" id=\"rain0\" rate=\"0.0\" total=\"162.0\" delta=\"0.0\" lowbat=\"0\" /> " +
                "<THB date=\"20170411205625\" id=\"thb0\" temp=\"24.5\" hum=\"41\" dew=\"10.4\" press=\"1021.8\" seapress=\"1022.6\" fc=\"-1\" lowbat=\"0\" /> " +
                "<WIND date=\"20170411205625\" id=\"wind0\" dir=\"90\" gust=\"1.0\" wind=\"0.3\" chill=\"9.3\" lowbat=\"0\" /> " +
                "<TH date=\"20170411205625\" id=\"th0\" temp=\"9.3\" hum=\"68\" dew=\"3.7\" lowbat=\"0\" />" +
                "</logger>";

            var xdoc = XDocument.Parse(xml);

            //Act 
            bool isValidXml = XmlValidator.ValidMeteobridgeData(xdoc);

            //Assert
            isValidXml.ShouldBeTrue();
        }

        [Fact]
        public void ConvertXml()
        {
            //Arrange
            string xml = "<logger>" +
                "<RAIN date=\"20170411205625\" id=\"rain0\" rate=\"0.0\" total=\"162.0\" delta=\"0.0\" lowbat=\"0\" /> " +
                "<THB date=\"20170411205625\" id=\"thb0\" temp=\"24.5\" hum=\"41\" dew=\"10.4\" press=\"1021.8\" seapress=\"1022.6\" fc=\"-1\" lowbat=\"0\" /> " +
                "<WIND date=\"20170411205625\" id=\"wind0\" dir=\"90\" gust=\"1.0\" wind=\"0.3\" chill=\"9.3\" lowbat=\"0\" /> " +
                "<TH date=\"20170411205625\" id=\"th0\" temp=\"9.3\" hum=\"68\" dew=\"3.7\" lowbat=\"0\" />" +
                "</logger>";

            var xdoc = XDocument.Parse(xml);

            //Act
            var measurement = XmlConverter.Convert(xdoc);

            //Assert
            measurement.Temperature.ShouldEqual(9.3);
            measurement.Windchill.ShouldEqual(9.3);
            measurement.Dewpoint.ShouldEqual(3.7);

            measurement.Rainfall.ShouldEqual(0.0);
            measurement.RainfallTotal.ShouldEqual(162.0);
            measurement.RainfallDelta.ShouldEqual(0.0);

            measurement.Humidity.ShouldEqual(68);
            measurement.Pressure.ShouldEqual(1021.8);
            measurement.SeaPressure.ShouldEqual(1022.6);

            measurement.WindDirection.ShouldEqual(90);
            measurement.WindDirectionCardinal.ShouldEqual("O");
            measurement.WindGust.ShouldEqual(3.6);
            measurement.WindSpeed.ShouldEqual(1.08);

            measurement.LowBattery.ShouldBeFalse();
        }
    }
}
