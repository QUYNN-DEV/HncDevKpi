using DevExpress.XtraGrid.Views.Grid;

namespace DEV_KPI.Common
{
    public static class UIControl
    {
        public static object GetCurrentDataInGrid(this GridView grv)
        {
            object result = null;
            int focusedRowHandle = grv.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                result = grv.GetRow(focusedRowHandle);
            }
            return result;
        }
    }
}
