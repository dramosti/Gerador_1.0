using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class ViewDAO
    {
        ConexaoDAO _objConexao;

        public ViewDAO(string vservidor, string vuser, string vpassword,
            string vdataBase, byte vtipoConexao)
        {
            _objConexao = new ConexaoDAO(servidor: vservidor, userId: vuser, senha: vpassword,
                dataBase: vdataBase, tipoConexao: vtipoConexao);
        }
    }
}
