using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class RepositoryNormal
    {
        private string NmTabela { get; set; }
        private string NmPk { get; set; }

        public RepositoryNormal(string nmTabela, string pk)
        {
            this.NmTabela = nmTabela;
            this.NmPk = pk;
        }

        public string Inject()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Inject]{0}"+
                      "public UnitOfWorkBase UndTrabalho { get; set; }{0}{0}" +

                      "private DataAccessor<" + NmTabela + "Model> reg" + NmTabela + "Accessor;{0}" +
                      "private DataAccessor<" + NmTabela + "Model> regAll" + NmTabela + "Accessor;{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Save(" + NmTabela + "Model obj" + NmTabela + "){0}" +
                      "{{0}" +
                      "    obj" + NmTabela + "."+NmPk+" = (int)UndTrabalho.dbPrincipal.ExecuteScalar(\"dbo.Proc_save_"+NmTabela+"\",{0}" +
                      "    ParameterBase<" + NmTabela + "Model>.SetParameterValue(obj" + NmTabela + "));{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Delete(int "+NmPk+"){0}" +
                      "{{0}" +
                      "    UndTrabalho.dbPrincipal.ExecuteScalar(\"dbo.Proc_delete_"+NmTabela+"\",{0}" +
                      "         UserData.idUser,{0}" +
                      "         "+NmPk+");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public int Copy(int "+NmPk+"){0}"+
                      "{{0}" +
                      "    return (int)UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                      "              \"dbo.Proc_copy_"+NmTabela+"\",{0}" +
                      "               "+NmPk+");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public " + NmTabela + "Model Get" + NmTabela + "(int "+NmPk+"){0}" +
                      "{{0}" +
                      "    if (reg" + NmTabela + "Accessor == null){0}" +
                      "    {{0}" +
                      "          reg" + NmTabela + "Accessor = UndTrabalho.dbPrincipal.CreateSprocAccessor(\"dbo.Proc_sel_" + NmTabela + "\",{0}" +
                      "                           new Parameters(UndTrabalho.dbPrincipal){0}" +
                      "                           .AddParameter<int>(\""+NmPk+"\"),{0}" +
                      "                           MapBuilder<" + NmTabela + "Model>.MapAllProperties().Build());{0}" +
                      "    }{0}{0}" +
                      "    return reg" + NmTabela + "Accessor.Execute("+NmPk+").FirstOrDefault();{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public List<" + NmTabela + "Model> GetAll" + NmTabela + "(){0}" +
                      "{{0}" +
                      "    if (regAll" + NmTabela + "Accessor == null){0}" +
                      "    {{0}" +
                      "        regAll" + NmTabela + "Accessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(\"SELECT * FROM " + NmTabela + "\",{0}" +
                      "                        MapBuilder<" + NmTabela + "Model>.MapAllProperties().Build());{0}" +
                      "    }{0}" +
                      "    return regAll" + NmTabela + "Accessor.Execute().ToList();{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

    }
}
