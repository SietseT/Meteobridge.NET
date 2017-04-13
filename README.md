# MeteoBridge.NET

Meteobridge.NET is a library that makes it easy to retrieve data from a weatherstation that is connected to a [Meteobridge](http://www.meteobridge.com/wiki/index.php/Home) device.

## Requirements
- A weatherstation that is connected to Meteobridge

## Features
- Retrieve live XML data from Meteobridge
- HTTP / HTTPS support
- Basic authentication support

## What data is retrieved?
- Temperature (in celsius)
- Dewpoint (in celsius)
- Windchill (in celsius)
- Pressure (hPa)
- Seapressure (hPa)
- Humidity (%)
- Rainfall (mm/h)
- Total rainfall (mm)
- Delta rainfall (rainfall since last weatherstation measurement, in mm)
- Wind direction (in degrees)
- Wind direction (cardinal)
- Wind speed (in km/h)
- Wind gust (in km/h)
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
- Support for Meteobridge PRO template files
- If desired, more ways to authenticate the request, for example: OAuth

