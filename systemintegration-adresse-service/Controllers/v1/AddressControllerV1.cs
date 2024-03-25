using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using systemintegration_adresse_service.Services;

namespace systemintegration_adresse_service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AddressControllerV1(ISearchServiceV1 searchServiceV1) : ControllerBase
{
    [HttpGet]
    public ActionResult<string?> GetStreetName([FromQuery] String vejKode,
        [FromQuery] String komKode)
    {
        string? result = searchServiceV1.FindByVejKodeAndKomKode(vejKode, komKode);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Fuzzy search for street names
    /// </summary>
    /// <param name="streetname"></param>
    /// <returns></returns>
    [HttpGet("{streetName}")]
    public ActionResult<IEnumerable<string>> SearchStreetName(string streetName)
    {
        return Ok(searchServiceV1.FindStreetsFuzzySearch(streetName));
    }
}