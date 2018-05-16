using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Pey4_CrystalReports
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();

            ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
            ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
            ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
            ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
            for (int intCounter = 0; intCounter <= report_BimehReport1.Database.Tables.Count - 1; intCounter++)
            {
                report_BimehReport1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
            }

            crystalReportViewer1.ReportSource = report_BimehReport1;
        }

        //private void ConfigureCrystalReports()
        //{
        //    crystalReportViewer.ReportSource = maliat_report;
        //    ConnectionInfo connectionInfo = new ConnectionInfo();
        //    SetDBLogonForReport(connectionInfo);
        //}

        //private void SetDBLogonForReport(ConnectionInfo connectionInfo)
        //{
        //    TableLogOnInfos tableLogOnInfos = crystalReportViewer.LogOnInfo;
        //    foreach (TableLogOnInfo tableLogOnInfo in tableLogOnInfos)
        //    {
        //        tableLogOnInfo.ConnectionInfo = connectionInfo;
        //    }
        //}
    }
}
