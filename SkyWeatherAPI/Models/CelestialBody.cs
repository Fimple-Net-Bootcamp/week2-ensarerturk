namespace SkyWeatherAPI.Models;

/*
 * Represents a celestial body, such as a planet or moon,
 * with information about its name, gravity, status, and weather data.
 */
public class CelestialBody
{
    private string _name;
    private double _gravity;
    private string _status;
    private List<WeatherData> _weatherDataList = new List<WeatherData>();

    // Gets or sets the name of the celestial body.
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Gets or sets the gravity of the celestial body.
    public double Gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

    // Gets or sets the status of the celestial body (e.g., active or inactive).
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }

    // Gets the list of weather data associated with the celestial body.
    public List<WeatherData> WeatherDataList
    {
        get { return _weatherDataList; }
        private set { _weatherDataList = value; }
    }
}