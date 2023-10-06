using Core.Config;
using Core.Helper;
using Core.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Core.DL
{
    public class KPI_USERDL
    {
        public static List<KPI_USERModel> Search(KPI_USERModel dtoSearch)
        {
            string strSql = @"SELECT * FROM	KPI_USER ";
            string strSlqWhere = "WHERE ";
            bool isAddWhere = false;
            if (!string.IsNullOrWhiteSpace(dtoSearch.EMPLOYER_CODE))
            {
                strSlqWhere += string.Format("EMPLOYER_CODE='{0}'", dtoSearch.EMPLOYER_CODE);
                isAddWhere = true;
            }
            if (!string.IsNullOrWhiteSpace(dtoSearch.TEAM))
            {
                strSlqWhere += string.Format("TEAM='{0}'", dtoSearch.TEAM);
                isAddWhere = true;
            }
            if (isAddWhere)
            {
                strSql += strSlqWhere;
            }
            var lstResult = new List<KPI_USERModel>();

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_USERModel), dr) as KPI_USERModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }
    }
}
