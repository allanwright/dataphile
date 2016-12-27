namespace aFile
{
    /// <summary>
    /// Defines file store options.
    /// </summary>
    public class FileStoreOptions
    {
        /// <summary>
        /// Gets or sets the base path for file storage.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the file extension used when creating files.
        /// </summary>
        public string Extension { get; set; } = "json";

        /// <summary>
        /// Gets or sets the serializer.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// Gets or sets the storage resolver.
        /// </summary>
        public IStorageResolver StorageResolver { get; set; }
    }
}