using Business.Models;
using Data.Interfaces;

namespace Business.Services;
public class PackageService(IPackageRepository respository)
{
  private readonly IPackageRepository _respository = respository;

  public async Task<IEnumerable<PackageModel>> GetAllPackagesAsync()
  {
    var packages = await _respository.GetAllAsync();
    return packages.Select(p => new PackageModel
    {
      Id = p.Id,
      Name = p.Name,
      Description = p.Description,
      Type = p.Type,
      Price = p.Price
    });
  }
}
