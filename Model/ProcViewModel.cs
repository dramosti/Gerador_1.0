using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProcViewModel
    {
        private string _nomeProc;

        public string NomeProc
        {
            get { return _nomeProc; }
            set { _nomeProc = value; }
        }
    }
}
