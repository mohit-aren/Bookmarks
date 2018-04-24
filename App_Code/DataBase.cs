using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;


    public class DbCall
    {
        private int conn1 = 0;

        public DbCall()
        {
        }

        public void set_conn1(int value)
        {
            conn1 = value;
        }

        public DataSet ExecuteQuery(string sql)
        {
            try
            {
                string conn_str = "";
                conn_str = System.Configuration.ConfigurationManager.AppSettings.Get("DBCONN");
 
                SqlConnection objconn = new SqlConnection(conn_str);

                SqlCommand objcomm = new SqlCommand(sql, objconn);
                objconn.Open();

                SqlDataAdapter objadap = new SqlDataAdapter(objcomm);

                DataSet ds = new DataSet();

                objadap.Fill(ds);
                objadap.Dispose();
                objcomm.Dispose();
                objconn.Close();
                objconn.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter("C:\\temp\\Portalerr.txt");
                sw.WriteLine(ex.Message + ex.InnerException + sql);
                sw.Close();

                throw ex;
                //return null;
            }
            finally
            {
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                string conn_str = "";
                conn_str = System.Configuration.ConfigurationManager.AppSettings.Get("DBCONN");

                //string conn_str = "Provider=Microsoft.Jet.Sql.4.0;Data Source=D:\\Proj Mgmt\\AccountCorr\\CorrDet.mdb;User Id=;Password=;";
                SqlConnection objconn = new SqlConnection(conn_str);

                SqlCommand objcomm = new SqlCommand(sql, objconn);
                objconn.Open();

                objcomm.ExecuteNonQuery();

                objcomm.Dispose();
                objconn.Close();
                objconn.Dispose();

                return 1;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter("C:\\temp\\Portalerr.txt");
                sw.WriteLine(ex.Message + ex.InnerException + sql);
                sw.Close();

                //throw ex;
                return 0;
            }
            finally
            {
            }
        }
    }
