namespace SkyWeatherAPI.Models;

/*
 * Represents a moon, a type of celestial body, with additional information about the presence of surface ice.
 * Inherits from the base class 'CelestialBody'.
 */
public class Moon : CelestialBody
{
    private bool _hasSurfaceIce;

    // Gets or sets a value indicating whether the moon has surface ice.
    public bool HasSurfaceIce
    {
        get => _hasSurfaceIce;
        set => _hasSurfaceIce = value;
    }
}