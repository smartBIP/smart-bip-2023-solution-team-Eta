using JFP.Domain.Images;
using JFP.Shared.Images;
using Microsoft.Extensions.ML;
using System.IO;
using System.Threading.Tasks;

namespace JFP.Server.Services;

public class ImageService : IImageService
{
    private readonly PredictionEnginePool<RecognitionModel.ModelInput, RecognitionModel.ModelOutput> _predictionEnginePool;

    public ImageService(PredictionEnginePool<RecognitionModel.ModelInput, RecognitionModel.ModelOutput> predictionEnginePool)
    {
        _predictionEnginePool = predictionEnginePool;
    }

    public Task<ImageResponse.CreateResponse> CreateAsync(ImageRequest.CreateRequest request)
    {
        int predictedCategory;
        string path = $"C:\\Development\\Projects\\HG - IP Project\\smart-bip-2023-solution-team-Eta\\src\\JFP.Server\\wwwroot\\Uploads\\";

        Image image = new(request.Image.File);

        image.SaveToDisk(path);

        RecognitionModel.ModelInput input = new()
        {
            ImageSource = File.ReadAllBytes($"{path}{image.FileName}")
        };

        var prediction = _predictionEnginePool.Predict(input);

        switch(prediction.PredictedLabel)
        {
            case "Broken Street":
                predictedCategory = 1;
                break;
            case "Traffic Lights":
                predictedCategory = 2;
                break;
            case "Trash Can":
                predictedCategory = 3;
                break;
            default:
                predictedCategory = 4; 
                break;
        }

        return Task.FromResult(new ImageResponse.CreateResponse
        {
            Image = new()
            {
                Id = image.Id,
                FilePath = $"{path}{image.FileName}"
            },
            Prediction = new()
            {
                ReportCategory = predictedCategory
            }
        });
    }
}
