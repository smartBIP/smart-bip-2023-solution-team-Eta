using Microsoft.AspNetCore.Http;

namespace JFP.Domain.Images;

public class Image
{
    public Guid Id { get; private set; }
    public string FileName { get; private set; }
    public IFormFile File { get; private set; }

    public Image(IFormFile file)
    {
        Id = Guid.NewGuid();
        FileName = $"{Id}_reportImage.{file.FileName.Split(".")[1]}";
        File = file;
    }

    public void SaveToDisk(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        using(FileStream fileStream = System.IO.File.Create($"{path}{FileName}"))
        {
            File.CopyTo(fileStream);
            fileStream.Flush();
        }
    }
}
