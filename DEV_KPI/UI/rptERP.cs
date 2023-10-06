using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace DEV_KPI.UI
{
    public partial class rptERP : DevExpress.XtraReports.UI.XtraReport
    {
        public rptERP()
        {
            InitializeComponent();
        }

        public void Print(List<KPI_TEAM_DETAILModel> lstSearch)
        {
            bindingSource1.DataSource = lstSearch.OrderBy(s => s.NGAY_THUC_HIEN).ToList();
        }
    }
}
