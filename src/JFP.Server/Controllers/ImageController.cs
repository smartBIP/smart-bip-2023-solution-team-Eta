using JFP.Shared.Images;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JFP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

	public ImageController(IImageService imageService)
	{
		_imageService = imageService;
	}

	[HttpPost]
	public async Task<ImageResponse.CreateResponse> CreateAsync([FromForm] ImageRequest.CreateRequest request)
	{
		return await _imageService.CreateAsync(request);
	}
}
