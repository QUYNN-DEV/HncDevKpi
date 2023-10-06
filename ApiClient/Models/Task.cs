using ApiClient.Helpers;
using Core.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiClient.Models
{
    public partial class ListTaskResponse
    {
        [JsonProperty("data")]
        public List<Task> Tasks { get; set; }
    }

    public partial class TaskResponse
    {
        [JsonProperty("data")]
        public Task Task { get; set; }
    }

    public partial class Task
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("assignee")]
        public User Assignee { get; set; }

        [JsonProperty("assignee_status")]
        public string AssigneeStatus { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("completed_at")]
        public object CompletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("due_at")]
        public object DueAt { get; set; }

        [JsonProperty("due_on")]
        public object DueOn { get; set; }

        [JsonProperty("followers")]
        public List<User> Followers { get; set; }

        [JsonProperty("hearted")]
        public bool Hearted { get; set; }

        [JsonProperty("hearts")]
        public List<object> Hearts { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("likes")]
        public List<object> Likes { get; set; }

        [JsonProperty("memberships")]
        public List<Membership> Memberships { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("num_hearts")]
        public long NumHearts { get; set; }

        [JsonProperty("num_likes")]
        public long NumLikes { get; set; }

        [JsonProperty("parent")]
        public object Parent { get; set; }

        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("start_on")]
        public object StartOn { get; set; }

        [JsonProperty("tags")]
        public List<object> Tags { get; set; }

        [JsonProperty("resource_subtype")]
        public string ResourceSubtype { get; set; }

        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        public static Task GetTask(string gid, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("tasks/{0}", gid), team);
            return JsonHelper.DeserializeObject<TaskResponse>(json).Task;
        }

        public static List<Task> GetListTaskByProject(string projectGid, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("tasks?project={0}", projectGid), team);
            return JsonHelper.DeserializeObject<ListTaskResponse>(json).Tasks;
        }

        public static List<Task> GetListTaskByAssign(string asanaID, string team)
        {
            string workspace = team == "ERP" ? "1159539870226645" : "1185204831610890";
            string json = ApiHelper.GetJsonString(string.Format("tasks?assignee={0}&workspace={1}", asanaID, workspace), team);
            return JsonHelper.DeserializeObject<ListTaskResponse>(json).Tasks;
        }

        public static List<Task> GetListTask(string projectGid, string asanaID, string team)
        {
            var lstByProject = GetListTaskByProject(projectGid, team);
            var lstByAssign = GetListTaskByAssign(asanaID, team);
            if (lstByAssign.IsNullOrEmpty() || lstByProject.IsNullOrEmpty())
            {
                return null;
            }
            var lstIDByProject = lstByProject.Select(s => s.Gid);
            //foreach (var item in lstIDByProject)
            //{
            //    var task = GetTask(item);

            //}
            return lstByAssign.Where(s => lstIDByProject.Contains(s.Gid)).ToList();
        }
    }

    public partial class Membership
    {
        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("section")]
        public Section Section { get; set; }
    }
}
