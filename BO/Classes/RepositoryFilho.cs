using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class RepositoryFilho
    {
        private string TabelaFilha { get; set; }
        private string PkPai { get; set; }
        private string PkFilho { get; set; }

        public RepositoryFilho(string TabelaFilha, string PkPai, string PkFilho)
        {
            this.TabelaFilha = TabelaFilha;
            this.PkPai = PkPai;
            this.PkFilho = PkFilho;
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Inject]{0}"+
                      "public UnitOfWorkBase UndTrabalho { get; set; }{0}{0}" +

                      "private DataAccessor<"+TabelaFilha+"Model> regAcessor;{0}{0}" +

                      "public void Save(" + TabelaFilha + "Model obj" + TabelaFilha + "){0}" +
                      "{{0}" +
                      "    obj" + TabelaFilha + "."+PkFilho+" = (int)UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                      "   \"[dbo].[Proc_save_"+TabelaFilha+"]\",{0}" +
                      "    ParameterBase<" + TabelaFilha + "Model>.SetParameterValue(obj" + TabelaFilha + "));{0}{0}" +

                      "    obj" + TabelaFilha + ".SetStatusRegistro(BaseModelFilhos.statusRegistroFilho.SemMudanca);{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Update()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Update(" + TabelaFilha + "Model obj" + TabelaFilha + "){0}" +
                      "{{0}" +
                      "    UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                      "    \"[dbo].[Proc_update_" + TabelaFilha + "]\",{0}" +
                      "    ParameterBase<" + TabelaFilha + "Model>.SetParameterValue(obj" + TabelaFilha + "));{0}{0}" +

                      "    obj" + TabelaFilha + ".SetStatusRegistro(BaseModelFilhos.statusRegistroFilho.SemMudanca);{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Delete(" + TabelaFilha + "Model obj" + TabelaFilha + "){0}" +
                      "{{0}" +
                      "    UndTrabalho.dbPrincipal.ExecuteScalar(\"[dbo].[Proc_delete_" + TabelaFilha + "]\",{0}" +
                      "          UserData.idUser,{0}" +
                      "          obj" + TabelaFilha + "."+PkFilho+");{0}{0}" +

                      "    obj" + TabelaFilha + ".SetStatusRegistro(BaseModelFilhos.statusRegistroFilho.SemMudanca);{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Delete2()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Delete(int "+PkPai+"){0}"+
                      "{{0}" +
                      "    UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,{0}" +
                      "      \"DELETE " + TabelaFilha + " WHERE " + PkPai + " = \" + " + PkPai + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Copy(" + TabelaFilha + "Model obj" + TabelaFilha + "){0}" +
                      "{{0}" +
                      "     obj" + TabelaFilha + "."+PkFilho+" = null;{0}" +
                      "     obj" + TabelaFilha + "." + PkFilho + " = (int)UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                      "                                    UndTrabalho.dbTransaction,{0}" +
                      "                                    \"[dbo].[Proc_save_"+TabelaFilha+"]\",{0}" +
                      " ParameterBase<" + TabelaFilha + "Model>.SetParameterValue(obj" + TabelaFilha + "));{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public " + TabelaFilha + "Model Get" + TabelaFilha + "(int "+PkFilho+"){0}" +
                      "{{0}" +
                      "    if (regAcessor == null){0}" +
                      "    {{0}" +
                      "         regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor(\"[dbo].[Proc_sel_" + TabelaFilha + "]\",{0}" +
                      "            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>(\""+PkFilho+"\"),{0}" +
                      "            MapBuilder<" + TabelaFilha + "Model>.MapAllProperties().Build());{0}" +
                      "    }{0}" +
                      "    return regAcessor.Execute("+PkFilho+").FirstOrDefault();{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public List<"+ TabelaFilha +"Model> GetAll"+ TabelaFilha +"(int "+PkPai+"){0}"+
                      "{{0}" +
                      "    DataAccessor<" + TabelaFilha + "Model> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor{0}" +
                      "    (\"SELECT * FROM " + TabelaFilha + " WHERE " + PkPai + " = @" + PkPai + "\", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>(\"" + PkPai + "\"),{0}" +
                      "    MapBuilder<" + TabelaFilha + "Model>.MapAllProperties().Build());{0}{0}" +

                      "    return reg.Execute(" + PkPai + ").ToList();{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }
    }
}