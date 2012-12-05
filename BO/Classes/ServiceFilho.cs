using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.Classes
{
    public class ServiceFilho
    {
        private string TabelasFilho { get; set; }
        private string PkPai { get; set; }
        private string PkFilho { get; set; }

        public ServiceFilho(string PkPai, string PkFilho, string TabelasFilho)
        {
            this.TabelasFilho = TabelasFilho;
            this.PkPai = PkPai;
            this.PkFilho = PkFilho;
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[Inject]{0}"+
                      "public I" + TabelasFilho + "Repository _"+TabelasFilho+"Repository { get; set; }{0}{0}" +

                      "public void Save(" + TabelasFilho + "Model obj" + TabelasFilho + "){0}" +
                      "{{0}"+
                      "     _" + TabelasFilho + "Repository.Save(obj" + TabelasFilho + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");
        }

        public string Update()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Update(" + TabelasFilho + "Model obj" + TabelasFilho + "){0}" +
                      "{{0}" +
                      "     _" + TabelasFilho + "Repository.Update(obj" + TabelasFilho + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");


        }

        public string Delete()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Delete(" + TabelasFilho + "Model obj" + TabelasFilho + "){0}" +
                      "{{0}" +
                      "     _" + TabelasFilho + "Repository.Delete(obj" + TabelasFilho + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");

        }

        public string Delete2()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Delete(int "+PkPai+"){0}" +
                      "{{0}" +
                      "     _" + TabelasFilho + "Repository.Delete(" + PkPai + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");

        }

        public string Copy()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public void Copy(" + TabelasFilho + "Model obj" + TabelasFilho + "){0}" +
                      "{{0}" +
                      "     _" + TabelasFilho + "Repository.Copy(obj" + TabelasFilho + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");

        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public "+TabelasFilho+"Model Get"+TabelasFilho+"(int "+PkFilho+"){0}" +
                      "{{0}" +
                      "     return _" + TabelasFilho + "Repository.Get" + TabelasFilho + "(" + PkFilho + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");

        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public List<" + TabelasFilho + "Model> GetAll" + TabelasFilho + "(int " + PkPai + "){0}" +
                      "{{0}" +
                      "     return _" + TabelasFilho + "Repository.GetAll" + TabelasFilho + "(" + PkPai + ");{0}" +
                      "}{0}{0}");

            return sb.ToString().Replace("{0}", "\r\n");


        }

    }
}
