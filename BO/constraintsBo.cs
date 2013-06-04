using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using Model;

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
                    sColumnName = dr["COLUMN_NAME"].ToString()
                }).ToList();
        }

        public string GetValorCopy(string sTable, string sCampo, string sValue)
        {
            string teste = base.GetValorCopyDao(sTable: sTable, sCampo: sCampo, sValue: sValue).Select().FirstOrDefault().ToString();
            return teste;
        }
    }
}
