using Core.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core.Helper
{
    public class LocalData
    {
        private static readonly string strFolderPath = @"C:\ProgramData\DEV_KPI\";
        private static readonly string strLocalFile = "DataLocal.txt";
        private static readonly string strDuongDan = strFolderPath + strLocalFile;

        public static void SetLocalDataEmployer(KPI_USERModel objUserLogIn)
        {
            DevHelper.Inject(objUserLogIn, _objUserLogIn);
        }
        private static readonly KPI_USERModel _objUserLogIn = new KPI_USERModel();

        public static KPI_USERModel ObjUserLogIn
        {
            private set { }
            get { return _objUserLogIn; }
        }


        public static void SaveLocalUser(string strUserCode)
        {
            List<string> strContent = null;
            ReadLocalData(out strContent);
            if (!strContent.IsNullOrEmpty())
            {
                DeleteLocalData();
            }
            SaveLocalData(strFolderPath, strUserCode);
        }

        public static void DeleteLocalData()
        {
            if (File.Exists(strDuongDan))
            {
                File.WriteAllText(strDuongDan, string.Empty);
            }
        }

        private static void SaveLocalData(string strFolderPath, string strUserCode)
        {
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }

            if (!File.Exists(strDuongDan))
            {
                File.Create(strDuongDan).Close();
            }
            File.AppendAllText(strDuongDan, strUserCode);
        }

        public static bool ReadLocalData(out List<string> resultData)
        {
            resultData = null;
            if (!File.Exists(strDuongDan))
            {
                return false;
            }
            resultData = File.ReadAllLines(strDuongDan).ToList();
            if (resultData.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
