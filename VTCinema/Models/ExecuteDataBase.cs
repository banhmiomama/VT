using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VTTECH_2019_08_20.Models
{
    class ExecuteDataBase : IDisposable
    {

        private SqlConnection _conn;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public void Dispose()
        {
        }
        ~ExecuteDataBase()
        {
            //Dispose(false);
        }
        public ExecuteDataBase()
        {
            CreateConnect();
        }
        private void CreateConnect()
        {
            try
            {
                string connectionString = String.Format(@"Server={0}; " + "Initial Catalog={1}; User ID={2};Password={3};Trusted_Connection=false; "
                       , "103.48.191.134"
                       , "VTT_Cosmetic_Mini"
                       , "vttechsolution"
                       , "P@assword123@vttech");
                _conn = new SqlConnection(connectionString);
                if (_conn.State == ConnectionState.Closed) _conn.Open();
            }
            catch (Exception ex)
            {
                // Connect Local
            }
        }




        public string ExecuteDatabaseLog(string s)
        {
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            SqlCommand command = _conn.CreateCommand();
            SqlTransaction transaction = _conn.BeginTransaction();
            command.Transaction = transaction; command.CommandText = @s;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                EnterLog(s);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return "";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
            }
        }
        public string ExecuteDatabaseNoLog(string s)
        {
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            SqlCommand command = _conn.CreateCommand();
            SqlTransaction transaction = _conn.BeginTransaction();
            command.Transaction = transaction;
            command.CommandText = @s;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();

                if (_conn.State == ConnectionState.Open) _conn.Close();
                return "";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
            }
        }
        public DataTable LoadDataSource_Table(string s)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                SqlCommand cmd = new SqlCommand(@s, _conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("myTable");
                da.Fill(table);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return table;
            }
            catch
            {
                return null;
            }
        }

        internal DataTable ExecuteDataTable(string v1, CommandType storedProcedure, string v2, SqlDbType int1, object serviceCat_ID, string v3, SqlDbType nVarChar1, object name, string v4, SqlDbType int2, object amount, string v5, SqlDbType nVarChar2, object note)
        {
            throw new NotImplementedException();
        }

        public DataSet LoadDataSource_DataSet(string s)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                SqlCommand cmd = new SqlCommand(@s, _conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataTable LoadPara(string paraTypeName)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                DataTable table = new DataTable("myTable");
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    table = confunc.ExecuteDataTable("YYY_sp_LoadCombo_Para", CommandType.StoredProcedure,
                      "@paraTypeName", SqlDbType.NVarChar, paraTypeName.Trim());
                }
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return table;
            }
            catch
            {
                return null;
            }
        }
        public int ExecuteScalar(string s)
        {
            int ID;
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            if (!s.EndsWith(";"))
            {
                s = s + ";";
            }
            SqlCommand command = _conn.CreateCommand();
            SqlTransaction transaction = _conn.BeginTransaction();
            command.Transaction = transaction;
            command.CommandText = @s + "SELECT CAST(scope_identity() AS int);";
            try
            {
                ID = (int)command.ExecuteScalar();
                transaction.Commit();
                EnterLog(s);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return ID;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }
        public void EnterLog(string sqlString, string filename = "", string functioname = "")
        {
            //try
            //{
            //    if (_conn.State == ConnectionState.Closed) _conn.Open();
            //    string sql = "INSERT INTO KIM_Log(Content,FileName,FunctionName,Created,Created_By,State) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";
            //    string currentPrefix = ConfigurationManager.AppSettings["prefixTableNameCurrent"];
            //    string newPrefix = ConfigurationManager.AppSettings["prefixTableNameNew"];
            //    if (currentPrefix != newPrefix)
            //        sql = sql.Replace(currentPrefix, newPrefix);
            //    SqlCommand cmd = new SqlCommand(sql, _conn);
            //    cmd.Parameters.AddWithValue("@param1", sqlString);
            //    cmd.Parameters.AddWithValue("@param2", filename);
            //    cmd.Parameters.AddWithValue("@param3", functioname);
            //    cmd.Parameters.AddWithValue("@param4", new Common().GetDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss"));
            //    cmd.Parameters.AddWithValue("@param5", Global.sys_userID);
            //    cmd.Parameters.AddWithValue("@param6", 1);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        public DataTable ExecuteDataTable(string sql,
            CommandType commandType,
            params object[] pars)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                SqlCommand com = new SqlCommand(sql, _conn);
                com.CommandType = commandType;
                com.CommandTimeout = 10000;
                for (int i = 0; i < pars.Length; i += 3)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    par.Value = pars[i + 2];
                    com.Parameters.Add(par);
                }

                SqlDataAdapter dad = new SqlDataAdapter(com);
                //EnterLog(sql);
                DataTable dt = new DataTable();
                dad.Fill(dt);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Execute a SQL and return a Datatable and keep Connection(not close)
        /// </summary>
        /// <param name="con">SqlConnection</param>
        /// <param name="sql">sql string</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="pars">Sql parameter: "@Name", SqlDbType, Value ("@id",SqlDbType.int, 1 [, ...])</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTableLog(string sql,
            CommandType commandType,
            params object[] pars)
        {
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            SqlCommand com = new SqlCommand(sql, _conn);
            com.CommandType = commandType;
            com.CommandTimeout = 10000;
            for (int i = 0; i < pars.Length; i += 3)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                par.Value = pars[i + 2];
                com.Parameters.Add(par);
            }

            SqlDataAdapter dad = new SqlDataAdapter(com);
            EnterLog(sql);
            DataTable dt = new DataTable();
            dad.Fill(dt);
            if (_conn.State == ConnectionState.Open) _conn.Close();
            return dt;
        }


        /// <summary>
        /// Execute a SQL and return a Datatable and keep Connection(not close)
        /// </summary>
        /// <param name="con">SqlConnection</param>
        /// <param name="sql">sql string</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="pars">Sql parameter: "@Name", SqlDbType, Value ("@id",SqlDbType.int, 1 [, ...])</param>
        /// <returns>DataTable</returns>
        public DataSet ExecuteDataSet(string sql,
            CommandType commandType,
            params object[] pars)
        {
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            SqlCommand com = new SqlCommand(sql, _conn);
            com.CommandType = commandType;
            com.CommandTimeout = 10000;
            for (int i = 0; i < pars.Length; i += 3)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                par.Value = pars[i + 2];
                com.Parameters.Add(par);
            }

            SqlDataAdapter dad = new SqlDataAdapter(com);
            //EnterLog(sql);
            DataSet ds = new DataSet();
            dad.Fill(ds);
            if (_conn.State == ConnectionState.Open) _conn.Close();
            return ds;
        }
        public DataSet ExecuteDataSetLog(string sql,
            CommandType commandType,
            params object[] pars)
        {
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            SqlCommand com = new SqlCommand(sql, _conn);
            com.CommandType = commandType;
            com.CommandTimeout = 10000;
            for (int i = 0; i < pars.Length; i += 3)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                par.Value = pars[i + 2];
                com.Parameters.Add(par);
            }

            SqlDataAdapter dad = new SqlDataAdapter(com);
            EnterLog(sql);
            DataSet ds = new DataSet();
            dad.Fill(ds);
            if (_conn.State == ConnectionState.Open) _conn.Close();
            return ds;
        }

        public DataTable LoadEmployee(int GroupID, int Branch_ID)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                DataTable table = new DataTable("myTable");
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    table = confunc.ExecuteDataTable("YYY_sp_LoadCombo_Employee", CommandType.StoredProcedure,
                      "@GroupID", SqlDbType.Int, GroupID,
                      "@Branch_ID", SqlDbType.Int, Branch_ID);
                }
                if (_conn.State == ConnectionState.Open) _conn.Close();
                return table;
            }
            catch
            {
                return null;
            }
        }


    }
}