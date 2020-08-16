using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VTCinema.Models
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
            //Dispose(true);GC.SuppressFinalize(this);
        }
   
        ~ExecuteDataBase()
        {
            //Dispose(false);
        }
        public ExecuteDataBase()
        {
            CreateConnect();
        }
        public ExecuteDataBase(string[] loc)
        {
            CreateConnect(loc);
        }
        private void CreateConnect()
        {
            try
            {

                //string connectionString = String.Format(@"Data Source=localhost;Initial Catalog=vtcinema_CINEMA; User ID=vtcinema_admin1;Password=Password@123;Trusted_Connection=false;");
                //_conn = new SqlConnection(connectionString);
                string connectionString = String.Format(@"Data Source=DESKTOP-BQS6UH7\SQLEXPRESS;Initial Catalog=VT_Cinema;Integrated Security=True");
                _conn = new SqlConnection(connectionString);
                if (_conn.State == ConnectionState.Closed) _conn.Open();
            }
            catch (Exception ex)
            {
                // Connect Local
            }
        }

        private void CreateConnect(string[] loc)
        {
            try
            {
                string connectionString = String.Format(@"Server={0}; " + "Initial Catalog={1}; User ID={2};Password={3};Trusted_Connection=false; ", loc[0]
                    , loc[1]
                    , loc[2]
                    , loc[3]);
                _conn = new SqlConnection(connectionString);
                if (_conn.State == ConnectionState.Closed) _conn.Open();
            }
            catch (Exception ex)
            {
                // Connect Local
            }
        }

        public DataTable ExecuteDataTable(string sql, CommandType commandType,params object[] pars)
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
        public DataTable ExecuteDataTableLog(string sql,CommandType commandType,params object[] pars)
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
    }
}