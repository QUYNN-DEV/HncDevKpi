using System.Data.SqlClient;

namespace Core.Config
{
    public class Connection
    {

        //public static MySqlConnection ConnectToMySqlDataBase()
        //{
        //    string connetionString = @"Server=sql3.freemysqlhosting.net;Port=3306;Database=sql3322621;Uid=sql3322621;Pwd=Q7EnVZY5Jt;CharSet=utf8;Convert Zero Datetime=True;persistsecurityinfo=True;SslMode=none";
        //    MySqlConnection cnn = new MySqlConnection(connetionString);
        //    cnn.Open();
        //    return cnn;
        //}

        public static SqlConnection ConnectToSQLDataBase()
        {
            string connetionString = @"Data Source=mssql-dev.fastlink.vn;Initial Catalog=HNC_DEV;User ID=updatedata;Password=upd@ted@t@";
            SqlConnection cnnSql = new SqlConnection(connetionString);
            cnnSql.Open();
            return cnnSql;
        }
    }


}
