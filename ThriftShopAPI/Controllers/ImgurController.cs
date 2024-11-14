using Microsoft.AspNetCore.Mvc;
using ThriftShopAPI.Repositories;

[ApiController]
[Route("api/[controller]")]
public class ImgurController : ControllerBase
{
    private readonly IImgurRepo _repository;
    private readonly ILogger<ImgurController> _logger;

    public ImgurController(IImgurRepo imgurRepo, ILogger<ImgurController> logger)
    {
        _repository = imgurRepo;
        _logger = logger;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        _logger.LogInformation("Upload endpoint hit");
        if (file == null || file.Length == 0)
        {
            _logger.LogWarning("No file received");
            return BadRequest("No file received");
        }

        try
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var imageData = ms.ToArray();
            var imgurUrl = await _repository.UploadImageAsync(imageData);
            return Ok(imgurUrl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in upload");
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("API is working");
    }
}