using Microsoft.Extensions.DependencyInjection;

namespace aFile
{
    public static class FileStoreExtensions
    {
        public static IServiceCollection AddFileStore(this IServiceCollection services, string basePath)
        {
            return AddFileStore(services, new FileStoreOptions() {
                BasePath = basePath
            });
        }

        public static IServiceCollection AddFileStore(this IServiceCollection services, FileStoreOptions options)
        {
            return services.AddSingleton(
                typeof(IFileStoreService),
                new FileStoreService(options));
        }
    }
}