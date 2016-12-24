using System;
using Microsoft.Extensions.DependencyInjection;

namespace aFile
{
    /// <summary>
    /// Defines extension methods for adding the file store service as an application dependency.
    /// </summary>
    public static class FileStoreExtensions
    {
        /// <summary>
        /// Adds the file store service as an application dependency.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="basePath">The base path for file storage.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddFileStore(this IServiceCollection services, string basePath)
        {
            return AddFileStore(services, options => {
                options.BasePath(basePath);
            });
        }

        /// <summary>
        /// Adds the file store service as an application dependency.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The file store options.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddFileStore(this IServiceCollection services, Action<FileStoreOptionsBuilder> options)
        {
            var optionsBuilder = new FileStoreOptionsBuilder();
            options(optionsBuilder);

            return services.AddSingleton(
                typeof(IFileStoreService),
                new FileStoreService(optionsBuilder.Build()));
        }
    }
}