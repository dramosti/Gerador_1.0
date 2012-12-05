using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class ServicePai
    {
        private List<string> _TabelasFilhas = new List<string>();
        private List<string> TabelasFilhas 
        {
            get { return _TabelasFilhas; }
            set { _TabelasFilhas = value; }
        }
        private string TabelaPai { get; set; }
        private string PkPai { get; set; }

        public ServicePai(string tabelaPai, string pkPai, List<string> tabelasFilhas)
        {
            this.TabelasFilhas = tabelasFilhas;
            this.TabelaPai = tabelaPai;
            this.PkPai = pkPai;
        }

        public string Inject()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Inject]{0}"+
                      "public I"+TabelaPai+"Repository _"+TabelaPai+"Repository { get; set; }{0}{0}");

            foreach (string filha in TabelasFilhas)
            {
                sb.Append("[Inject]{0}" +
                          "public I" + filha + "Repository _" + filha + "Repository { get; set; }{0}{0}");
            }

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public " + TabelaPai + "Model Get" + TabelaPai + "(int " + PkPai + ", bool bChildren = false){0}" +
                      "{{0}" +
                      "    " + TabelaPai + "Model obj" + TabelaPai + " = _" + TabelaPai + "Repository.Get" + TabelaPai + "(" + PkPai + ");{0}{0}" +

                      "    if (bChildren){0}" +
                      "    {{0}");
                    

            foreach (string filho in TabelasFilhas)
            {
                sb.Append("        obj" + TabelaPai + ".l" + filho + " = _" + filho + "Repository.GetAll" + filho + "(" + PkPai + ");{0}");
            }

            sb.Append("    }{0}{0}"+

                      "    return obj" + TabelaPai + ";{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Save()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("public void Save(" + TabelaPai + "Model obj" + TabelaPai + "){0}" +
                      "{{0}" +
                      "    try{0}" +
                      "    {{0}" +
                      "        _" + TabelaPai + "Repository.BeginTransaction();{0}" +
                      "        _" + TabelaPai + "Repository.Save(obj" + TabelaPai + ");{0}{0}");

            foreach (string filha in TabelasFilhas)
            {
                sb.Append("        #region " + filha + "{0}" +
                          "        foreach (" + filha + "Model item in obj" + TabelaPai + ".l" + filha + ".Where(p => p.GetStatusRegistro() == BaseModelFilhos.statusRegistroFilho.Incluido)){0}" +
                          "        {{0}" +
                          "            //Aqui deve-se setar as Fks' que devem ser carregadas de classes estaticas (se houver){0}" +
                          "            //Exemplo:{0}" +
                          "            //item.idUsuario = (int)AcessoUser.idUser;{0}{0}" +

                          "            item." + PkPai + " = (int)obj" + TabelaPai + "." + PkPai + ";{0}" +
                          "            _" + filha + "Repository.Save(item);{0}" +
                          "        }{0}" +
                          "        foreach (" + filha + "Model item in obj" + TabelaPai + ".l" + filha + ".Where(p => p.GetStatusRegistro() == BaseModelFilhos.statusRegistroFilho.Alterado)){0}" +
                          "        {{0}" +
                          "              _" + filha + "Repository.Update(item);{0}" +
                          "        }{0}" +
                          "        foreach (" + filha + "Model item in obj" + TabelaPai + ".l" + filha + ".Where(p => p.GetStatusRegistro() == BaseModelFilhos.statusRegistroFilho.Excluido)){0}" +
                          "        {{0}" +
                          "            _" + filha + "Repository.Delete(item);{0}" +
                          "        }{0}" +
                          "        #endregion{0}{0}");
            }

            sb.Append("        _" + TabelaPai + "Repository.CommitTransaction();{0}{0}" +

                      "    }{0}" +
                      "    catch (Exception){0}" +
                      "    {{0}" +
                      "        _" + TabelaPai + "Repository.RollackTransaction();{0}" +
                      "        throw;{0}" +
                      "    }{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");

        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Delete(" + TabelaPai + "Model obj" + TabelaPai + "){0}" +
                      "{{0}" +
                      "      try{0}" +
                      "      {{0}{0}" +

                      "          _" + TabelaPai + "Repository.BeginTransaction();{0}{0}");

            foreach (string filha in TabelasFilhas)
	        {
		        sb.Append("          //Deleta Filho{0}"+
                          "          _" + filha + "Repository.Delete((int)obj" + TabelaPai + "."+PkPai+");{0}{0}");
	        }

            sb.Append("          _" + TabelaPai + "Repository.Delete(obj" + TabelaPai + ");{0}" +
                      "          _" + TabelaPai + "Repository.CommitTransaction();{0}{0}" +

                      "      }{0}"+
                      "      catch (Exception){0}"+
                      "      {{0}"+
                      "          _" + TabelaPai + "Repository.RollackTransaction();{0}" +
                      "          throw;{0}"+
                      "      }{0}"+
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Copy(" + TabelaPai + "Model obj" + TabelaPai + "){0}" +
                      "{{0}" +
                      "      try{0}" +
                      "      {{0}{0}" +

                      "          _" + TabelaPai + "Repository.BeginTransaction();{0}" +
                      "          _" + TabelaPai + "Repository.Copy(obj" + TabelaPai + ");{0}{0}");

            foreach (string filha in TabelasFilhas)
            {
                sb.Append("          foreach (" + filha + "Model item in obj" + TabelaPai + ".l" + filha + "){0}" +
                          "          {{0}" +
                          "              item." + PkPai + " = (int)obj" + TabelaPai + "." + PkPai + "; //codigo do novo pai{0}" +
                          "              _" + filha + "Repository.Copy(item);{0}" +
                          "          }{0}{0}");
            }

            sb.Append("          _" + TabelaPai + "Repository.CommitTransaction();{0}" +
                      "      }{0}" +
                      "      catch (Exception){0}" +
                      "      {{0}" +
                      "          _" + TabelaPai + "Repository.RollackTransaction();{0}" +
                      "          throw;{0}" +
                      "      }{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }



    }
}
