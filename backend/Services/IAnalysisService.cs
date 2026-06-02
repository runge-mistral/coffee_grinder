using CoffeeGrinderBackend.Models;

namespace CoffeeGrinderBackend.Services;

public interface IAnalysisService
{
    Task<CoffeeGrindAnalysis> AnalyzeImageAsync(IFormFile image, string? userId);
    Task<IEnumerable<CoffeeGrindResponse>> GetAllUploadsAsync();
}
