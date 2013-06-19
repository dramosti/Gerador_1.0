using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ProcViewDAO
    {
        ConexaoDAO _objConexao;

        public ProcViewDAO(string vservidor, string vuser, string vpassword,
            string vdataBase, byte vtipoConexao)
        {
            _objConexao = new ConexaoDAO(servidor: vservidor, userId: vuser, senha: vpassword,
                dataBase: vdataBase, tipoConexao: vtipoConexao);
        }

        public DataTable GetProcView(string vobj)
        {
            DataTable dt = new DataTable();
            if (!_objConexao.isConectado())
            {
                _objConexao.Conectar();
            }

            SqlDataAdapter adapter =
                new SqlDataAdapter("select * from "+vobj+" order by name"
                    , _objConexao.GetConexao());

            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _objConexao.CloseConnection();
            }
        }

        protected DataTable GetProcedureView(string nomeProc)
        {
            DataTable dt = new DataTable();
            if (!_objConexao.isConectado())
            {
                _objConexao.Conectar();
            }

            SqlDataAdapter adapter =
                new SqlDataAdapter("execute sp_helptext["+nomeProc+"]"
                    , _objConexao.GetConexao());

            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _objConexao.CloseConnection();
            }
        }

        //public void ExecutarProcView(string[] vprocview, string vnomeprocview)
        //{
        //    int _count = 0;
        //    string _script = "";
        //    while (_count < vprocview.Count())
        //    {
        //        _script += vprocview[_count]+Environment.NewLine;
        //        _count++;
        //    }

        //    if(VerificaProcView(vnomeprocview))
        //    {
        //        _script = _script.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
        //    }

        //    if (!_objConexao.isConectado())
        //    {
        //        _objConexao.Conectar();
        //    }

        //    SqlCommand _comando = new SqlCommand(_script, _objConexao.GetConexao());

        //    try
        //    {
        //        _comando.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {                
        //        throw;
        //    }
        //}

        public void ExecutarProcView(string vprocview, string vnomeprocview)
        {
            if (VerificaProcView(vnomeprocview))
            {
                if(vprocview.Contains("CREATE PROCEDURE"))
                {
                    vprocview = vprocview.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
                }
                else if (vprocview.Contains("CREATE VIEW"))
                {
                    vprocview = vprocview.Replace("CREATE VIEW", "ALTER VIEW");
                }
                else if (vprocview.Contains("CREATE TRIGGER"))
                {
                    vprocview = vprocview.Replace("CREATE TRIGGER", "ALTER TRIGGER");
                }
                else
                {
                    return;
                }             
            }

            if (!_objConexao.isConectado())
            {
                _objConexao.Conectar();
            }

            SqlCommand _comando = new SqlCommand(vprocview, _objConexao.GetConexao());

            try
            {
                _comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificaProcView(string vnomeprocview)
        {
            if(!_objConexao.isConectado())
            {
                _objConexao.Conectar();
            }

            SqlCommand _comando = new SqlCommand("select COUNT(*) from SYSOBJECTS where name = '" +
                vnomeprocview + "'", _objConexao.GetConexao());

            if((int)_comando.ExecuteScalar() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
