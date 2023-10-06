using Core.Config;
using Core.Helper;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Core.DL
{
    public class KPI_TEAM_DETAILDL
    {
        public static List<KPI_TEAM_DETAILModel> SearchUnCompleteTask(string employCode)
        {
            var lstResult = new List<KPI_TEAM_DETAILModel>();
            string strSql = string.Format(@"SELECT DISTINCT A.CONG_VIEC
                                            FROM KPI_TEAM_DETAIL A WITH (NOLOCK)
                                            WHERE EMPLOYER_CODE = '{0}'
                                                  AND TY_LE_HOAN_THANH < 100
                                                  AND TY_LE_HOAN_THANH <> 0
                                                  AND NOT EXISTS (SELECT *
                                                                FROM dbo.KPI_TEAM_DETAIL B WITH (NOLOCK)
                                                                WHERE A.CONG_VIEC = B.CONG_VIEC
                                                                      AND B.TY_LE_HOAN_THANH = 100);", employCode);

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_TEAM_DETAILModel), dr) as KPI_TEAM_DETAILModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }

        public static List<KPI_TEAM_DETAILModel> SearchMaNV(DateTime tungay, DateTime denngay, string MaNV, string Team)
        {
            var lstResult = new List<KPI_TEAM_DETAILModel>();
            string strSql = string.Format(@" SELECT us.TEAM,us.EMPLOYER_NAME,
                                                   detail.*
                                             FROM KPI_TEAM_DETAIL AS detail 
                                                INNER JOIN KPI_USER AS us 
                                                    ON detail.EMPLOYER_CODE = us.EMPLOYER_CODE
                                                       AND NGAY_THUC_HIEN >= '{1}'
                                                       AND NGAY_THUC_HIEN <= '{2}'
                                                       AND us.TEAM = '{3}'
                                                       AND us.EMPLOYER_CODE = '{0}'; ", MaNV, tungay.ToString("yyyy-MM-dd"), denngay.ToString("yyyy-MM-dd"), Team);

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_TEAM_DETAILModel), dr) as KPI_TEAM_DETAILModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult.OrderByDescending(s => s.NGAY_THUC_HIEN).ToList();
        }

        public static List<KPI_TEAM_DETAILModel> SearchTeam(DateTime tungay, DateTime denngay, string Team)
        {
            var lstResult = new List<KPI_TEAM_DETAILModel>();
            string strSql = string.Format(@" SELECT us.TEAM,us.EMPLOYER_NAME,
                                                    detail.*
                                             FROM KPI_TEAM_DETAIL AS detail 
                                                  INNER JOIN KPI_USER AS us  ON detail.EMPLOYER_CODE = us.EMPLOYER_CODE
                                                       AND NGAY_THUC_HIEN >= '{0}'
                                                       AND NGAY_THUC_HIEN <= '{1}'
                                                       AND us.TEAM = '{2}'", tungay.ToString("yyyy-MM-dd"), denngay.ToString("yyyy-MM-dd"), Team);

            var cmd = new SqlCommand(strSql, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = DLHelper.CreatDtoFromDataReader(typeof(KPI_TEAM_DETAILModel), dr) as KPI_TEAM_DETAILModel;
                    lstResult.Add(dtoResult);
                }
            }
            return lstResult;
        }
    }
}
