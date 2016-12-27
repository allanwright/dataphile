using Newtonsoft.Json;

namespace aFile
{
    /// <summary>
    /// Defines the default serializer.
    /// </summary>
    /// <remarks>
    /// The default serializer implements json serialization.
    /// </remarks>
    public class DefaultSerializer : ISerializer
    {
        /// <summary>
        /// Deserializes the specified object.
        /// </summary>
        /// <typeparam name="T">The deserialized type.</typeparam>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T Deserialize<T>(string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The serialized object.</returns>
        public string Serialize<T>(T value) where T : class
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}