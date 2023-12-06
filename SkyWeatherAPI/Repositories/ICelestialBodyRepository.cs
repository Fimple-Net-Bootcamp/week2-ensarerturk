using SkyWeatherAPI.Models;

namespace SkyWeatherAPI.Repositories;

// Represents the repository for managing celestial bodies.
public interface ICelestialBodyRepository
{
    /*
     * Gets all celestial bodies.
     *
     * @return A list of celestial bodies.
     */
    List<CelestialBody> GetAllCelestialBodies();

    /*
     * Gets a celestial body by its name.
     *
     * @param name: The name of the celestial body.
     * @return The celestial body matching the specified name or null.
     */
    CelestialBody GetCelestialBodyByName(string name);

    /*
     * Adds a new celestial body.
     *
     * @param celestialBody: The celestial body to be added.
     */
    void AddCelestialBody(CelestialBody celestialBody);

    /*
     * Adds weather data to a celestial body.
     *
     * @param celestialBodyName: The name of the celestial body.
     * @param weatherData: The weather data to be added.
     */
    void AddWeatherDataToCelestialBody(string celestialBodyName, WeatherData weatherData);

    /*
     * Updates a celestial body.
     *
     * @param updatedCelestialBody: The updated celestial body.
     */
    void UpdateCelestialBody(CelestialBody updatedCelestialBody);

    /*
     * Partially updates a celestial body.
     *
     * @param name: The name of the celestial body to be updated.
     * @param partialUpdatedCelestialBody: The partially updated celestial body.
     */
    void PartialUpdateCelestialBody(string name, CelestialBody partialUpdatedCelestialBody);

    /*
     * Deletes a celestial body by its name.
     *
     * @param name: The name of the celestial body to be deleted.
     */
    void DeleteCelestialBody(string name);
}