using JFP.Shared.Common;

namespace JFP.Shared.Images;

public static class ImageResponse
{
    public class CreateResponse
    {
        public ImageDto.Detail Image { get; set; } = default!;
        public PredictionDto.Index Prediction { get; set; } = default!;
    }
}
