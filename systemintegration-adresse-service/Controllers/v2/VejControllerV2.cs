using Microsoft.AspNetCore.Mvc;
using systemintegration_adresse_service.Models;
using systemintegration_adresse_service.Services;

namespace systemintegration_adresse_service.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class VejControllerV2 : ControllerBase
{
    public VejControllerV2(IVejServiceV2 vejServiceV2)
    {
        _vejServiceV2 = vejServiceV2;
    }

    private IVejServiceV2 _vejServiceV2;
    
    [HttpGet("findByKomKodeAndVejKode{komKode:regex(^\\d{{4}}$)}/{vejKode:regex(^\\d{{4}}$)}")]
    public ActionResult<AktVej> FindByKomKodeAndVejKode(string komKode, string vejKode)
    {
        var result = _vejServiceV2.FindByKomKodeVejKode(komKode, vejKode);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("findAllByVejnavn/{vejnavn}")]
    public ActionResult<IEnumerable<AktVej>> FindAllByVejnavn(string vejnavn)
    {
        return Ok(_vejServiceV2.FindVejByNameFuzzySearch(vejnavn));
    }
    
    
}