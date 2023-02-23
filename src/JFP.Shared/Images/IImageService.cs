namespace JFP.Shared.Images;

public interface IImageService
{
    Task<ImageResponse.CreateResponse> CreateAsync(ImageRequest.CreateRequest request);
}
