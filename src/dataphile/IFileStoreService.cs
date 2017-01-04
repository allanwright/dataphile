using System.Collections.Generic;

namespace Dataphile
{
    /// <summary>
    /// Defines the interface for the FileStore service.
    /// </summary>
    public interface IFileStoreService
    {
        /// <summary>
        /// Reads all instances of the specified entity type from the file store.
        /// </summary>
        /// <typeparam name="T">The type of entity to read.</typeparam>
        /// <returns>All entities of the specified type.  If none exist then an empty collection is returned.</returns>
        IEnumerable<T> ReadAll<T>() where T : class;

        /// <summary>
        /// Reads the specified entity from the file store.
        /// </summary>
        /// <typeparam name="T">The type of entity to read.</typeparam>
        /// <param name="id">The id of the entity to read.</param>
        /// <returns>The entity, if it exists, otherwise an ArgumentException is thrown.</returns>
        T ReadSingle<T>(object id) where T : class;

        /// <summary>
        /// Inserts an entity into the file store.
        /// </summary>
        /// <typeparam name="T">The type of entity to insert.</typeparam>
        /// <param name="value">The entity to insert.</param>
        /// <param name="id">The id of the entity to insert.</param>
        /// <remarks>
        /// An ArgumentNullException is thrown if the entity is null.
        /// An InvalidOperationException is thrown if the entity already exists in the file store.
        /// </remarks>
        void Insert<T>(T value, object id) where T : class;

        /// <summary>
        /// Updates an existing entity in the file store.
        /// </summary>
        /// <typeparam name="T">The type of entity to update.</typeparam>
        /// <param name="value">The entity to update.</param>
        /// <param name="id">The id of the entity to update.</param>
        /// <remarks>
        /// An ArgumentNullException is thrown if the entity is null.
        /// An InvalidOperationException is thrown if the entity doesn't exist in the file store.
        /// </remarks>
        void Update<T>(T value, object id) where T : class;

        /// <summary>
        /// Deletes an existing entity from the file store.
        /// </summary>
        /// <typeparam name="T">The type of entity to delete.</typeparam>
        /// <param name="id">The id of the entity to delete.</param>
        /// <remarks>
        /// An ArgumentNullException is thrown if the entity is null.
        /// An InvalidOperationException is thrown if the entity doesn't exist in the file store.
        /// </remarks>
        void Delete<T>(object id) where T : class;
    }
}