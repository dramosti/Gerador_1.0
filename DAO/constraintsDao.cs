using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using Comum;

namespace DAO
{
    public class constraintsDao: ServidorDAO
    {
        ConexaoDAO _objConexao;

        public constraintsDao()
        {
            Servidor = Static.sServidor;
            DataBase = Static.sBase;
            TipoConexao = Static.bTipoConexao;
            UserId = Static.sUser;
            Senha = Static.sPassword;
        }

        protected DataTable GetConstraintsDao(string sTable)
        {
            DataTable dt = new DataTable();

            if (!isConectado())
            {
                Conectar();
            }
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select distinct(inf.COLUMN_NAME), inf.CONSTRAINT_NAME, inf.TABLE_NAME " +
                "from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE inf "+
                "inner join sys.key_constraints const "+
                "on inf.CONSTRAINT_NAME = const.name "+
                "inner join sys.columns c "+
                "on inf.COLUMN_NAME = c.name "+
                "where const.type = 'UQ' and inf.TABLE_NAME = '"+sTable+"' and c.system_type_id = 167 "
                                                            , GetConexao());
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected DataTable GetAllConstraintsDao()
        {
            DataTable dt = new DataTable();

            if (!isConectado())
            {
                Conectar();
            }
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select distinct(inf.COLUMN_NAME), inf.CONSTRAINT_NAME, inf.TABLE_NAME " +
                "from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE inf " +
                "inner join sys.key_constraints const " +
                "on inf.CONSTRAINT_NAME = const.name " +
                "inner join sys.columns c " +
                "on inf.COLUMN_NAME = c.name " +
                "where const.type = 'UQ' and c.system_type_id = 167 "
                                                            , GetConexao());
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected DataTable GetValorCopyDao(string sTable, string sCampo, string sValue)
        {
            DataTable dt = new DataTable();

            if (!isConectado())
            {
                Conectar();
            }
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select top(1) "+sCampo+
                    "from "+sTable+" where "+sCampo+" like '"+sValue+"%' "+
                    "order by "+sCampo+" desc " , GetConexao());
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected bool ConstrExistsDao(string sConstraints)
        {
            if (!isConectado())
            {
                Conectar();
            }
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("select count (CONSTRAINT_NAME) from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ");
                sb.Append("where CONSTRAINT_NAME = '" + sConstraints + "'");
                SqlCommand command = new SqlCommand(sb.ToString(), GetConexao());
                int cont = (int)command.ExecuteScalar();
                return cont > 0;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                CloseConnection();
            }

            
        }

        protected void ExecutConstrDao(string sScript)
        {
            SqlCommand command = new SqlCommand(sScript, GetConexao());
            command.ExecuteNonQuery();
        }
        
    }
}
