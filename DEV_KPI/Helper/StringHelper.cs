using System.Text.RegularExpressions;

namespace DEV_KPI.Helper
{
    public class StringHelper
    {
        public static string TaskCodeFromTaskName(string taskCode)
        {
            string regex = @"ERP-\d+";
            string output = string.Empty;
            if (taskCode.Contains("ERP"))
            {
                string nonSpace = taskCode.Replace(" ", "");
                var lstMath = Regex.Matches(taskCode, regex);
                if (lstMath.Count > 0)
                {
                    output = lstMath[0].Value;
                }
            }
            return output;
        }
    }
}
