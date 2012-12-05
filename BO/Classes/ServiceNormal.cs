using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class ServiceNormal
    {
        private string NmTabela { get; set; }
        private string NmPk { get; set; }

        public ServiceNormal(string nmTabela, string pk)
        {
            this.NmTabela = nmTabela;
            this.NmPk = pk;
        }

        public string Inject()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Inject]{0}"+
                      "public I"+NmTabela+"Repository _"+NmTabela+"Repository { get; set; }{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Save(" + NmTabela + "Model obj" + NmTabela + "){0}" +
                      "{{0}" +
                      "    _" + NmTabela + "Repository.Save(obj" + NmTabela + ");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public void Delete(int "+NmPk+"){0}"+
                      "{{0}" +
                      "    _" + NmTabela + "Repository.Delete(" + NmPk + ");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public int Copy(int "+NmPk+"){0}"+
                      "{{0}" +
                      "    return _"+NmTabela+"Repository.Copy(" + NmPk + ");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public " + NmTabela + "Model Get" + NmTabela + "(int "+NmPk+"){0}" +
                      "{{0}" +
                      "    return _" + NmTabela + "Repository.Get" + NmTabela + "(" + NmPk + ");{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public List<" + NmTabela + "Model> GetAll" + NmTabela + "(){0}" +
                      "{{0}" +
                      "    return _" + NmTabela + "Repository.GetAll();{0}" +
                      "}{0}{0}");


            return sb.ToString().Replace("{0}", "\r\n");
        }
    }
}
