using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using UIWindows.Relatórios;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UIWindows
{
    public partial class UIRelMod : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public UIRelMod(string vParametro)
        {
            InitializeComponent();
            relModForms _objRel = new relModForms();
            _objRel.DataDefinition.RecordSelectionFormula = vParametro;
            rvModulos.ReportSource = _objRel;
            ConnectionInfo myConnectionInfo = new ConnectionInfo();
            myConnectionInfo.ServerName = "HLPSRV";
            myConnectionInfo.DatabaseName = "PROD_MODULOS";
            myConnectionInfo.UserID = "sa";
            myConnectionInfo.Password = "H029060tSql";
            SetDBLogonForReport(myConnectionInfo, _objRel);
            rvModulos.RefreshReport();
        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument ArquivoReport)
        {
            Tables tables = ArquivoReport.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }
    }
}