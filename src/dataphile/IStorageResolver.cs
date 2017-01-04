namespace Dataphile
{
    /// <summary>
    /// Defines the interface for resolving storage paths.
    /// </summary>
    public interface IStorageResolver
    {
        /// <summary>
        /// Resolves a storage path for a specified object.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="basePath">The base storage path.</param>
        /// <param name="id">The id of the object.</param>
        /// <param name="extension">The storage file extension.</param>
        /// <returns>The storage path for the specified object.</returns>
        string ResolveObject<T>(
            string basePath,
            object id,
            string extension
            ) where T : class;
        
        /// <summary>
        /// Resolves a storage path for a specified type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <param name="basePath">The base storage path.</typeparam>
        /// <returns>The storage path for the specified type.</returns>
        string ResolveType<T>(
            string basePath
            ) where T : class;
    }
}