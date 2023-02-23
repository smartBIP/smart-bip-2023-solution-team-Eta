using Microsoft.AspNetCore.Http;

namespace JFP.Shared.Images;

public static class ImageDto
{
    public class Detail
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; } = default!;
    }

    public class Create
    {
        public IFormFile File { get; set; } = default!;
    }
}