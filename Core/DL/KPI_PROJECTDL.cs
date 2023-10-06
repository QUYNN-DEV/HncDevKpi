using Core.Config;
using Core.Helper;
using Core.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Core.DL
{
    public class KPI_PROJECTDL
    {
        public static List<KPI_PROJECTModel> Search()
        {
            var lstResult = new List<KPI_PROJECTModel>();
            string strSql = @" SELECT * FROM KPI_PROJECT ";

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_PROJECTModel), dr) as KPI_PROJECTModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }


    }
}
