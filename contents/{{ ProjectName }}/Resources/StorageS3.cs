using Amazon;
using Amazon.Runtime;
using Amazon.S3;

namespace {{ ProjectName }}.Resources;

public static class StorageS3Extensions
{
    public static IServiceCollection AddStorageS3(this IServiceCollection services, Settings settings)
    {
        var config = new AmazonS3Config
        {
            ForcePathStyle = true,
        };
        if (!string.IsNullOrEmpty(settings.S3Endpoint))
        {
            config.ServiceURL = settings.S3Endpoint;
        }
        else
        {
            config.RegionEndpoint = RegionEndpoint.USEast1;
        }
        var credentials = new BasicAWSCredentials(settings.S3AccessKey, settings.S3SecretKey);
        services.AddSingleton<IAmazonS3>(new AmazonS3Client(credentials, config));
        return services;
    }
}
