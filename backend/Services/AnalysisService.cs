using CoffeeGrinderBackend.Models;
using System.Text.Json;

namespace CoffeeGrinderBackend.Services;

public class AnalysisService : IAnalysisService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<AnalysisService> _logger;
    private readonly List<CoffeeGrindAnalysis> _uploads = new();

    public AnalysisService(IWebHostEnvironment environment, ILogger<AnalysisService> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public async Task<CoffeeGrindAnalysis> AnalyzeImageAsync(IFormFile image, string? userId)
    {
        // Generate unique filename
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        
        // Ensure uploads directory exists
        Directory.CreateDirectory(uploadsFolder);
        
        var filePath = Path.Combine(uploadsFolder, fileName);
        
        // Save the image
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        // TODO: Integrate with Mistral API for actual analysis
        // For now, return mock analysis
        var analysis = new CoffeeGrindAnalysis
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            ImagePath = fileName,
            GrindSize = "Medium", // Placeholder - will come from Mistral
            Consistency = "Uniform", // Placeholder
            ParticleSizeMicrons = 500, // Placeholder
            ColorAnalysis = "Dark brown with consistent color distribution", // Placeholder
            ShapeAnalysis = "Mostly uniform particles with some variation", // Placeholder
            MistralAnalysis = "This appears to be a medium grind suitable for drip coffee makers. The consistency is good with minimal fines.", // Placeholder
            CreatedAt = DateTime.UtcNow
        };

        _uploads.Add(analysis);
        _logger.LogInformation("Saved image: {FileName}", fileName);

        return analysis;
    }

    public async Task<IEnumerable<CoffeeGrindResponse>> GetAllUploadsAsync()
    {
        // TODO: Load from database instead of in-memory list
        return _uploads.Select(u => new CoffeeGrindResponse
        {
            Id = u.Id,
            ImageUrl = $"/uploads/{u.ImagePath}",
            GrindSize = u.GrindSize,
            Consistency = u.Consistency,
            ParticleSizeMicrons = u.ParticleSizeMicrons,
            ColorAnalysis = u.ColorAnalysis,
            ShapeAnalysis = u.ShapeAnalysis,
            MistralAnalysis = u.MistralAnalysis,
            CreatedAt = u.CreatedAt
        });
    }
}
