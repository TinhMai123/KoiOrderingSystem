using System.Text.Json;

namespace KoiOrderingSystem_Web.Utils
{
    public static class JsonUtils
    {
        /// <summary>
        /// Converts a JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON string will be converted.</typeparam>
        /// <param name="jsonString">The JSON string to convert.</param>
        /// <returns>An object of type T.</returns>
        /// <exception cref="JsonException">Thrown when the JSON string is not valid.</exception>
        public static T? FromJson<T>(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("JSON string cannot be null or empty.", nameof(jsonString));
            }

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Converts an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to convert.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
