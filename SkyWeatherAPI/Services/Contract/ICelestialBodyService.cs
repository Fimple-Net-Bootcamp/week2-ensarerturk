using SkyWeatherAPI.Models;

namespace SkyWeatherAPI.Services.Contract;

/*
 * The ICelestialBodyService interface defines methods to manage celestial bodies.
 */
public interface ICelestialBodyService
{
    /*
     * Gets a paginated list of celestial bodies based on specified parameters.
     *
     * @param page: The page number for pagination.
     * @param pageSize: The number of items per page.
     * @param status: Optional filter for celestial body status.
     * @param sortBy: Optional parameter for sorting by a specific property.
     * @param sortAscending: Optional parameter for sorting in ascending or descending order.
     * @return A paginated list of celestial bodies.
     */
    List<CelestialBody> GetAllCelestialBodies(int page = 1, int pageSize = 10, string status = null,
        string sortBy = null, bool sortAscending = true);

    /*
     * Gets a celestial body by its name.
     *
     * @param name: The name of the celestial body.
     * @return The celestial body matching the specified name or null if not found.
     */
    CelestialBody GetCelestialBodyByName(string name);

    /*
     * Adds weather data to a celestial body.
     *
     * @param celestialBodyName: The name of the celestial body.
     * @param weatherData: The weather data to be added.
     */
    void AddWeatherDataToCelestialBody(string celestialBodyName, WeatherData weatherData);

    /*
     * Updates a celestial body in the repository.
     *
     * @param name: The name of the celestial body to be updated.
     * @param updatedCelestialBody: The updated celestial body.
     */
    void UpdateCelestialBody(string name, CelestialBody updatedCelestialBody);

    /*
     * Partially updates a celestial body in the repository.
     *
     * @param name: The name of the celestial body to be updated.
     * @param partialUpdatedCelestialBody: The partially updated celestial body.
     */
    void PartialUpdateCelestialBody(string name, CelestialBody partialUpdatedCelestialBody);

    /*
     * Deletes a celestial body from the repository by its name.
     *
     * @param name: The name of the celestial body to be deleted.
     */
    void DeleteCelestialBody(string name);
}