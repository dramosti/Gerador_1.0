using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BO
{
    public class ProcViewBO : ProcViewDAO
    {
        public ProcViewBO(string vservidor, string vuser, string vpassword,
            string vdataBase, byte vtipoConexao)
            : base(vservidor: vservidor, vuser: vuser,
                vpassword: vpassword, vdataBase: vdataBase, vtipoConexao: vtipoConexao)
        {

        }

        public void GetProcedureView(string vProcedure, ref string[] vvwProcedure)
        {
            DataTable _dt = new DataTable();
            _dt = base.GetProcedureView(vProcedure);            
            vvwProcedure = new string[_dt.Rows.Count];
            int _cont = 0;

            foreach (DataRow row in _dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    vvwProcedure[_cont] = item.ToString();
                }                
                _cont++;
            }
        }

        public void GetProcedureView(string vProcedure, ref string[] vvwProcedure,
            string vCaminho)
        {
            vvwProcedure = File.ReadAllLines(vCaminho + @"\" + vProcedure);
        }

        public bool SalvarProcedureView(string vProcView, string vCaminho, string vArquivo)
        {
            DirectoryInfo _di = new DirectoryInfo(vCaminho);
            if(!_di.Exists)
            {
                Directory.CreateDirectory(vCaminho);
            }

            FileInfo _fi = new FileInfo(vCaminho+"\\"+vArquivo);
            bool _salva = true;
            

            if (_fi.Exists)
            {
                DialogResult _result = MessageBox.Show("Arquivo "+vCaminho+vArquivo+" já existe, deseja sobreescrever?", "Sobreescrever?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ( _result == DialogResult.No)
                {
                    _salva = false;
                }
            }

            if (_salva)
            {
                File.Create(vCaminho+"\\"+vArquivo).Close();

                StreamWriter _sw = new StreamWriter(vCaminho+"\\"+vArquivo);

                _sw.Write(vProcView);

                _sw.Close();
                return true;
            }

            return false;
        }

        public void SalvarProcedureView(string[] vProcView, string vCaminho, string vArquivo)
        {
            File.Create(vCaminho+"\\"+vArquivo).Close();

            StreamWriter _sw = new StreamWriter(vCaminho+"\\"+vArquivo);

            StringBuilder _sb = new StringBuilder();

            foreach (string linha in vProcView)
            {
                _sb.Append(linha);
            }
            _sw.Write(_sb);

            _sw.Close();
        }

        public bool VerificaProcView(string vCaminho, string vArquivo)
        {
            DirectoryInfo _di = new DirectoryInfo(vCaminho);
            if (!_di.Exists)
            {
                Directory.CreateDirectory(vCaminho);
            }

            FileInfo _fi = new FileInfo(vCaminho + "\\" + vArquivo);

            if (_fi.Exists)
            {
                return true;
            }

            return false;
        }
    }
}
