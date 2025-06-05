using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PackageController(PackageService packageService) : ControllerBase
{
  private readonly PackageService _packageService = packageService;

  [HttpGet("GetAllPackages")]
  public async Task<IActionResult> GetAllPackages()
  {
    var packages = await _packageService.GetAllPackagesAsync();

    return Ok(packages);
  }
}
