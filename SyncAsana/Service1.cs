using ApiClient.Models;
using Core.DL;
using Core.Helper;
using Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Timers;

namespace SyncAsana
{
    public partial class Service1 : ServiceBase
    {
        private bool isRunning = false;
        private Timer timer = new Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                //Lấy list về từ asana
                var lstProject = Project.GetListProject("ERP");
                //Xóa bỏ Task tồn
                lstProject.RemoveAll(s => s.Gid == "1159549879397552");
                //Lấy list từ local
                var lstLocal = KPI_PROJECTDL.Search();
                //Đồng bộ
                if (!lstProject.IsNullOrEmpty())
                {
                    foreach (var item in lstProject)
                    {
                        var dtoLocal = lstLocal.FirstOrDefault(s => s.Gid == item.Gid);
                        if (dtoLocal == null)
                        {
                            DLHelper.Insert(new KPI_PROJECTModel { Gid = item.Gid, Name = item.Name });
                        }
                    }
                }
                //Lấy list về từ asana
                if (!lstProject.IsNullOrEmpty())
                {
                    foreach (var project in lstProject)
                    {
                        var lstSection = SectionHelper.GetSectionsList(project.Gid, "ERP");
                        if (lstSection.IsNullOrEmpty())
                        {
                            continue;
                        }
                        var lstSecGid = lstSection.Select(s => s.Gid).ToList();

                        //Lấy list từ local
                        var lstSectionLocal = KPI_SECTIONDL.Search(lstSecGid);
                        foreach (var section in lstSection)
                        {
                            var dtoSecLocal = lstSectionLocal.FirstOrDefault(s => s.Gid == section.Gid);
                            if (dtoSecLocal == null)
                            {
                                DLHelper.Insert(new KPI_SECTIONModel { Gid = section.Gid, Name = section.Name, ProGid = project.Gid });
                            }
                        }
                    }
                }
                isRunning = false;
            }
        }

        protected override void OnStop()
        {
        }
    }
}
