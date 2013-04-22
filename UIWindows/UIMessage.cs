using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cMessageBoxCustomizado;

namespace UIWindows
{
    public partial class UIMessage : cMessageBoxCustomizado.formMessageBox
    {
        public UIMessage(string vMessage, string vMessageMenu, 
            Botoes vBotoes, Icones vIcone):base(vMessage: vMessage,
            vMessageMenu: vMessageMenu, vBotoes: vBotoes, vIcone: vIcone)
        {
            InitializeComponent();
        }
    }
}
