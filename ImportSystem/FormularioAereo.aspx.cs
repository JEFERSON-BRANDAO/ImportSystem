using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using Microsoft.Reporting.WebForms;
using System.Collections;
// ===============================
// AUTHOR       : JEFFERSON BRANDÃO DA COSTA - ANALISTA/PROGRAMADOR
// CREATE DATE  : 24/09/19
// DESCRIPTION  : Sistema controle de Importação
// SPECIAL NOTES:
// ===============================
// Change History: version 1.0.1
//Formulário Aereo [IMPORT PROCESS]
// Date: 11/06/21
//==================================

namespace ImportSystem
{
    public partial class FormularioAereo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAviso.Visible = false;
            //Esconde botao de exportação
            //RelatorioAereo.ShowExportControls = false;

            if (!IsPostBack)
            {
                int IdAir_shipiment = 0;
                Int32.TryParse((string)Page.RouteData.Values["id"], out IdAir_shipiment);
                Pwce(IdAir_shipiment);
            }
        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                if (RequiredFieldValidatorPwce.IsValid)
                {
                    lblAviso.Visible = false;
                    //
                    RelatorioAereo.LocalReport.DataSources.Clear();
                    RelatorioAereo.LocalReport.DataSources.Add(new ReportDataSource("Formulario", ObjectDataSourceAereo));
                    RelatorioAereo.LocalReport.ReportPath = @"Aereo.rdlc";

                }
                

            }
            catch (Exception erro)
            {
                lblAviso.Visible = true;
                lblAviso.Text = erro.Message;
                //
                RelatorioAereo.LocalReport.DataSources.Clear();
                RelatorioAereo.LocalReport.ReportPath = @"vazio.rdlc";
            }

        }

        protected void RelatorioAereo_Load(object sender, EventArgs e)
        {
            var fieldInfo = typeof(Microsoft.Reporting.WebForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //
            foreach (var extension in this.RelatorioAereo.LocalReport.ListRenderingExtensions())
            {
                //if (string.Compare("EXCELOPENXML", extension.Name) == 0)
                //    fieldInfo.SetValue(extension, false);

                //Desabilitar exibir estes formatos para exportação
                if (string.Compare("Excel", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
                //
                if (string.Compare("PDF", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
            }
        }

        public void Pwce(int Id)
        {
            #region RETORNA PWCE

            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    string Sql = string.Format(@"SELECT PWCE FROM IMPORTACAO.AIR_SHIPMENT WHERE IDAIR_SHIPMENT={0}", Id);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        txtPwce.Text = string.IsNullOrEmpty(Objconn.Tabela.Rows[0]["PWCE"].ToString()) ? string.Empty : Objconn.Tabela.Rows[0]["PWCE"].ToString();
                    }

                }
                catch (Exception erro)
                {
                    lblAviso.Visible = true;
                    lblAviso.Text = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Page.RouteData.Values["id"]))
            {
                int IdAir_shipiment = 0;
                Int32.TryParse((string)Page.RouteData.Values["id"], out IdAir_shipiment);
                Response.RedirectToRoute("Novo_Aereo", new { id = IdAir_shipiment });
            }
        }
    }
}