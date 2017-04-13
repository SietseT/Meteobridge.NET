using Meteobridge.Helpers;
using Meteobridge.Models;
using System;
using System.Xml.Linq;

namespace Meteobridge.Xml
{
    internal static class XmlConverter
    {
        internal static WeatherMeasurement Convert(XDocument doc)
        {
            XElement elementRain = doc.Root?.Element("RAIN");
            XElement elementIndoor = doc.Root?.Element("THB");
            XElement elementOutdoor = doc.Root?.Element("TH");
            XElement elementWind = doc.Root?.Element("WIND");

            var measurement = new WeatherMeasurement();

            measurement.Rainfall = DataHelper.GetDoubleValue(elementRain?.Attribute("rate").Value);
            measurement.RainfallTotal = DataHelper.GetDoubleValue(elementRain?.Attribute("total").Value);
            measurement.RainfallDelta = DataHelper.GetDoubleValue(elementRain?.Attribute("delta").Value);


            measurement.Humidity = (int)elementOutdoor?.Attribute("hum");
            measurement.Pressure = DataHelper.GetDoubleValue(elementIndoor?.Attribute("press").Value);
            measurement.SeaPressure = DataHelper.GetDoubleValue(elementIndoor?.Attribute("seapress").Value);

            measurement.Temperature = DataHelper.GetDoubleValue(elementOutdoor?.Attribute("temp").Value);
            measurement.Dewpoint = DataHelper.GetDoubleValue(elementOutdoor?.Attribute("dew").Value);
            measurement.Windchill = DataHelper.GetDoubleValue(elementWind?.Attribute("chill").Value);

            measurement.WindDirection = (int)elementWind?.Attribute("dir");
            measurement.WindDirectionCardinal = DataHelper.DegreesToCardinal(measurement.WindDirection);
            measurement.WindGust = DataHelper.GetDoubleValue(elementWind?.Attribute("gust").Value) * 3.6; //1m/s = 3.6km/h
            measurement.WindSpeed = DataHelper.GetDoubleValue(elementWind?.Attribute("wind").Value) * 3.6; //1m/s = 3.6km/h

            measurement.MeasurementTime = DateTime.UtcNow;

            //Check for low battery
            bool lowBatRain = DataHelper.GetBoolValue(elementRain?.Attribute("lowbat")?.Value);
            bool lowBatIndoor = DataHelper.GetBoolValue(elementIndoor?.Attribute("lowbat")?.Value);
            bool lowBatOutdoor = DataHelper.GetBoolValue(elementOutdoor?.Attribute("lowbat")?.Value);
            bool lowBatWind = DataHelper.GetBoolValue(elementWind?.Attribute("lowbat")?.Value);

            measurement.LowBattery = (lowBatRain || lowBatIndoor || lowBatOutdoor || lowBatWind);

            return measurement;
        }
    }
}
