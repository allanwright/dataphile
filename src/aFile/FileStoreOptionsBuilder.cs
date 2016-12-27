namespace aFile
{
    /// <summary>
    /// Defines a file store options builder.
    /// </summary>
    public class FileStoreOptionsBuilder
    {
        private FileStoreOptions _options;

        /// <summary>
        /// Initializes a new instance of the FileStoreOptionsBuilder object.
        /// </summary>
        public FileStoreOptionsBuilder()
        {
            _options = new FileStoreOptions();
        }

        /// <summary>
        /// Builds the file store options.
        /// </summary>
        /// <returns>The file store options.</returns>
        public FileStoreOptions Build()
        {
            return _options;
        }

        /// <summary>
        /// Sets the base path for file storage.
        /// </summary>
        /// <param name="basePath">The base path for file storage.</param>
        /// <returns>The file store options builder.</returns>
        public FileStoreOptionsBuilder BasePath(string basePath)
        {
            _options.BasePath = basePath;
            return this;
        }

        /// <summary>
        /// Sets the file extension used when creating files.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>The file store options builder.</returns>
        public FileStoreOptionsBuilder Extension(string extension)
        {
            _options.Extension = extension;
            return this;
        }

        /// <summary>
        /// Sets the serializer.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <returns>The file store options builder.</returns>
        public FileStoreOptionsBuilder Serializer(ISerializer serializer)
        {
            _options.Serializer = serializer;
            return this;
        }

        /// <summary>
        /// Sets the storage resolver.
        /// </summary>
        /// <param name="storageResolver">The storage resolver.</param>
        /// <returns>The file store options builder.</returns>
        public FileStoreOptionsBuilder StorageResolver(IStorageResolver storageResolver)
        {
            _options.StorageResolver = storageResolver;
            return this;
        }
    }
}