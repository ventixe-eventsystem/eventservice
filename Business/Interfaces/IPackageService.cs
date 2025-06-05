using Business.Models;

namespace Business.Services;

public interface IPackageService
{
  Task<IEnumerable<PackageModel>> GetAllPackagesAsync();
}