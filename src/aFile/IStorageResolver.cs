namespace aFile
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
        string ResolvePath<T>(
            string basePath,
            string id,
            string extension
            ) where T : class;
    }
}