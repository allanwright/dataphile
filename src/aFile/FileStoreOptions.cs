namespace aFile
{
    /// <summary>
    /// Defines file store options.
    /// </summary>
    public class FileStoreOptions
    {
        /// <summary>
        /// Gets or sets the base path of the file store.
        /// </summary>
        /// <remarks>
        /// An ArgumentException is thrown if BasePath is not an absolute path.
        /// </remarks>
        public string BasePath { get; set; }

        public string Extension { get; set; } = "json";

        public ISerializer Serializer { get; set; }

        public IStorageResolver StorageResolver { get; set; }
    }
}