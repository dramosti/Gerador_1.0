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
    public class TabelasDAO : ServidorDAO
    {
        public string nmView { get; set; }

        private List<TabelaModel> _tabelasDetalhes;

        public DataTable GetTabelas()
        {
            try
            {
                DataTable dt = new DataTable();

                if (!isConectado())
                {
                    Conectar();
                }
                // Aaki já tras todas as tabelas do banco que esta conectado...
                SqlDataAdapter adapter = new SqlDataAdapter("select * from INFORMATION_SCHEMA.Tables where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME", GetConexao());
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

        public List<TabelaModel> GetDetalhes(string sNomeTabela) //este metodo tras todas as colunas da tabela e preenche na lista de objetos
        {
            DataTable dt = new DataTable();

            try
            {            
                _tabelasDetalhes = new List<TabelaModel>();

                if (!isConectado())
                {
                    Conectar();
                }
                SqlCommand command = new SqlCommand("sp_columns", GetConexao());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@table_name", sNomeTabela);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {

                    _tabelasDetalhes.Add(new TabelaModel
                    {
                        NomeTabela = row[2].ToString(),
                        TabelaOwner = row[1].ToString(),
                        NomeColuna = row[3].ToString(),
                        TipoColuna = row[5].ToString(),
                        Tamanho = row[7].ToString(),
                        CasasDecimais = row[8].ToString(),
                        Precisao = row[6].ToString(),
                        IsNullable = row[10].ToString()
                    });
                }

                return _tabelasDetalhes;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                CloseConnection();
                dt.Dispose();
            }
        }

        public List<string> CarregaPK(string sNomeTabela)
        {
            StringBuilder squery = new StringBuilder();
            squery.Append("SELECT syscolumns.name AS Coluna ");
            squery.Append("FROM sysindexes ");
            squery.Append("INNER JOIN sysindexkeys ");
            squery.Append("ON sysindexes . id    = sysindexkeys . id ");
            squery.Append("AND sysindexes . indid = sysindexkeys . indid ");
            squery.Append("INNER JOIN syscolumns ");
            squery.Append("ON sysindexes . id = syscolumns . id ");
            squery.Append("AND sysindexkeys . colid = syscolumns . colid ");
            squery.Append("WHERE OBJECTPROPERTY ( OBJECT_ID ( sysindexes . name), 'IsPrimaryKey' ) = 1 ");
            squery.Append("AND OBJECT_ID ('{0}') = sysindexkeys . id");

            try
            {
                DataTable dt = new DataTable();
                List<string> lPK = new List<string>();

                if (!isConectado())
                {
                    Conectar();
                }
                SqlCommand cmd = new SqlCommand(string.Format(squery.ToString(), sNomeTabela), GetConexao());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                
                foreach (DataRow dr in dt.Rows)
                {
                    lPK.Add(dr["Coluna"].ToString());
                }

                return lPK;
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

        public DataTable GetListaTabFilha(string nmTabPai)
        {
            try
            {
                DataTable dt = new DataTable();

                if (!isConectado())
                {
                    
                    Conectar();
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT    OBJECT_NAME(constid) FK, OBJECT_NAME(FKEYID) Tabela_Filha, OBJECT_NAME(rKEYID) Tabela_Pai, COL_NAME(Rkeyid, Rkey) Colunas_Pai, COL_NAME(fkeyid, fkey) Colunas_Filha" +
                                                            " FROM    SYSFOREIGNKEYS where OBJECT_NAME(rKEYID) = '"+nmTabPai+"'", GetConexao());
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

        public string GetView(string nmTabela)
        {
            try
            {
                nmTabela = "vw"+ nmTabela.Replace("_", "");
                nmView = nmTabela;

                DataTable dt = new DataTable();
                StringBuilder view = new StringBuilder();

                if (!isConectado())
                {
                    
                    Conectar();
                }

                SqlCommand cmd = new SqlCommand("sp_helptext", GetConexao());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@objname", nmTabela);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (!row[0].ToString().Equals("\r\n"))
                    {
                        view.Append(row[0].ToString() + "{0}");
                    }
                }

                return view.ToString().Replace("{0}", "\r\n");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public DataTable GetColunasByTabelaDao(string vNomeTabela)
        {
            try
            {
                DataTable dt = new DataTable();
                DataBase = Static.sBase;
                UserId = Static.sUser;
                Senha = Static.sPassword;
                TipoConexao = Static.bTipoConexao;
                Servidor = Static.sServidor;

                if (!isConectado())
                {

                    Conectar();
                }

                SqlDataAdapter adapter = new SqlDataAdapter("select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS"+
                    " where TABLE_NAME = '"+vNomeTabela+"'", GetConexao());
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
