namespace SkyWeatherAPI.Models;

/*
 * Represents a planet, a type of celestial body, with additional information about the quality of the atmosphere.
 * Inherits from the base class 'CelestialBody'.
 */
public class Planet : CelestialBody
{
    private string _atmosphereQuality;

    // Gets or sets the quality of the planet's atmosphere. Throws ArgumentNullException if the value is null.
    public string AtmosphereQuality
    {
        get => _atmosphereQuality;
        set => _atmosphereQuality = value ?? throw new ArgumentNullException(nameof(value));
    }
}