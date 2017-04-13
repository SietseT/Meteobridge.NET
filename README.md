# MeteoBridge.NET

Meteobridge.NET is a library that makes it easy to retrieve data from a weatherstation that is connected to a [Meteobridge](http://www.meteobridge.com/wiki/index.php/Home) device.

## Requirements
- A weatherstation that is connected to Meteobridge

## Features
- Retrieve live XML data from Meteobridge
- HTTP / HTTPS support
- Basic authentication support

## What data is retrieved?
- Temperature (celsius)
- Dewpoint (celsius)
- Windchill (celsius)
- Pressure (hPa)
- Seapressure (hPa)
- Humidity (%)
- Rainfall (mm/h)
- Total rainfall (mm)
- Delta rainfall (rainfall since last weatherstation measurement, mm)
- Wind direction (degrees)
- Wind direction (cardinal)
- Wind speed (km/h)
- Wind gust (km/h)
- Low battery (boolean)

## How to use?
The code snippet below demonstrates example usage.

````csharp
var uri = new Uri("http://127.0.0.1");

var request = new MeteobridgeRequest(uri);
request.Authentication = new BasicAuthentication("user", "password"); //Optional

var result = request.GetWeatherMeasurement();
````


## What's next?
- Add documentation to (public) methods
- Meteobridge [templates](http://www.meteobridge.com/wiki/index.php/Templates) engine
- Support for Fahrenheit and other data types
- Support for Meteobridge PRO template files
- If desired, more ways to authenticate the request, for example: OAuth

