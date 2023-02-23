using JFP.Shared.Images;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using BrowserInterop.Geolocation;
using BrowserInterop.Extensions;
using JFP.Domain.Common;
using Microsoft.JSInterop;

namespace JFP.NewClient.Pages.Reports;

public partial class Index
{
    private LocationDto.Index _location = new();
    private ImageResponse.CreateResponse? _imageResponse;
    private WindowNavigatorGeolocation _geolocationWrapper;
    private bool _isLoading;

    [Inject] public ImageService ImageService { get; set; } = default!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var window = await JsRuntime.Window();
        var navigator = await window.Navigator();
        _geolocationWrapper = navigator.Geolocation;
    }

    private async Task UploadImages(InputFileChangeEventArgs e)
    {
        _isLoading = true;

        await GetLocation();

        var image = e.GetMultipleFiles().First();

        using var content = new MultipartFormDataContent();

        var imageContent = new StreamContent(image.OpenReadStream(15 * 1000 * 1024));

        imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

        content.Add(
            content: imageContent,
            name: "\"Image.File\"",
            fileName: image.Name
        );

        _imageResponse = await ImageService.UploadAsync(content);

        _isLoading = false;
    }

    private async Task GetLocation()
    {
        var currentPosition = (await _geolocationWrapper.GetCurrentPosition()).Location.Coords;
        _location = new()
        {
            Latitude = currentPosition.Latitude.ToString(),
            Longitude = currentPosition.Longitude.ToString()
        };
    }
}