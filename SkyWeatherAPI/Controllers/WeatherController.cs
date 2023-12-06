using Microsoft.AspNetCore.Mvc;
using SkyWeatherAPI.Models;
using SkyWeatherAPI.Services.Contract;

namespace SkyWeatherAPI.Controllers;

[ApiController]
[Route("api/v1/celestialbodies")]
public class WeatherController : ControllerBase
{
    private readonly ICelestialBodyService _celestialBodyService;
    private readonly IWeatherService _weatherService;

    // Initializes a new instance of the WeatherController class with the provided services.
    public WeatherController(ICelestialBodyService celestialBodyService, IWeatherService weatherService)
    {
        _celestialBodyService = celestialBodyService;
        _weatherService = weatherService;
    }

    // Gets a paginated list of celestial bodies with optional filtering and sorting.
    [HttpGet]
    public ActionResult<List<CelestialBody>> GetAll([FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string status = null, [FromQuery] string sortBy = null, [FromQuery] bool sortAscending = true)
    {
        try
        {
            var celestialBodies =
                _celestialBodyService.GetAllCelestialBodies(page, pageSize, status, sortBy, sortAscending);
            if (celestialBodies.Count == 0)
            {
                return BadRequest("Bad Request");
            }

            return Ok(celestialBodies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Gets information about a celestial body with the specified name.
    [HttpGet("{name}")]
    public ActionResult<CelestialBody> GetWithName(string name)
    {
        try
        {
            var celestialBody = _celestialBodyService.GetCelestialBodyByName(name);

            if (celestialBody != null)
            {
                return Ok(celestialBody);
            }

            return NotFound("Celestial Body not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Gets weather data for a celestial body with the specified name.
    [HttpGet("{name}/weathers")]
    public ActionResult<List<WeatherData>> GetWeatherData(string name)
    {
        try
        {
            var weatherData = _weatherService.GetWeatherData(name);
            return Ok(weatherData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Adds weather data to a celestial body with the specified name.
    [HttpPost("{name}/weathers")]
    public ActionResult AddWeatherDataToCelestialBody(string name, [FromBody] WeatherData weatherData)
    {
        try
        {
            var celestialBody = _celestialBodyService.GetCelestialBodyByName(name);

            if (celestialBody == null) return NotFound("Celestial Body not found");
            
            _celestialBodyService.AddWeatherDataToCelestialBody(name, weatherData);
            return Ok("Weather data added successfully");

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Updates information about a celestial body with the specified name.
    [HttpPut("{name}")]
    public ActionResult UpdateCelestialBody(string name, [FromBody] CelestialBody updatedCelestialBody)
    {
        try
        {
            var existingCelestialBody = _celestialBodyService.GetCelestialBodyByName(name);

            if (existingCelestialBody == null) return NotFound("Celestial Body not found");
            
            _celestialBodyService.UpdateCelestialBody(name, updatedCelestialBody);
            return Ok("Celestial Body updated successfully");

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Partially updates information about a celestial body with the specified name.
    [HttpPatch("{name}")]
    public ActionResult PartialUpdateCelestialBody(string name, [FromBody] CelestialBody partialUpdatedCelestialBody)
    {
        try
        {
            var existingCelestialBody = _celestialBodyService.GetCelestialBodyByName(name);

            if (existingCelestialBody == null) return NotFound("Celestial Body not found");
            
            _celestialBodyService.PartialUpdateCelestialBody(name, partialUpdatedCelestialBody);
            return Ok("Celestial Body partially updated successfully");

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    // Deletes a celestial body with the specified name.
    [HttpDelete("{name}")]
    public ActionResult DeleteCelestialBody(string name)
    {
        try
        {
            var existingCelestialBody = _celestialBodyService.GetCelestialBodyByName(name);

            if (existingCelestialBody == null) return NotFound("Celestial Body not found");
            
            _celestialBodyService.DeleteCelestialBody(name);
            return Ok("Celestial Body deleted successfully");

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}