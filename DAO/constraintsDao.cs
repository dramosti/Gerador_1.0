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

        public DataTable GetConstraintsDao(string sTable)
        {
            DataTable dt = new DataTable();

            if (!isConectado())
            {
                Conectar();
            }
            try
            { 

                SqlDataAdapter adapter = new SqlDataAdapter("select distinct(inf.COLUMN_NAME) "+
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

        public DataTable GetValorCopyDao(string sTable, string sCampo, string sValue)
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
        
    }
}
