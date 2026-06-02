using Microsoft.AspNetCore.Mvc;
using CoffeeGrinderBackend.Models;
using CoffeeGrinderBackend.Services;

namespace CoffeeGrinderBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyzeController : ControllerBase
{
    private readonly IAnalysisService _analysisService;
    private readonly ILogger<AnalyzeController> _logger;

    public AnalyzeController(IAnalysisService analysisService, ILogger<AnalyzeController> logger)
    {
        _analysisService = analysisService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Analyze([FromForm] CoffeeGrindRequest request)
    {
        if (request.Image == null || request.Image.Length == 0)
        {
            return BadRequest(new { message = "No image uploaded" });
        }

        try
        {
            var analysis = await _analysisService.AnalyzeImageAsync(request.Image, request.UserId);
            return Ok(new CoffeeGrindResponse
            {
                Id = analysis.Id,
                ImageUrl = $"/images/{analysis.ImagePath}",
                GrindSize = analysis.GrindSize,
                Consistency = analysis.Consistency,
                ParticleSizeMicrons = analysis.ParticleSizeMicrons,
                ColorAnalysis = analysis.ColorAnalysis,
                ShapeAnalysis = analysis.ShapeAnalysis,
                MistralAnalysis = analysis.MistralAnalysis,
                CreatedAt = analysis.CreatedAt
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error analyzing image");
            return StatusCode(500, new { message = "Error analyzing image", error = ex.Message });
        }
    }

    [HttpGet("uploads")]
    public async Task<IActionResult> GetAllUploads()
    {
        try
        {
            var uploads = await _analysisService.GetAllUploadsAsync();
            return Ok(uploads);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching uploads");
            return StatusCode(500, new { message = "Error fetching uploads", error = ex.Message });
        }
    }
}
