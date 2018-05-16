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
    public partial class Form6 : Form
    {
        public ParameterFields paramFields = new ParameterFields(); 

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();

            ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
            ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
            ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
            ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
            for (int intCounter = 0; intCounter <= report_SANAD21.Database.Tables.Count - 1; intCounter++)
            {
                report_SANAD21.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
            }

            crystalReportViewer1.ReportSource = report_SANAD21;
            crystalReportViewer1.ParameterFieldInfo = paramFields;
        }
    }
}
