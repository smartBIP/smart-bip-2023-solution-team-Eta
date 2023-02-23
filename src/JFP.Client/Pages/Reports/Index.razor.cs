using JFP.Shared.Images;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace JFP.Client.Pages.Reports;

public partial class Index
{
    [Inject] public ImageService ImageService { get; set; } = default!;

    private async Task UploadImages(InputFileChangeEventArgs e)
    {
        var image = e.GetMultipleFiles().First();

        using var content = new MultipartFormDataContent();

        var imageContent = new StreamContent(image.OpenReadStream(15 * 1000 * 1024));

        imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

        content.Add(
            content: imageContent,
            name: "\"files\"",
            fileName: image.Name
        );

        var response = await ImageService.UploadAsync(content);
    }
}