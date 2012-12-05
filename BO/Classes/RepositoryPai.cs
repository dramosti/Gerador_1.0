using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class RepositoryPai
    {
        public string TabelaPai { get; set; }
        public string PkPai { get; set; }

        public RepositoryPai(string tabelaPai, string pkPai)
        {
            TabelaPai = tabelaPai;
            PkPai = pkPai;
        }


        public string Inject()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Inject]{0}"+
                      "public UnitOfWorkBase UndTrabalho { get; set; }{0}{0}" +

                      "private DataAccessor<" + TabelaPai + "Model> reg" + TabelaPai + "Accessor;{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Save("+TabelaPai+"Model obj"+TabelaPai+"){0}"+
                       "{{0}" +
                       "    //Aqui deve-se setar as FK's (se houver){0}" +
                       "    //Exemplo:{0}" +
                       "    //produto.idEmpresa = CompanyData.idEmpresa;{0}{0}" +

                       "    if (obj"+TabelaPai+"."+PkPai+" == null){0}" +
                       "    {{0}" +
                       "        obj"+TabelaPai+"."+PkPai+" = (int)UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                       "        \"[dbo].[Proc_save_"+TabelaPai+"]\",{0}" +
                       "        ParameterBase<"+TabelaPai+"Model>.SetParameterValue(obj"+TabelaPai+"));{0}" +
                       "    }{0}" +
                       "    else{0}" +
                       "    {{0}" +
                       "        UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                       "        \"[dbo].[Proc_update_"+TabelaPai+"]\",{0}" +
                       "        ParameterBase<"+TabelaPai+"Model>.SetParameterValue(obj"+TabelaPai+"));{0}" +
                       "    }{0}" +
                       "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Delete("+TabelaPai+"Model obj"+TabelaPai+"){0}"+
                      "{{0}" +
                       "   UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                       "   UndTrabalho.dbTransaction,{0}" +
                       "  \"[dbo].[Proc_delete_" + TabelaPai + "]\",{0}" +
                       "   UserData.idUser,{0}" +
                       "   obj" + TabelaPai + "." + PkPai + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Copy(" + TabelaPai + "Model obj" + TabelaPai + "){0}" +
                       "{{0}" +
                       "    obj" + TabelaPai + "."+PkPai+" = (int)UndTrabalho.dbPrincipal.ExecuteScalar({0}" +
                       "    UndTrabalho.dbTransaction,{0}" +
                       "   \"dbo.Proc_copy_" + TabelaPai + "\",{0}" +
                       "    obj" + TabelaPai + "."+PkPai+");{0}" +
                       "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public " + TabelaPai + "Model Get" + TabelaPai + "(int " + PkPai + "){0}" +
                      "{{0}{0}" +

                      "    if (reg"+TabelaPai+"Accessor == null){0}" +
                      "    {{0}" +
                      "    reg"+TabelaPai+"Accessor = UndTrabalho.dbPrincipal.CreateSprocAccessor(\"dbo.Proc_sel_"+TabelaPai+"\",{0}" +
                      "                             new Parameters(UndTrabalho.dbPrincipal){0}" +
                      "                             .AddParameter<int>(\""+PkPai+"\"),{0}" +
                      "                             MapBuilder<"+TabelaPai+"Model>.MapAllProperties().Build());{0}" +
                      "    }{0}{0}" +

                      "    return reg"+TabelaPai+"Accessor.Execute("+PkPai+").FirstOrDefault();{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        //public string GetAll()
        //{
        //}

        public string Transactions()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void BeginTransaction(){0}" +
                      "{{0}" +
                      "    UndTrabalho.BeginTransaction();{0}" +
                      "}{0}" +
                      "public void CommitTransaction(){0}" +
                      "{{0}" +
                      "     UndTrabalho.CommitTransaction();{0}" +
                      "}{0}" +
                      "public void RollackTransaction(){0}" +
                      "{{0}" +
                      "     UndTrabalho.RollBackTransaction();{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

    }
}
