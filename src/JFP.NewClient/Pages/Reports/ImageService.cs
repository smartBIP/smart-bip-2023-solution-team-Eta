﻿using JFP.Shared.Images;
using System.Net.Http;
using System.Net.Http.Json;

namespace JFP.NewClient.Pages.Reports;

public class ImageService : IImageService
{
    private const string _endpoint = "api/Image";

    private readonly HttpClient _client;

    public ImageService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ImageResponse.CreateResponse> CreateAsync(ImageRequest.CreateRequest request)
    {
        var response = await _client.PostAsJsonAsync(_endpoint, request);

        return await response.Content.ReadFromJsonAsync<ImageResponse.CreateResponse>();
    }

    public async Task<ImageResponse.CreateResponse> UploadAsync(MultipartFormDataContent content)
    {
        var response = await _client.PostAsync(_endpoint, content);
        return await response.Content.ReadFromJsonAsync<ImageResponse.CreateResponse>();
    }
}
