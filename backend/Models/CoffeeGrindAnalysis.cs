namespace CoffeeGrinderBackend.Models;

public class CoffeeGrindAnalysis
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? ImagePath { get; set; }
    public string? GrindSize { get; set; } // e.g., "Fine", "Medium", "Coarse"
    public string? Consistency { get; set; } // e.g., "Uniform", "Inconsistent"
    public double? ParticleSizeMicrons { get; set; }
    public string? ColorAnalysis { get; set; }
    public string? ShapeAnalysis { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? MistralAnalysis { get; set; } // Analysis from Mistral API
}

public class CoffeeGrindRequest
{
    public IFormFile? Image { get; set; }
    public string? UserId { get; set; }
}

public class CoffeeGrindResponse
{
    public string? Id { get; set; }
    public string? ImageUrl { get; set; }
    public string? GrindSize { get; set; }
    public string? Consistency { get; set; }
    public double? ParticleSizeMicrons { get; set; }
    public string? ColorAnalysis { get; set; }
    public string? ShapeAnalysis { get; set; }
    public string? MistralAnalysis { get; set; }
    public DateTime CreatedAt { get; set; }
}
