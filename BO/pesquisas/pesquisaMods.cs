using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;

namespace BO.pesquisas
{
    public class pesquisaMods
    {
        private ctxModulos _ctxModulos;

        public pesquisaMods()
        {
            _ctxModulos = new ctxModulos();
        }

        public List<mModulos> GetTodos()
        {
            return _ctxModulos.entityModulos.Where(m => m.idModulo > 0).ToList();
        }

        public List<mModulos> GetIdMaior(int vId)
        {
            return _ctxModulos.entityModulos.Where(m => m.idModulo > vId).ToList();
        }

        public List<mModulos> GetIdMenor(int vId)
        {
            return _ctxModulos.entityModulos.Where(m => m.idModulo < vId).ToList();
        }

        public List<mModulos> GetIdIgual(int vId)
        {
            return _ctxModulos.entityModulos.Where(m => m.idModulo == vId).ToList();
        }

        public List<mModulos> GetModContem(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNome.Contains(vValor)).ToList();
        }

        public List<mModulos> GetModInicia(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNome.StartsWith(vValor)).ToList();
        }

        public List<mModulos> GetModIgual(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNome == vValor).ToList();
        }

        public List<mModulos> GetNsContem(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNameSpaceCamada.Contains(vValor)).ToList();
        }

        public List<mModulos> GetNsInicia(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNameSpaceCamada.StartsWith(vValor)).ToList();
        }

        public List<mModulos> GetNsIgual(string vValor)
        {
            return _ctxModulos.entityModulos.Where(m => m.xNameSpaceCamada == vValor).ToList();
        }
    }
}
