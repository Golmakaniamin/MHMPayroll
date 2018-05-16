using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Resources;

namespace Pey4_CrystalReports
{
    public partial class AllPrint : Form
    {
        SqlConnection objConnection = new SqlConnection();
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string selkar = "";
        public string sarbarg;
        public string recore_sel;

        public AllPrint()
        {
            InitializeComponent();
        }

        private void AllPrint_Load(object sender, EventArgs e)
        {
            if (selkar == "Report_Groupby_List")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@noe";
                paramDiscreteValue1.Value = sarbarg;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Groupby_List1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Groupby_List1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Groupby_List1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Groupby_List1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Report_Fish_2_Hoghogh")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@hogog";
                paramField1.ReportName = "Amin_mazaya";
                paramDiscreteValue1.Value = "م%";
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@hogog";
                paramField2.ReportName = "Amin_Kosorat";
                paramDiscreteValue2.Value = "%ات";
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@noe";
                paramDiscreteValue3.Value = sarbarg;
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Fish_2_Hoghogh1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Fish_2_Hoghogh1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Fish_2_Hoghogh1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Fish_2_Hoghogh1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Report_Garardad")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@hogog";
                paramField1.ReportName = "Amin_mazaya";
                paramDiscreteValue1.Value = "%";
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@type1";
                paramField2.ReportName = "Amin_mazaya";
                paramDiscreteValue2.Value = "2";
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Garardad1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Garardad1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Garardad1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Garardad1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Report_Groupby_Moon")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@noe";
                paramDiscreteValue3.Value = sarbarg;
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Groupby_Moon1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Groupby_Moon1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Groupby_Moon1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Groupby_Moon1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Report_Karkard")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@noe";
                paramDiscreteValue3.Value = sarbarg;
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Karkard1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Karkard1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Karkard1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Karkard1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Report_Groupby_Moon_Chart")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@noe";
                paramDiscreteValue3.Value = sarbarg;
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= report_Groupby_Moon_Chart1.Database.Tables.Count - 1; intCounter++)
                {
                    report_Groupby_Moon_Chart1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                report_Groupby_Moon_Chart1.RecordSelectionFormula = recore_sel;

                crystalReportViewer1.ReportSource = report_Groupby_Moon_Chart1;
                crystalReportViewer1.ParameterFieldInfo = paramFields;
            }
        }
    }
}
