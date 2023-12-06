using SkyWeatherAPI.Models;

namespace SkyWeatherAPI.Repositories;

/*
 * CelestialBodyRepository provides the implementation of the ICelestialBodyRepository interface
 * to manage celestial bodies in the in-memory repository.
 */
public class CelestialBodyRepository : ICelestialBodyRepository
{
    private static List<CelestialBody> _celestialBodies = new List<CelestialBody>()
    {
        new Planet { Name = "Mars", Gravity = 3.71, AtmosphereQuality = "Thin", Status = "active" },
        new Moon { Name = "Titan", Gravity = 1.352, HasSurfaceIce = true, Status = "inactive" }
    };
    
    /*
     * Gets all celestial bodies.
     *
     * @return A list of celestial bodies.
     */
    public List<CelestialBody> GetAllCelestialBodies()
    {
        return _celestialBodies;
    }

    /*
     * Gets a celestial body by its name.
     *
     * @param name: The name of the celestial body.
     * @return The celestial body matching the specified name or throws an exception if not found.
     */
    public CelestialBody GetCelestialBodyByName(string name)
    {
        return _celestialBodies.FirstOrDefault(n => n.Name == name) ?? throw new InvalidOperationException();
    }

    /*
     * Adds a new celestial body to the repository.
     *
     * @param celestialBody: The celestial body to be added.
     */
    public void AddCelestialBody(CelestialBody celestialBody)
    {
        _celestialBodies.Add(celestialBody);
    }

    /*
     * Adds weather data to a celestial body.
     *
     * @param celestialBodyName: The name of the celestial body.
     * @param weatherData: The weather data to be added.
     */
    public void AddWeatherDataToCelestialBody(string celestialBodyName, WeatherData weatherData)
    {
        // Finds the celestial body by name and adds the weather data to its list.
        var body = _celestialBodies.FirstOrDefault(body => body.Name == celestialBodyName);
        
        body?.WeatherDataList.Add(weatherData);
    }

    /*
     * Updates a celestial body in the repository.
     *
     * @param updatedCelestialBody: The updated celestial body.
     */
    public void UpdateCelestialBody(CelestialBody updatedCelestialBody)
    {
        // Finds the existing celestial body by name and updates its properties.
        var existingBody = _celestialBodies.FirstOrDefault(body => body.Name == updatedCelestialBody.Name);
        
        if (existingBody == null) return;
        existingBody.Name = updatedCelestialBody.Name;
        existingBody.Gravity = updatedCelestialBody.Gravity;
        existingBody.Status = updatedCelestialBody.Status;
    }

    /*
     * Partially updates a celestial body in the repository.
     *
     * @param name: The name of the celestial body to be updated.
     * @param partialUpdatedCelestialBody: The partially updated celestial body.
     */
    public void PartialUpdateCelestialBody(string name, CelestialBody partialUpdatedCelestialBody)
    {
        // Finds the existing celestial body by name and updates its properties based on the partial update.
        var existingCelestialBody = _celestialBodies.FirstOrDefault(body => body.Name == name);
        
        if (existingCelestialBody == null) return;
        
        // Updates the name if the partial update has a non-empty name.
        if (!string.IsNullOrEmpty(partialUpdatedCelestialBody.Name))
        {
            existingCelestialBody.Name = existingCelestialBody.Name;
        }

        // Updates the gravity if the partial update has a positive gravity value.
        if (partialUpdatedCelestialBody.Gravity > 0)
        {
            existingCelestialBody.Gravity = partialUpdatedCelestialBody.Gravity;
        }

        // Updates the status if the partial update has a non-empty status.
        if (!string.IsNullOrEmpty(partialUpdatedCelestialBody.Status))
        {
            existingCelestialBody.Status = partialUpdatedCelestialBody.Status;
        }
    }

    /*
     * Deletes a celestial body from the repository by its name.
     *
     * @param name: The name of the celestial body to be deleted.
     */
    public void DeleteCelestialBody(string name)
    {
        // Finds and removes the celestial body from the repository by its name.
        var celestialBodyToDelete = _celestialBodies.FirstOrDefault(body => body.Name == name);

        if (celestialBodyToDelete != null)
        {
            _celestialBodies.Remove(celestialBodyToDelete);
        }
    }
}