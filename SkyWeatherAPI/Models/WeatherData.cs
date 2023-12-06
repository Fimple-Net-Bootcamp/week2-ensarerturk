namespace SkyWeatherAPI.Models;

// Represents weather data, including the condition and temperature.
public class WeatherData
{
    private string _condition;
    private double _temperature;

    // Gets or sets the weather condition.
    public string Condition
    {
        get { return _condition; }
        set { _condition = value; }
    }

    // Gets or sets the temperature.
    public double Temperature
    {
        get { return _temperature; }
        set { _temperature = value; }
    }
}