namespace aFile
{
    /// <summary>
    /// Defines the serializer interface used by FileStoreService.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserializes the specified object.
        /// </summary>
        /// <typeparam name="T">The deserialized type.</typeparam>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize<T>(string value) where T : class;

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The serialized object.</returns>
        string Serialize<T>(T value) where T : class;
    }
}