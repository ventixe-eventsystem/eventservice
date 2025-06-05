using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PackageController(IPackageService packageService) : ControllerBase
{
  private readonly IPackageService _packageService = packageService;

  [HttpGet("GetAllPackages")]
  public async Task<IActionResult> GetAllPackages()
  {
    try
    {
      var packages = await _packageService.GetAllPackagesAsync();
      if (packages == null || !packages.Any())
        return NotFound("No packages found.");

      return Ok(packages);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"An error occurred while retrieving packages: {ex.Message}");
    }
  }
}
