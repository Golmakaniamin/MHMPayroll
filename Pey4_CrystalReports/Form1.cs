using System;
using System.Collections.Generic;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pey4_CrystalReports
{
    public partial class Form1 : Form
    {
        public string sarbarg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();

            ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
            ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
            ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
            ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
            for (int intCounter = 0; intCounter <= report_Fish_Hoghogh1.Database.Tables.Count - 1; intCounter++)
            {
                report_Fish_Hoghogh1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
            }

            ParameterFields paramFields = new ParameterFields();
            paramFields.Clear();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
            paramField1.Name = "@noe";
            paramDiscreteValue1.Value = sarbarg;
            paramField1.CurrentValues.Add(paramDiscreteValue1);
            paramFields.Add(paramField1);

            crystalReportViewer1.ReportSource = report_Fish_Hoghogh1;
            crystalReportViewer1.ParameterFieldInfo = paramFields;
        }
    }
}
