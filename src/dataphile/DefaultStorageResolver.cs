using System.IO;

namespace Dataphile
{
    /// <summary>
    /// Defines the default storage path resolver.
    /// </summary>
    public class DefaultStorageResolver : IStorageResolver
    {
        /// <summary>
        /// Resolves a storage path for a specified object.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="basePath">The base storage path.</param>
        /// <param name="id">The id of the object.</param>
        /// <param name="extension">The storage file extension.</param>
        /// <returns>The storage path for the specified object.</returns>
        public string ResolveObject<T>(
            string basePath,
            object id,
            string extension) where T : class
        {
            string name = string.Format(
                "{0}.{1}",
                id,
                extension);
            
            return Path.Combine(
                ResolveType<T>(basePath),
                name);
        }

        /// <summary>
        /// Resolves a storage path for a specified type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <param name="basePath">The base storage path.</typeparam>
        /// <returns>The storage path for the specified type.</returns>
        public string ResolveType<T>(
            string basePath
            ) where T : class
        {
            return Path.Combine(
                basePath,
                typeof(T).FullName.Replace(".", "_"));
        }
    }
}