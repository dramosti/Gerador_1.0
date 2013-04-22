using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAO
{
    public class ServidorDAO : ConexaoDAO
    {
        private List<string> _servidor;

        public List<string> GetServidores()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            if (dbProviderFactory.CanCreateDataSourceEnumerator)
            {
                DbDataSourceEnumerator dbDataSourceEnumerator = dbProviderFactory.CreateDataSourceEnumerator();

                if (dbDataSourceEnumerator != null)
                {
                    DataTable dt;
                    _servidor = new List<string>();
                    dt = dbDataSourceEnumerator.GetDataSources();

                    foreach (DataRow row in dt.Rows)
                    {
                        _servidor.Add(row[0].ToString());
                    }
                }  
            }

            return _servidor;
        }

        public DataSet GetDatabases()
        {
            try
            {
                if (!isConectado())
                {
                    Conectar();
                }
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("SELECT name FROM sys.Databases", GetConexao());
                da.Fill(ds, "sys.Databases");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
