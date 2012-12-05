using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ConexaoDAO
    {
        private string _servidor;
        private string _userId;
        private string _senha;
        private string _dataBase;     
        private byte _tipoConexao;
        private SqlConnection conn;

        public ConexaoDAO()
        {
        }

        public ConexaoDAO(string servidor, string userId, string senha, string dataBase, byte tipoConexao)
        {
            this._servidor    = servidor;
            this._userId      = userId;
            this._senha       = senha;
            this._dataBase    = dataBase;
            this._tipoConexao = tipoConexao;
        }

        public string Servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }

        public byte TipoConexao
        {
            get { return _tipoConexao; }
            set { _tipoConexao = value; }
        }

        public void Conectar()
        {
            if (_tipoConexao == 0) //Windows Authentication
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=" + _servidor + ";Initial Catalog="+ _dataBase +";Integrated Security=true;";

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException sql)
                    {
                        throw new Exception(sql.Message); 
                    }    
                }
            }
            else if (_tipoConexao == 1) //User Authentication
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=" + _servidor + ";Initial Catalog=" + _dataBase + ";User Id=" + _userId + ";Password=" + _senha + ";";

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException sql)
                    {
                        throw new Exception(sql.Message);
                    }  
                }
            }
        }

        public SqlConnection GetConexao()
        {
            return conn;
        }

        public bool isConectado()
        {
            if (conn != null)
            {
                return (conn.State == ConnectionState.Open);
            }

            return false;
        }

        public bool CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                return true;
            }

            return false;
        }
        
    }
}
