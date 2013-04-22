using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;

namespace BO.pesquisas
{
    public class pesquisaForms
    {
        ctxFormularios _objCtx;

        public pesquisaForms()
        {
            _objCtx = new ctxFormularios();
        }

        public List<vwFormularios> RetornaTodos()
        {            
            return _objCtx.vwFormularios.Where(f => f.xID != "").ToList();
        }

        public List<vwFormularios> fIdFormContains(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xID.Contains(_valor)).ToList();
        }

        public List<vwFormularios> fIdFormInicia(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xID.StartsWith(_valor)).ToList();
        }

        public List<vwFormularios> fIdFormIgual(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xID == _valor).ToList();
        }

        public List<vwFormularios> fFormContains(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xName.Contains(_valor)).ToList();
        }

        public List<vwFormularios> fFormInicia(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xName.StartsWith(_valor)).ToList();
        }

        public List<vwFormularios> fFormIgual(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xName == _valor).ToList();
        }

        public List<vwFormularios> fNamesContains(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xType.Contains(_valor)).ToList();
        }

        public List<vwFormularios> fNamesInicia(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xType.StartsWith(_valor)).ToList();
        }

        public List<vwFormularios> fNamesIgual(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xType == _valor).ToList();
        }

        public List<vwFormularios> fModuloContains(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xNome.Contains(_valor)).ToList();
        }

        public List<vwFormularios> fModuloInicia(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xNome.StartsWith(_valor)).ToList();
        }

        public List<vwFormularios> fModuloIgual(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xNome == _valor).ToList();
        }

        public List<vwFormularios> fScopeIgual(string _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.xScope == _valor).ToList();
        }

        public List<vwFormularios> fSingletonIgual(bool _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.stSingleton == _valor).ToList();
        }

        public List<vwFormularios> fAtivoIgual(bool _valor)
        {
            return _objCtx.vwFormularios.Where(f => f.stAtivo == _valor).ToList();
        }
    }
}
