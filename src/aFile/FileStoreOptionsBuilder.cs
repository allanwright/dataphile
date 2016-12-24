namespace aFile
{
    public class FileStoreOptionsBuilder
    {
        private FileStoreOptions _options;

        public FileStoreOptionsBuilder()
        {
            _options = new FileStoreOptions();
        }

        public FileStoreOptions Build()
        {
            return _options;
        }

        public FileStoreOptionsBuilder BasePath(string basePath)
        {
            _options.BasePath = basePath;
            return this;
        }

        public FileStoreOptionsBuilder Extension(string extension)
        {
            _options.Extension = extension;
            return this;
        }

        public FileStoreOptionsBuilder Serializer(ISerializer serializer)
        {
            _options.Serializer = serializer;
            return this;
        }

        public FileStoreOptionsBuilder StorageResolver(IStorageResolver storageResolver)
        {
            _options.StorageResolver = storageResolver;
            return this;
        }
    }
}