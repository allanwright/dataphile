using Microsoft.Extensions.DependencyInjection;

namespace aFile
{
    public static class FileStoreExtensions
    {
        public static void AddFileStore(this IServiceCollection services, string basePath)
        {
            AddFileStore(services, new FileStoreOptions() {
                BasePath = basePath
            });
        }

        public static void AddFileStore(this IServiceCollection services, FileStoreOptions options)
        {
            services.AddSingleton(
                typeof(IFileStoreService),
                new FileStoreService(options));
        }
    }
}