using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AVDeviceControl
{
    /// <summary>
    /// Data required by authentication
    /// </summary>
    public class CameraCtlAuthInfo
    {
        /// <summary>
        /// True if authentication is required, false otherwise
        /// </summary>
        [JsonProperty(PropertyName = "authRequired")]
        public readonly bool AuthRequired;

        /// <summary>
        /// Authentication challenge
        /// </summary>
        [JsonProperty(PropertyName = "challenge")]
        public readonly string Challenge;

        /// <summary>
        /// Password salt
        /// </summary>
        [JsonProperty(PropertyName = "salt")]
        public readonly string PasswordSalt;

        /// <summary>
        /// Builds the object from JSON response body
        /// </summary>
        /// <param name="data">JSON response body as a <see cref="JObject"/></param>
        public CameraCtlAuthInfo(JObject data)
        {
            JsonConvert.PopulateObject(data.ToString(), this);
        }

        /// <summary>
        /// Default Constructor for deserialization
        /// </summary>
        public CameraCtlAuthInfo() { }
    }
}