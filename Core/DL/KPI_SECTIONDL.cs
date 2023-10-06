using Core.Config;
using Core.Helper;
using Core.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Core.DL
{
    public class KPI_SECTIONDL
    {
        public static List<KPI_SECTIONModel> Search()
        {
            var lstResult = new List<KPI_SECTIONModel>();
            string strSql = @" SELECT * FROM dbo.KPI_SECTION";

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_SECTIONModel), dr) as KPI_SECTIONModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }

        public static List<KPI_SECTIONModel> Search(List<string> lstGid)
        {
            var lstResult = new List<KPI_SECTIONModel>();
            string strSql = string.Format(@" SELECT * FROM dbo.KPI_SECTION WHERE Gid IN ( '{0}' );", string.Join("','", lstGid));

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_SECTIONModel), dr) as KPI_SECTIONModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }
    }
}
