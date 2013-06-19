using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using Model;
using System.IO;

namespace BO
{
    public class constraintsBo: constraintsDao
    {
        public constraintsBo()
        {
        }

        public List<constraintsModel> GetConstraints(string sTable)
        {
            return base.GetConstraintsDao(sTable: sTable).AsEnumerable().Select(dr => new constraintsModel
                {
                    sColumnName = dr["COLUMN_NAME"].ToString(),
                    sConstrName = dr["CONSTRAINT_NAME"].ToString(),
                    sTabela = dr["TABLE_NAME"].ToString()
                }).ToList();
        }

        public string GetValorCopy(string sTable, string sCampo, string sValue)
        {
            return base.GetValorCopyDao(sTable: sTable, sCampo: sCampo, sValue: sValue).Select().FirstOrDefault().ToString();            
        }

        public string MontaScript(constraintsModel objConstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE i ");
            sb.Append(Environment.NewLine);
            sb.Append("where i.CONSTRAINT_NAME = '"+objConstr.sConstrName+"' and i.TABLE_NAME = '"+objConstr.sTabela+"')");
            sb.Append(Environment.NewLine);
            sb.Append("begin");
            sb.Append(Environment.NewLine);
            sb.Append("ALTER TABLE [dbo].["+objConstr.sTabela+"]");
            sb.Append(Environment.NewLine);
            sb.Append("DROP CONSTRAINT ["+objConstr.sConstrName+"]");
            sb.Append(Environment.NewLine);
            sb.Append("end");
            sb.Append(Environment.NewLine);
            sb.Append("ALTER TABLE [dbo].["+objConstr.sTabela+"] ADD  CONSTRAINT ["+objConstr.sConstrName+"]"+
                " UNIQUE NONCLUSTERED");
            sb.Append(Environment.NewLine);
            sb.Append("(");
            sb.Append(Environment.NewLine);
            sb.Append("["+objConstr.sColumnName+"] ASC");
            sb.Append(Environment.NewLine);
            sb.Append(");");
            return sb.ToString();
        }

        public bool ConstrExists(string sConstraints)
        {
            return base.ConstrExistsDao(sConstraints: sConstraints);
        }

        public List<constraintsModel> GetAllConstraints()
        {
            return base.GetAllConstraintsDao().AsEnumerable().Select(dr => new constraintsModel
            {
                sColumnName = dr["COLUMN_NAME"].ToString(),
                sConstrName = dr["CONSTRAINT_NAME"].ToString(),
                sTabela = dr["TABLE_NAME"].ToString()
            }).ToList();
        }

        public bool SalvaConstraint(string sConst, string sCaminho, string sNomeArq)
        {
            try
            {
                if (!Directory.Exists(sCaminho + "\\constraints"))
                {
                    Directory.CreateDirectory(sCaminho + "\\constraints");
                }

                File.Create(sCaminho + "\\constraints\\" + sNomeArq + ".sql").Close();

                StreamWriter _sw = new StreamWriter(sCaminho + "\\constraints\\" + sNomeArq + ".sql");

                _sw.Write(sConst);
                _sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public bool ArqConstrExiste(string sCaminho, string sNomeArq)
        {
            return File.Exists(sCaminho + "\\constraints\\" + sNomeArq + ".sql");
        }

        public void ExecutConstr(string sScript)
        {
            base.ExecutConstrDao(sScript: sScript);
        }
    }
}
