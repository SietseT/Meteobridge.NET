using System;

namespace Meteobridge.Models
{
    public class WeatherMeasurement
    {
        public double Temperature { get; set; }
        public double Dewpoint { get; set; }
        public double Windchill { get; set; }

        public int WindDirection { get; set; }
        public string WindDirectionCardinal { get; set; }
        public double WindSpeed { get; set; }
        public double WindGust { get; set; }

        public int Humidity { get; set; }
        public double Pressure { get; set; }
        public double SeaPressure { get; set; }

        public double Rainfall { get; set; }
        public double RainfallTotal { get; set; }
        public double RainfallDelta { get; set; }

        public DateTime MeasurementTime { get; set; }
        public bool LowBattery { get; set; }
    }
}
