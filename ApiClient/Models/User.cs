using ApiClient.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace ApiClient.Models
{
    public partial class UserResponse
    {
        [JsonProperty("data")]
        public User User { get; set; }
    }

    public partial class ListUserResponse
    {
        [JsonProperty("data")]
        public List<User> Users { get; set; }
    }

    public partial class User
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("workspaces")]
        public List<Workspace> Workspaces { get; set; }

        public Image Avatar { get; set; }

        public static User GetUser(string grid, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("users/{0}", grid), team);
            return JsonHelper.DeserializeObject<UserResponse>(json).User;
        }

        public static List<User> GetListUser(string team)
        {
            string json = ApiHelper.GetJsonString("users", team);
            return JsonHelper.DeserializeObject<ListUserResponse>(json).Users;
        }
    }
}
