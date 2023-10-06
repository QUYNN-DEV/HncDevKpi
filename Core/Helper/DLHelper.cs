using Core.Config;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Core.Helper
{
    public class DLHelper
    {
        public static object CreatDtoFromDataReader(Type type, IDataReader rd)
        {
            object obj = Activator.CreateInstance(type);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dicNameDr = new Dictionary<string, object>();

            for (int i = 0; i <= rd.FieldCount - 1; i++)
            {
                dicNameDr.Add(rd.GetName(i), rd[rd.GetName(i)]);
            }
            foreach (var prop in props)
            {
                if (dicNameDr.ContainsKey(prop.Name))
                {
                    prop.SetValue(obj, dicNameDr[prop.Name], null);
                }
            }
            return obj;
        }

        public static bool Insert(object source)
        {
            // gen sql insert
            var typeSoure = source.GetType();
            string strTableName = GetNameDataTable(typeSoure);
            var lstPropSource = typeSoure.GetProperties();
            var lstFieldName = GetListColumnInDB(strTableName);
            // loại bỏ trường ID
            lstFieldName.RemoveAll(x => x.ToUpper().Equals("ID"));
            string strSqlInser = "INSERT INTO " + strTableName + " (" + String.Join(",", lstFieldName) + ") VALUES ( " + BuilderSqlValue(source, lstFieldName) + ")";

            //return cmd.ExecuteNonQuery() == 1 ? true : false;

            var cmd = new SqlCommand(strSqlInser, Connection.ConnectToSQLDataBase());
            cmd.CommandType = CommandType.Text;
            var bInsert= cmd.ExecuteNonQuery() == 1 ? true : false;


            //var cmdSql = new SqlCommand(strSqlInser, Connection.ConnectToSQLDataBase());
            //cmdSql.CommandType = CommandType.Text;
            //bInsert= cmdSql.ExecuteNonQuery() == 1 ? true : false;

            return bInsert;
        }

        public static bool Update(object source)
        {
            // gen sql insert
            var typeSoure = source.GetType();
            string strTableName = GetNameDataTable(typeSoure);
            var lstPropSource = typeSoure.GetProperties();
            var lstFieldName = GetListColumnInDB(strTableName);
            string strSqlInser = "UPDATE " + GetNameDataTable(typeSoure) + " SET " + BuilderSqlValue(source, lstFieldName, true);
            var cmd = new SqlCommand(strSqlInser, Connection.ConnectToSQLDataBase());
            var bHoanThanh = cmd.ExecuteNonQuery() == 1 ? true : false;
            return bHoanThanh;
        }



        public static bool Delete(object source)
        {
            // gen sql insert
            var typeSoure = source.GetType();
            var lstPropSource = source.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == "id");

            // loại bỏ trường ID
            string strSqlInser = "DELETE FROM " + GetNameDataTable(typeSoure) + " WHERE ID=" + lstPropSource.GetValue(source);
            var cmd = new SqlCommand(strSqlInser, Connection.ConnectToSQLDataBase());
            var bHoanThanh = cmd.ExecuteNonQuery() == 1 ? true : false;
            return bHoanThanh;
        }

        public static string GetNameDataTable(Type typeData)
        {
            return typeData.Name.Replace("Model", "");
        }

        public static List<string> GetListColumnInDB(string tableName)
        {
            var lstResult = new List<string>();
            string query = string.Format("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", tableName);
            var cmd = new SqlCommand(query, Connection.ConnectToSQLDataBase());
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dtoResult = CreatDtoFromDataReader(typeof(DbColumnModel), dr) as DbColumnModel;
                    lstResult.Add(dtoResult.COLUMN_NAME);
                }
            }
            return lstResult;
        }

        public static string BuilderSqlValue(object dtoSource, List<string> lstFieldName = null, bool isAddWhere = false)
        {
            var lstPropSource = dtoSource.GetType().GetProperties();
            string strWhere = " WHERE ID=";
            var lstValue = new List<string>();
            foreach (var prop in lstPropSource)
            {
                //Nếu trong db không có tên cột này thì bỏ qua
                if (!lstFieldName.Contains(prop.Name))
                {
                    continue;
                }
                if (prop.Name.ToLower().Equals("id"))
                {
                    strWhere += prop.GetValue(dtoSource);
                    continue;
                }
                var strValue = "";
                if (isAddWhere)// nếu là update
                {
                    strValue += prop.Name + "=";
                }
                // kiểm tra kiểu dữ liệu
                switch (prop.PropertyType.Name.ToLower())
                {
                    case "string":
                        strValue += "N'" + prop.GetValue(dtoSource) + "'";
                        break;
                    case "bool":
                        strValue += "'" + ((bool)prop.GetValue(dtoSource) == false ? "0" : "1") + "'";
                        break;
                    case "int":
                        strValue += prop.GetValue(dtoSource).ToString();
                        break;
                    case "decimal":
                        strValue += prop.GetValue(dtoSource).ToString();
                        break;
                    case "double":
                        strValue += prop.GetValue(dtoSource).ToString();
                        break;
                    case "datetime":
                        strValue += "'" + Convert.ToDateTime(prop.GetValue(dtoSource)).ToString("yyyy/MM/dd HH:mm") + "'";
                        break;
                    case "boolean":
                        strValue += "'" + ((Boolean)prop.GetValue(dtoSource) == false ? "0" : "1") + "'";//
                        break;
                    case "int32":
                        strValue += prop.GetValue(dtoSource).ToString();
                        break;
                    default:
                        strValue += "'" + prop.GetValue(dtoSource) + "'";
                        break;
                }
                lstValue.Add(strValue);
            }
            var strResult = string.Join(",", lstValue);
            if (isAddWhere)
            {
                strResult += strWhere;
            }
            return strResult;
        }
    }
}
