using SkyWeatherAPI.Models;
using SkyWeatherAPI.Repositories;
using SkyWeatherAPI.Services.Contract;

namespace SkyWeatherAPI.Services;

/*
 * The CelestialBodyService class provides business logic to manage celestial bodies
 * by implementing the ICelestialBodyService interface.
 */
public class CelestialBodyService : ICelestialBodyService
{
    private ICelestialBodyRepository _celestialBodyRepository;

    /*
     * Constructor of the CelestialBodyService class, requiring an instance of ICelestialBodyRepository.
     *
     * @param celestialBodyRepository: Repository providing access to celestial bodies data.
     */
    public CelestialBodyService(ICelestialBodyRepository celestialBodyRepository)
    {
        _celestialBodyRepository = celestialBodyRepository;
    }

    // Retrieves a paginated list of celestial bodies based on the specified parameters.
    public List<CelestialBody> GetAllCelestialBodies(int page = 1, int pageSize = 10, string status = null,
        string sortBy = null,
        bool sortAscending = true)
    {
        // Retrieve all celestial bodies from the repository.
        var allCelestialBodies = _celestialBodyRepository.GetAllCelestialBodies();

        // Filter celestial bodies by status if the status parameter is provided.
        if (!string.IsNullOrEmpty(status))
        {
            allCelestialBodies = allCelestialBodies.Where(body => body.Status == status).ToList();
        }

        // Sort celestial bodies based on the specified criteria and order.
        if (!string.IsNullOrEmpty(sortBy))
        {
            sortBy = char.ToUpper(sortBy[0]) + sortBy.Substring(1).ToLower();
            
            allCelestialBodies = sortAscending
                ? allCelestialBodies.OrderBy(body => body.GetType().GetProperty(sortBy)?.GetValue(body, null)).ToList()
                : allCelestialBodies.OrderByDescending(body => body.GetType().GetProperty(sortBy)?.GetValue(body, null))
                    .ToList();
        }
        // Perform pagination by skipping items and taking a specified number of items per page.
        allCelestialBodies = allCelestialBodies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return allCelestialBodies;
    }

    // Retrieves a celestial body by its name
    public CelestialBody GetCelestialBodyByName(string name)
    {
        return _celestialBodyRepository.GetCelestialBodyByName(name);
    }

    // Adds weather data to the specified celestial body.
    public void AddWeatherDataToCelestialBody(string celestialBodyName, WeatherData weatherData)
    {
        _celestialBodyRepository.AddWeatherDataToCelestialBody(celestialBodyName, weatherData);
    }

    // Updates the specified celestial body
    public void UpdateCelestialBody(string name, CelestialBody updatedCelestialBody)
    {
        _celestialBodyRepository.UpdateCelestialBody(updatedCelestialBody);
    }

    // Performs a partial update on the specified celestial body.
    public void PartialUpdateCelestialBody(string name, CelestialBody partialUpdatedCelestialBody)
    {
        _celestialBodyRepository.PartialUpdateCelestialBody(name, partialUpdatedCelestialBody);
    }

    // Deletes the celestial body with the specified name.
    public void DeleteCelestialBody(string name)
    {
        _celestialBodyRepository.DeleteCelestialBody(name);
    }
}