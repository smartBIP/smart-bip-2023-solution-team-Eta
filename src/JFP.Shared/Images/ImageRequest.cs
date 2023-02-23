namespace JFP.Shared.Images;

public static class ImageRequest
{
    public class CreateRequest
    {
        public ImageDto.Create Image { get; set; } = default!;
    }
}