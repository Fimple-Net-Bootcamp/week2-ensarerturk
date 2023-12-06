using SkyWeatherAPI.Models;

namespace SkyWeatherAPI.Services.Contract;

// Defines the contract for weather-related services.
public interface IWeatherService
{
    // Retrieves weather data for the celestial body with the specified name.
    List<WeatherData> GetWeatherData(string celestialBodyName);
}