using ApiClient.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiClient.Models
{
    public partial class ProjectResponse
    {
        [JsonProperty("data")]
        public Project Project { get; set; }
    }

    public partial class ListProjectResponse
    {
        [JsonProperty("data")]
        public List<Project> Projects { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("current_status")]
        public object CurrentStatus { get; set; }

        [JsonProperty("custom_fields")]
        public List<object> CustomFields { get; set; }

        [JsonProperty("default_view")]
        public string DefaultView { get; set; }

        [JsonProperty("due_on")]
        public object DueOn { get; set; }

        [JsonProperty("due_date")]
        public object DueDate { get; set; }

        [JsonProperty("followers")]
        public List<User> Followers { get; set; }

        [JsonProperty("is_template")]
        public bool IsTemplate { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("members")]
        public List<User> Members { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("owner")]
        public User Owner { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("section_migration_status")]
        public string SectionMigrationStatus { get; set; }

        [JsonProperty("start_on")]
        public object StartOn { get; set; }

        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        public string CreateUser { get; set; }

        public string ListMember { get; set; }

        public static Project GetProject(string gid, string team)
        {
            string json = ApiHelper.GetJsonString(string.Format("projects/{0}", gid), team);
            return JsonHelper.DeserializeObject<ProjectResponse>(json).Project;
        }

        public static List<Project> GetListProject(string team)
        {
            string json = ApiHelper.GetJsonString("projects?archived=false", team);
            return JsonHelper.DeserializeObject<ListProjectResponse>(json).Projects;
        }

        public static bool CreateNewProject(Project project, string team)
        {
            var ProjectPostData = new ProjectPostData();
            var ProjectPost = new ProjectPost
            {
                Name = project.Name,
                Workspace = project.Workspace.Gid,
                Public = project.Public,
                Notes = project.Notes
            };
            ProjectPostData.ProjectPost = ProjectPost;
            return ApiHelper.CreateObject("projects", ProjectPostData, team);
        }

        public static bool UpdateProject(Project project, string team)
        {
            var ProjectPostData = new ProjectPostData();
            var ProjectPost = new ProjectPost
            {
                Name = project.Name,
                Workspace = project.Workspace.Gid,
                Public = project.Public,
                Notes = project.Notes
            };
            ProjectPostData.ProjectPost = ProjectPost;
            return ApiHelper.UpdateObject(string.Format("projects/{0}", project.Gid), ProjectPostData, team);
        }

        public static bool DeleteProject(string gid, string team)
        {
            return ApiHelper.DeleleObject(string.Format("projects/{0}", gid), team);
        }

        private class ProjectPostData
        {
            [JsonProperty("data")]
            public ProjectPost ProjectPost { get; set; }
        }

        private class ProjectPost
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("workspace")]
            public string Workspace { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("public")]
            public bool Public { get; set; }
        }
    }
}
