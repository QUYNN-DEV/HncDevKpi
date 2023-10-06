using DevExpress.Data;
using DevExpress.XtraGrid.Columns;

namespace DEV_KPI.Common.UI
{
    public class UIGridCustomSummaryPercent : UIGridCustomSummary
    {
        //--colSoBiChia/colBichia = colThuong
        public GridColumn colSoBiChia
        {
            set;
            get;
        }

        public GridColumn colSoChia
        {
            set;
            get;
        }

        public GridColumn colThuong
        {
            set
            {
                BindingColumn = value;
            }
            get { return BindingColumn; }
        }

        public decimal DefaultPercentValue
        {
            get;
            set;
        }

        private bool _isPercent = true;
        public bool IsPercent
        {
            get { return _isPercent; }
            set { _isPercent = value; }
        }

        public UIGridCustomSummaryPercent()
            : base()
        {
            DefaultPercentValue = 0;
        }
    }

    public class UIGridCustomSummary
    {
        public GridColumn BindingColumn
        {
            set;
            get;
        }

        public string FormatString
        {
            get;
            set;
        }

        public SummaryItemType SummaryType
        {
            get;
            set;
        }

        public UIGridCustomSummary()
        {
            FormatString = "{0}";
            SummaryType = SummaryItemType.None;
        }
    }


}
