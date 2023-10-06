namespace DEV_KPI.Common.UI
{
    public class UIGridCustomSummaryDistinct : UIGridCustomSummary
    {
        public bool IgnoreEmptyData
        {
            get; set;
        }

        public static string GetKeyValue(object value)
        {
            if (value == null)
            {
                return "";
            }

            return value.ToString();
        }
    }
}
