using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;

namespace BO
{
    public class modulosBO
    {
        ctxModulos _ctxModulos = null;

        public modulosBO()
        {
            _ctxModulos = new ctxModulos();
        }

        public int Salvar(mModulos _objModulos)
        {
            if(_objModulos.idModulo == 0)
            {
                _ctxModulos.AddToentityModulos(_objModulos);
            }
            _ctxModulos.SaveChanges();

            return _objModulos.idModulo;
        }

        public mModulos GetModulo(int _codMod)
        {
            _ctxModulos = new ctxModulos();
            return _ctxModulos.entityModulos.Where(m => m.idModulo == _codMod).FirstOrDefault();
        }

        public int GetCount(string vValor)
        {
            List<mModulos> _objMods = new List<mModulos>();
            _objMods = _ctxModulos.entityModulos.Where(m => m.xNome == vValor).ToList();
            return _objMods.Count;
        }
    }
}
