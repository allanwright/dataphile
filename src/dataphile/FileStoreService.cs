using System;
using System.Collections.Generic;
using System.IO;

namespace Dataphile
{
    public class FileStoreService : IFileStoreService
    {
        private FileStoreOptions _options;

        /// <summary>
        /// Initializes a new instance of the FileStoreService object.
        /// </summary>
        /// <param name="serializer">The serializer used by FileStoreService.</param>
        public FileStoreService(FileStoreOptions options)
        {
            _options = options;

            if (string.IsNullOrEmpty(_options.BasePath))
                throw new ArgumentException("BasePath cannot be null or empty");
            
            if (string.IsNullOrEmpty(_options.Extension))
                throw new ArgumentException("Extension cannot be null or empty");
            
            if (_options.Extension.StartsWith("."))
                _options.Extension = _options.Extension.TrimStart(".".ToCharArray());
            
            if (_options.Serializer == null)
                _options.Serializer = new DefaultSerializer();
            
            if (_options.StorageResolver == null)
                _options.StorageResolver = new DefaultStorageResolver();
        }

        public void Delete<T>(object id) where T : class
        {
            File.Delete(
                _options.StorageResolver.ResolveObject<T>(
                    _options.BasePath,
                    id,
                    _options.Extension));
        }

        public void Insert<T>(T value, object id) where T : class
        {
            string directoryPath = _options.StorageResolver.ResolveType<T>(
                _options.BasePath);            
            var directoryInfo = new DirectoryInfo(directoryPath);

            if (!directoryInfo.Exists)
                directoryInfo.Create();
            
            File.WriteAllText(
                _options.StorageResolver.ResolveObject<T>(
                    _options.BasePath,
                    id,
                    _options.Extension),
                _options.Serializer.Serialize(value));
        }

        public T ReadSingle<T>(object id) where T : class
        {
            return _options.Serializer.Deserialize<T>(
                File.ReadAllText(_options.StorageResolver.ResolveObject<T>(
                    _options.BasePath,
                    id,
                _options.Extension)));
        }

        public IEnumerable<T> ReadAll<T>() where T : class
        {
            var fileInfo = new FileInfo(_options.StorageResolver.ResolveObject<T>(_options.BasePath, "", _options.Extension));
            var directoryInfo = fileInfo.Directory;

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            var items = new List<T>();

            foreach (FileInfo file in directoryInfo.GetFiles(string.Concat("*.", _options.Extension)))
            {
                items.Add(ReadSingle<T>(file.Name.TrimEnd(string.Concat(".", _options.Extension).ToCharArray())));
            }

            return items.ToArray();
        }

        public void Update<T>(T value, object id) where T : class
        {
            Insert(value, id);
        }
    }
}