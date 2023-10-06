using ApiClient.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ApiClient.Models
{
    public partial class Section
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }
    public partial class SectionResponse
    {
        [JsonProperty("data")]
        public List<Section> Section { get; set; }
    }
    public class SectionHelper
    {
        public static List<Section> GetSectionsList(string projectGid, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("projects/{0}/sections/", projectGid), team);
            return JsonHelper.DeserializeObject<SectionResponse>(json).Section;
        }
        public static List<Task> GetTaskBySection(string strSectionId, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("sections/{0}/tasks", strSectionId), team);
            return JsonHelper.DeserializeObject<ListTaskResponse>(json).Tasks;
        }

        public static List<Task> GetTaskByAsanaIDSection(string asanaID, string sectionId, string team)
        {
            var lstIDBySection = GetTaskBySection(sectionId, team).Select(s => s.Gid).ToList();
            var lstTaskByAssign = Task.GetListTaskByAssign(asanaID, team);
            return lstTaskByAssign.Where(s => lstIDBySection.Contains(s.Gid)).ToList();
        }
    }

}