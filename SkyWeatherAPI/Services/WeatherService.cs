using SkyWeatherAPI.Models;
using SkyWeatherAPI.Services.Contract;

namespace SkyWeatherAPI.Services;

// Service responsible for retrieving weather data for a celestial body.
public class WeatherService : IWeatherService
{
    private readonly ICelestialBodyService _celestialBodyService;

    // Initializes a new instance of the WeatherService class with the provided ICelestialBodyService dependency.
    public WeatherService(ICelestialBodyService celestialBodyService)
    {
        _celestialBodyService = celestialBodyService;
    }

    // Retrieves weather data for the celestial body with the specified name.
    // If the celestial body is not found, an empty list is returned.
    public List<WeatherData> GetWeatherData(string celestialBodyName)
    {
        var celestialBody = _celestialBodyService.GetCelestialBodyByName(celestialBodyName);

        return celestialBody?.WeatherDataList ?? new List<WeatherData>();
    }
}