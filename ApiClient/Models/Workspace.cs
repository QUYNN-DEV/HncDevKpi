using Newtonsoft.Json;

namespace ApiClient.Models
{
    public partial class Workspace
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }
}
