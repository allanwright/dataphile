using System;
using System.IO;

namespace aFile
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
        public string ResolvePath<T>(
            string basePath,
            object id,
            string extension) where T : class
        {
            string name = string.Format(
                "{0}.{1}",
                id,
                extension);

            Type type = typeof(T);
            
            return Path.Combine(
                basePath,
                type.FullName.Replace(".", "_"),
                name);
        }
    }
}