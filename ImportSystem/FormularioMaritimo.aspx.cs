using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Classes;

namespace ImportSystem
{
    public partial class FormularioMaritimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAviso.Visible = false;
            //Esconde botao de exportação
            //RelatorioAereo.ShowExportControls = false;

            if (!IsPostBack)
            {
                int IdSea_shipiment = 0;
                Int32.TryParse((string)Page.RouteData.Values["id"], out IdSea_shipiment);
                Pwce(IdSea_shipiment);
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
                    RelatorioMaritimo.LocalReport.DataSources.Clear();
                    //
                    RelatorioMaritimo.LocalReport.DataSources.Add(new ReportDataSource("Formulario", ObjectDataSourceMaritimo));
                    RelatorioMaritimo.LocalReport.ReportPath = @"Maritimo.rdlc";
                }
            }
            catch (Exception erro)
            {
                lblAviso.Visible = true;
                lblAviso.Text = erro.Message;
                //
                RelatorioMaritimo.LocalReport.DataSources.Clear();
                RelatorioMaritimo.LocalReport.ReportPath = @"vazio.rdlc";
            }
        }

        protected void RelatorioMaritimo_Load(object sender, EventArgs e)
        {
            var fieldInfo = typeof(Microsoft.Reporting.WebForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //
            foreach (var extension in this.RelatorioMaritimo.LocalReport.ListRenderingExtensions())
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
                    string Sql = string.Format(@"SELECT PWCE FROM IMPORTACAO.SEA_SHIPMENT WHERE IDSEA_SHIPMENT={0}", Id);
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
            //Response.RedirectToRoute("novoMaritimo");
            if (!string.IsNullOrEmpty((string)Page.RouteData.Values["id"]))
            {
                int IdSea_shipiment = 0;
                Int32.TryParse((string)Page.RouteData.Values["id"], out IdSea_shipiment);
                Response.RedirectToRoute("Novo_Maritimo", new { id = IdSea_shipiment });
            }
        }

    }
}