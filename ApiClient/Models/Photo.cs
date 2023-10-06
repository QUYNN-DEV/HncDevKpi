using Newtonsoft.Json;

namespace ApiClient.Models
{
    public partial class Photo
    {
        [JsonProperty("image_21x21")]
        public string Image21X21 { get; set; }

        [JsonProperty("image_27x27")]
        public string Image27X27 { get; set; }

        [JsonProperty("image_36x36")]
        public string Image36X36 { get; set; }

        [JsonProperty("image_60x60")]
        public string Image60X60 { get; set; }

        [JsonProperty("image_128x128")]
        public string Image128X128 { get; set; }
    }
}
