using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Model;
using System.Data;

namespace BO
{
    public class TabelasBO : TabelasDAO
    {
        private List<TabelaModel> _colunas;
        public string ProcNome_Insert;
        public string ProcNome_Update;
        public string ProcNome_Delete;
        public string ProcNome_Select;
        public string ProcNome_Duplicar;
        public enum tipoProc { DELETE, SAVE, UPDATE, COPY, SEL };

        //string vservidor, string vuser, string vpassword,
        //string vdataBase, byte vtipoConexao

        public void setTabela(string sNomeTabela)
        {
            _colunas = GetDetalhes(sNomeTabela);
        }

        public string GerarInsert_Update_SP()
        {
            StringBuilder proc = new StringBuilder();

            if (_colunas == null)
            {
                throw new Exception("Erro ao selecionar a tabela");
            }
            //Cabeçalho fixo
            ProcNome_Insert = _colunas.First().TabelaOwner + ".Proc_save_" + _colunas.First().NomeTabela;

            proc.Append("CREATE PROCEDURE [");
            proc.Append(_colunas.First().TabelaOwner);
            proc.Append("].[Proc_save_");
            proc.Append(_colunas.First().NomeTabela + "]{0}");
            proc.Append("({0}");
            proc.Append("   @idUser int, {0}");

            string values = String.Empty;
            string columnNames = String.Empty;
            string update = String.Empty;
            string columKey = String.Empty;
            int qtd = 0;
            qtd = _colunas.Count;

            string svalorParameter = "";

            for (int i = 0; i < qtd; i++)
            {
                svalorParameter = "   @" + _colunas[i].NomeColuna + " " + (_colunas[i].TipoColuna == "int identity" ? "int" :
                                             _colunas[i].TipoColuna.ToUpper().Contains("CHAR") ?
                                                (_colunas[i].TipoColuna + "(" + _colunas[i].Tamanho + ")") :
                                                    _colunas[i].TipoColuna.ToUpper().Contains("DECIMAL") ?
                                                        _colunas[i].TipoColuna + "(" + _colunas[i].Precisao + "," + _colunas[i].CasasDecimais + ")" :
                                                        _colunas[i].TipoColuna);
                svalorParameter += _colunas[i].IsNullable == "1" ? " = null" : "";
                svalorParameter += (qtd - i == 1 ? "" : ",{0}");

                if (_colunas[i].TipoColuna != "int identity")
                {
                    values += "{0}   @" + _colunas[i].NomeColuna + (qtd - i == 1 ? "" : ",");
                    columnNames += "{0}   " + _colunas[i].NomeColuna + (qtd - i == 1 ? "" : ",");
                }

                proc.Append(svalorParameter);
            }

            proc.Append("{0}) {0}AS{0}");
            proc.Append("BEGIN{0}"); //iNICIO
            proc.Append("DECLARE @xOper CHAR(1){0}");

            proc.Append("SET @xOper = 'I' {0}");
            proc.Append("INSERT INTO " + _colunas.First().NomeTabela + "{0}(");
            proc.Append(columnNames);
            proc.Append("{0}){0}");
            proc.Append("VALUES{0}(");
            proc.Append(values);
            proc.Append("{0}){0}");
            proc.Append("DECLARE @codigo INT {0}");
            proc.Append("SET @codigo = @@IDENTITY{0}");
            proc.Append("END{0}{0}");

            #region LOG

            proc.Append("DECLARE @stLog INT {0}");
            proc.Append("SELECT @stLog = stLog FROM Configuracao_Log_Tabela {0}");
            proc.Append("where xTabela = '" + _colunas.First().NomeTabela + "'{0}");
            proc.Append("");
            proc.Append("");
            proc.Append("");
            proc.Append("IF @stLog = 1 {0}");
            proc.Append("BEGIN {0}");
            proc.Append("IF ( @@ERROR = 0 ){0}");
            proc.Append("BEGIN{0}");
            proc.Append("EXECUTE [dbo].[Proc_insert_log]{0}");
            proc.Append("   @xTabela = '" + _colunas.First().NomeTabela + "',{0}");
            proc.Append("   @idUsuario = @idUser,{0}");
            proc.Append("   @xOperacao = @xOper,{0}");
            proc.Append("   @idChave1 = @codigo{0}");
            proc.Append("END{0}");
            proc.Append("END{0}");

            #endregion

            proc.Append("SELECT @codigo {0}");//Finaliza proc

            return string.Format(proc.ToString(), Environment.NewLine);
        }

        //Novo
        public string GerarUpdate_SP()
        {
            StringBuilder proc = new StringBuilder();

            if (_colunas == null)
            {
                throw new Exception("Erro ao selecionar a tabela");
            }
            //Cabeçalho fixo
            ProcNome_Update = _colunas.First().TabelaOwner + ".Proc_update_" + _colunas.First().NomeTabela;

            proc.Append("CREATE PROCEDURE [");
            proc.Append(_colunas.First().TabelaOwner);
            proc.Append("].[Proc_update_");
            proc.Append(_colunas.First().NomeTabela + "]{0}");
            proc.Append("({0}");
            proc.Append("   @idUser int, {0}");

            string values = String.Empty;
            string columnNames = String.Empty;
            string update = String.Empty;
            string columKey = String.Empty;
            int qtd = 0;
            qtd = _colunas.Count;


            for (int i = 0; i < qtd; i++)
            {

                string svalorParameter = "   @" + _colunas[i].NomeColuna + " " + (_colunas[i].TipoColuna == "int identity" ? "int" :
                                                 _colunas[i].TipoColuna.ToUpper().Contains("CHAR") ?
                                                    (_colunas[i].TipoColuna + "(" + _colunas[i].Tamanho + ")") :
                                                        _colunas[i].TipoColuna.ToUpper().Contains("DECIMAL") ?
                                                            _colunas[i].TipoColuna + "(" + _colunas[i].Precisao + "," + _colunas[i].CasasDecimais + ")" :
                                                            _colunas[i].TipoColuna);
                svalorParameter += _colunas[i].IsNullable == "1" ? " = null" : "";
                svalorParameter += (qtd - i == 1 ? "" : ",{0}");


                if (!_colunas[i].TipoColuna.Contains("int identity"))
                {
                    update += "{0}   [" + _colunas[i].NomeColuna + "]= @" + _colunas[i].NomeColuna + (qtd - i == 1 ? "" : ",");
                }
                else
                {
                    columKey = _colunas[i].NomeColuna;
                }

                proc.Append(svalorParameter);
            }

            proc.Append("{0}) {0}AS{0}");
            proc.Append("BEGIN{0}"); //iNICIO
            proc.Append("DECLARE @xOper CHAR(1){0}");
            proc.Append("SET @xOper = 'U' {0}");

            proc.Append("UPDATE " + _colunas.First().NomeTabela + " SET ");
            proc.Append(update);
            proc.Append("{0}WHERE " + columKey + " = @" + columKey);

            #region LOG

            proc.Append("{0}{0}DECLARE @stLog INT {0}");
            proc.Append("SELECT @stLog = stLog FROM Configuracao_Log_Tabela {0}");
            proc.Append("where xTabela = '" + _colunas.First().NomeTabela + "'{0}");
            proc.Append("");
            proc.Append("");
            proc.Append("");
            proc.Append("IF @stLog = 1 {0}");
            proc.Append("BEGIN {0}");
            proc.Append("IF ( @@ERROR = 0 ){0}");
            proc.Append("BEGIN{0}");
            proc.Append("EXECUTE [dbo].[Proc_insert_log]{0}");
            proc.Append("   @xTabela = '" + _colunas.First().NomeTabela + "',{0}");
            proc.Append("   @idUsuario = @idUser,{0}");
            proc.Append("   @xOperacao = @xOper,{0}");
            proc.Append("   @idChave1 = @" + columKey + "{0}");
            proc.Append("END{0}");
            proc.Append("END{0}");

            #endregion

            proc.Append("SELECT @" + columKey + "{0}");
            proc.Append("{0}END{0}"); //Finaliza proc

            return string.Format(proc.ToString(), Environment.NewLine);
        }

        public string GerarDelete_SP()
        {
            StringBuilder sp = new StringBuilder();

            if (_colunas != null)
            {
                string primarykey = "@" + _colunas.Where(c => c.TipoColuna == "int identity").FirstOrDefault().NomeColuna;
                string where = String.Empty;

                ProcNome_Delete = _colunas.First().TabelaOwner + ".Proc_delete_" + _colunas.First().NomeTabela;

                sp.Append("CREATE PROCEDURE [");
                sp.Append(_colunas.First().TabelaOwner);
                sp.Append("].[Proc_delete_");
                sp.Append(_colunas.First().NomeTabela + "]{0}");
                sp.Append("({0}");
                sp.Append("   @idUser int,{0}");

                int qtd = CarregaPK(_colunas.First().NomeTabela).Count; //Método CarregaPK fica na DAO e retorna uma lista de string com as colunas primarias

                for (int i = 0; i < qtd; i++)
                {
                    string chaveP = CarregaPK(_colunas.First().NomeTabela)[i];
                    where += chaveP + " = @" + chaveP + ((qtd - i == 1) ? "" : " AND{0}");
                    sp.Append("   @" + chaveP + " " + (_colunas[i].TipoColuna == "int identity" ? "int" : _colunas[i].TipoColuna) + ((qtd - i == 1) ? "" : ",{0}"));
                }

                sp.Append("{0}) {0}AS {0}BEGIN {0}");
                sp.Append("DELETE " + _colunas.First().NomeTabela + " WHERE ");
                sp.Append(where);

                #region LOG
                sp.Append("{0}{0}DECLARE @stLog INT {0}");
                sp.Append("SELECT @stLog = stLog FROM Configuracao_Log_Tabela {0}");
                sp.Append("WHERE xTabela = '" + _colunas.First().NomeTabela + "'{0}");
                sp.Append("");
                sp.Append("");
                sp.Append("");
                sp.Append("IF @stLog = 1 {0}");
                sp.Append("BEGIN {0}");
                sp.Append("IF ( @@ERROR = 0 ){0}");
                sp.Append("BEGIN{0}");
                sp.Append("EXECUTE [dbo].[Proc_insert_log]{0}");
                sp.Append("   @xTabela = '" + _colunas.First().NomeTabela + "',{0}");
                sp.Append("   @idUsuario = @idUser,{0}");
                sp.Append("   @xOperacao = 'D',{0}");
                sp.Append("   @idChave1 = " + primarykey + "{0}");
                sp.Append("END{0}");
                sp.Append("END{0}");

                #endregion
                sp.Append("END");
            }
            return string.Format(sp.ToString(), Environment.NewLine);
        }

        public string GerarSelect_SP()
        {
            StringBuilder sp = new StringBuilder();

            if (_colunas != null)
            {
                string campos = String.Empty;
                string where = String.Empty;

                ProcNome_Select = _colunas.First().TabelaOwner + ".Proc_sel_" + _colunas.First().NomeTabela;

                sp.Append("CREATE PROCEDURE [");
                sp.Append(_colunas.First().TabelaOwner);
                sp.Append("].[Proc_sel_");
                sp.Append(_colunas.First().NomeTabela + "]{0}");
                sp.Append("({0}");

                int qtd = CarregaPK(_colunas.First().NomeTabela).Count; //Método CarregaPK fica na DAO e retorna uma lista de string com as colunas primarias

                for (int i = 0; i < qtd; i++)
                {
                    string chaveP = CarregaPK(_colunas.First().NomeTabela)[i];
                    string tipoc = _colunas.Where(c => c.NomeColuna == chaveP).FirstOrDefault().TipoColuna;
                    sp.Append("   @" + chaveP + " " + (tipoc == "int identity" ? "int" : tipoc) + ((qtd - i == 1) ? "" : ",{0}"));
                    where += _colunas.FirstOrDefault().NomeTabela + "." + chaveP + " = @" + chaveP + ((qtd - i == 1) ? "" : "{0}and ");
                }

                for (int i = 0; i < _colunas.Count; i++)
                {
                    campos += "{0}   " + _colunas[i].NomeTabela + "." + _colunas[i].NomeColuna + (_colunas.Count - i == 1 ? "" : ",");
                }

                sp.Append("{0}) {0}AS {0}BEGIN {0}");
                sp.Append("SELECT ");
                sp.Append(campos);
                sp.Append("{0} FROM " + _colunas.FirstOrDefault().NomeTabela + "{0}");
                sp.Append("WHERE ");
                sp.Append(where);
                sp.Append(";{0}END");


            }

            return string.Format(sp.ToString(), Environment.NewLine);
        }

        public string GerarDuplicar_SP()
        {
            StringBuilder sp = new StringBuilder();

            if (_colunas != null)
            {
                constraintsBo objConstBo = new constraintsBo();
                List<constraintsModel> lConstraints = objConstBo.GetConstraints(_colunas.First().NomeTabela);
                string campos = String.Empty;
                string sValues = String.Empty;
                string where = String.Empty;

                ProcNome_Duplicar = _colunas.First().TabelaOwner + ".Proc_copy_" + _colunas.First().NomeTabela;

                sp.Append("CREATE PROCEDURE [");
                sp.Append(_colunas.First().TabelaOwner);
                sp.Append("].[Proc_copy_");
                sp.Append(_colunas.First().NomeTabela + "]{0}");
                sp.Append("({0}");

                int qtd = CarregaPK(_colunas.First().NomeTabela).Count; //Método CarregaPK fica na DAO e retorna uma lista de string com as colunas primarias

                for (int i = 0; i < qtd; i++)
                {
                    string chaveP = CarregaPK(_colunas.First().NomeTabela)[i];
                    string tipoc = _colunas.Where(c => c.NomeColuna == chaveP).FirstOrDefault().TipoColuna;
                    sp.Append("   @" + chaveP + " " + (tipoc == "int identity" ? "int" : tipoc) + ((qtd - i == 1) ? "" : ",{0}"));
                    where += _colunas.FirstOrDefault().NomeTabela + "." + chaveP + " = @" + chaveP + ((qtd - i == 1) ? "" : "{0}and ");
                }

                for (int i = 0; i < _colunas.Count; i++)
                {
                    if (_colunas[i].TipoColuna != "int identity")
                    {
                        campos += "{0}   " + _colunas[i].NomeTabela + "." + _colunas[i].NomeColuna +
                            (_colunas.Count - i == 1 ? "" : ",");
                    }
                }

                for (int i = 0; i < _colunas.Count; i++)
                {
                    if (_colunas[i].TipoColuna != "int identity")
                    {
                        sValues += "{0}   "
                            + ((lConstraints.Where(c => c.sColumnName == _colunas[i].NomeColuna).Count() > 0) ?
                            "case when (select c.CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS c where c.COLUMN_NAME = '" + _colunas[i].NomeColuna + "'" +
                            " and c.TABLE_NAME = '" + _colunas[i].NomeTabela + "') < 7 " +
                            "then " +
                            "case when ((select c.IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS c where c.COLUMN_NAME = '" + _colunas[i].NomeColuna + "' " +
                            "and c.TABLE_NAME = '" + _colunas[i].NomeTabela + "') = 'NO') " +
                            "then " +
                            "Reverse(SUBSTRING(Reverse(IDENT_CURRENT('" + _colunas[i].NomeTabela + "')), 1, " +
                            "(select c.CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS c where c.COLUMN_NAME = '" + _colunas[i].NomeColuna + "' " +
                            "and c.TABLE_NAME = '" + _colunas[i].NomeTabela + "'))) " +
                            "else " +
                            "null " +
                            "end " +
                            "else " +
                            "case when (select count(j1." + _colunas[i].NomeColuna + ") from " + _colunas[i].NomeTabela + " j1 where j1." + _colunas[i].NomeColuna + " like 'copy_%') = 0 " +
                            "then " +
                            "'copy_1' " +
                            "else " +
                            "'copy_'+(Cast(Cast(Substring((select top(1) j2." + _colunas[i].NomeColuna + " from " + _colunas[i].NomeTabela + " j2" +
                            " where j2." + _colunas[i].NomeColuna + " like 'copy_%' order by j2." + _colunas[i].NomeColuna + " desc), " +
                            "PATINDEX('%copy_%', (select top(1) j3." + _colunas[i].NomeColuna + " from " + _colunas[i].NomeTabela + " j3 " +
                            "where j3." + _colunas[i].NomeColuna + " like 'copy_%' order by j3." + _colunas[i].NomeColuna + "))+5, " +
                            "(select c.CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS c where c.COLUMN_NAME = '" + _colunas[i].NomeColuna + "' " +
                            "and c.TABLE_NAME = '" + _colunas[i].NomeTabela + "'))as int) + 1 as varchar(max))) " +
                            "end " +
                            "end" :
                                _colunas[i].NomeTabela + "." + _colunas[i].NomeColuna) +
                            (_colunas.Count - i == 1 ? "" : ",");
                    }
                }

                sp.Append("{0}) {0}AS {0}BEGIN {0}");
                sp.Append("INSERT INTO " + _colunas.FirstOrDefault().NomeTabela);
                sp.Append("{0}(");
                sp.Append(campos);
                sp.Append("{0}){0}SELECT");
                sp.Append(sValues);

                sp.Append("{0}FROM " + _colunas.FirstOrDefault().NomeTabela + "{0}");
                sp.Append("WHERE ");
                sp.Append(where);
                sp.Append(";{0}{0}DECLARE @ret int;{0}");
                sp.Append("SET @ret =  @@IDENTITY{0}");
                sp.Append("SELECT @ret");
                sp.Append("{0}END");
            }
            return string.Format(sp.ToString(), Environment.NewLine);
        }



        public string GerarPropriedadesWithOrder(string sNomeTabela, bool tbFilho)
        {
            StringBuilder prop = new StringBuilder();

            List<TabelaModel> _tab = GetDetalhes(sNomeTabela);

            for (int i = 0; i < _tab.Count; i++)
            {
                string tipo = ConverterTipo(_tab[i].TipoColuna);
                string aux = "";

                if (tbFilho && _tab[i].TipoColuna == "int identity")
                {
                    aux = "private ";
                    aux += tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + "_" + _tab[i].NomeColuna + ";" + Environment.NewLine;
                    aux += "[ParameterOrder(Order = " + (i + 1) + ")]" + Environment.NewLine;
                    aux += "public ";
                    aux += tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + _tab[i].NomeColuna + Environment.NewLine;
                    aux += "{" + Environment.NewLine;
                    aux += "get{ return _" + _tab[i].NomeColuna + "; }" + Environment.NewLine;
                    aux += "set" + Environment.NewLine;
                    aux += "{" + Environment.NewLine;
                    aux += "_" + _tab[i].NomeColuna + " = value;" + Environment.NewLine;
                    aux += "base.SetID(value);" + Environment.NewLine;
                    aux += "}" + Environment.NewLine;
                    aux += "}" + Environment.NewLine;
                }
                else
                {
                    prop.Append("[ParameterOrder(Order = " + (i + 1) + ")]" + Environment.NewLine);
                    prop.Append("public ");
                    aux = tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + _tab[i].NomeColuna;
                    aux += "{ get; set; }" + Environment.NewLine;
                }

                prop.Append(aux);

            }

            return prop.ToString();
        }

        public string GerarPropriedadesWithINotifyPropertyChanged(string sNomeTabela, bool tbFilho, bool bParameterOrder)
        {
            StringBuilder prop = new StringBuilder();

            List<TabelaModel> _tab = GetDetalhes(sNomeTabela);

            for (int i = 0; i < _tab.Count; i++)
            {
                string tipo = ConverterTipo(_tab[i].TipoColuna);
                string aux = "";

                aux = "private ";
                aux += tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + "_" + _tab[i].NomeColuna + ";" + Environment.NewLine;
                if (bParameterOrder)
                {
                    if (_tab[i].TipoColuna == "int identity")
                        aux += "[ParameterOrder(Order = " + (i + 1) + "), PrimaryKey(isPrimary = true)]" + Environment.NewLine;
                    else
                        aux += "[ParameterOrder(Order = " + (i + 1) + ")]" + Environment.NewLine;
                }
                aux += "public ";
                aux += tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + _tab[i].NomeColuna + Environment.NewLine;
                aux += "{" + Environment.NewLine;
                aux += "get{ return _" + _tab[i].NomeColuna + "; }" + Environment.NewLine;
                aux += "set" + Environment.NewLine;
                aux += "{" + Environment.NewLine;
                aux += "_" + _tab[i].NomeColuna + " = value;" + Environment.NewLine;
                aux += "base.NotifyPropertyChanged(propertyName: \"" + _tab[i].NomeColuna + "\");" + Environment.NewLine;
                aux += "}" + Environment.NewLine;
                aux += "}" + Environment.NewLine;

                prop.Append(aux);

            }

            return prop.ToString();
        }

        public string GerarPropriedades(string sNomeTabela, bool tbFilho)
        {
            StringBuilder prop = new StringBuilder();

            List<TabelaModel> _tab = GetDetalhes(sNomeTabela);

            for (int i = 0; i < _tab.Count; i++)
            {
                string tipo = ConverterTipo(_tab[i].TipoColuna);
                string aux = "";

                if (tbFilho && _tab[i].TipoColuna == "int identity")
                {
                    aux = tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + "_" + _tab[i].NomeColuna + ";" + Environment.NewLine;
                    aux += tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + _tab[i].NomeColuna + Environment.NewLine;
                    aux += "{" + Environment.NewLine;
                    aux += "get{ return _" + _tab[i].NomeColuna + "; }" + Environment.NewLine;
                    aux += "set" + Environment.NewLine;
                    aux += "{" + Environment.NewLine;
                    aux += "_" + _tab[i].NomeColuna + " = value;" + Environment.NewLine;
                    aux += "base.SetID(value);" + Environment.NewLine;
                    aux += "}" + Environment.NewLine;
                    aux += "}" + Environment.NewLine;
                }
                else
                {
                    prop.Append("public ");
                    aux = tipo + (tipo == "string" ? " " : (_tab[i].TipoColuna == "int identity" ? "? " : (_tab[i].IsNullable == "1" ? "? " : " "))) + _tab[i].NomeColuna;
                    aux += "{ get; set; }" + Environment.NewLine;
                }

                prop.Append(aux);

            }

            return prop.ToString();
        }

        private string ConverterTipo(string _tipo)
        {
            _tipo.ToLower();
            switch (_tipo)
            {
                case "int identity": _tipo = "int";
                    break;
                case "varchar": _tipo = "string";
                    break;
                case "char": _tipo = "string";
                    break;
                case "numeric": _tipo = "decimal";
                    break;
                case "tinyint": _tipo = "byte";
                    break;
                case "bit": _tipo = "bool";
                    break;
                case "time": _tipo = "TimeSpan";
                    break;
                case "date": _tipo = "DateTime";
                    break;
                case "datetime": _tipo = "DateTime";
                    break;
                case "nchar": _tipo = "string";
                    break;
                default:
                    break;
            }
            return _tipo;
        }


        public string GetNameProc(tipoProc tpProc)
        {
            switch (tpProc)
            {
                case tipoProc.DELETE:
                    return "Proc_delete_" + _colunas.First().NomeTabela;
                case tipoProc.SAVE:
                    return "Proc_save_" + _colunas.First().NomeTabela;
                case tipoProc.UPDATE:
                    return "Proc_update_" + _colunas.First().NomeTabela;
                case tipoProc.COPY:
                    return "Proc_copy_" + _colunas.First().NomeTabela;
                case tipoProc.SEL:
                    return "Proc_sel_" + _colunas.First().NomeTabela;
                default:
                    return "";
            }
        }

        public List<TabelaModel> GetColunasByTabela(string vTabela)
        {
            return base.GetColunasByTabelaDao(vNomeTabela: vTabela).
                AsEnumerable().Select(c => new TabelaModel
                {
                    NomeColuna = c["COLUMN_NAME"].ToString()
                }).ToList();
        }
    }
}
