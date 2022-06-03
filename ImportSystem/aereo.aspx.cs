using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;
using System.Configuration;

namespace ImportSystem
{
    public partial class aereo : System.Web.UI.Page
    {
        internal string verde = ConfigurationManager.AppSettings["bolinhaVerde"].ToString();
        internal string vermelho = ConfigurationManager.AppSettings["bolinhaVermelha"].ToString();
        internal string amarelo = ConfigurationManager.AppSettings["bolinhaAmarela"].ToString();
        internal string cinza = ConfigurationManager.AppSettings["bolinhaCinza"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            lbAviso.Visible = false;

            if (!IsPostBack)
            {
                CarreGrid();

                int Id = 0;
                //
                try
                {
                    Id = Convert.ToInt32(Session["id"]);
                }
                catch (Exception)
                {
                    Session["id"] = 0;
                    //Response.Redirect("Login.aspx");
                    Response.RedirectToRoute("login");
                }

                ControleAcesso acesso = new ControleAcesso();
                string tipoUsuario = acesso.Permissao(Id);
                if (tipoUsuario != "ADMINISTRADOR")
                {
                    btnSalvar.Visible = false;
                }
                else
                {
                    btnSalvar.Visible = true;
                }

                ComboCliente();
            }
        }

        public void MantemCongeladoGridAereo() 
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridAereo.ClientID + "', 293, 850 , 30 ,true); </script>", false);
        }

        public void ComboCliente()
        {
            Dados lista = new Dados();
            //
            cboCliente.DataSource = lista.ListaCliente();
            cboCliente.DataTextField = "NOME";
            cboCliente.DataValueField = "ID";
            cboCliente.DataBind();
            cboCliente.Items.Insert(0, new ListItem("[Todos]", string.Empty));

        }

        public void CarreGrid()
        {
            try
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {

                    int liberado = chkLiberado.Checked ? 1 : 0;
                    string invoice = txtInvoice.Text;
                    string pwce = txtPwce.Text;
                    string packlist = txtPackList.Text;
                    string sqlPwce = string.IsNullOrEmpty(pwce) ? " " : string.Format(" AND lower(trim(a.PWCE)) ='{0}' ", pwce.ToLower().Trim());
                    string sqlInvoice = string.IsNullOrEmpty(invoice) ? " " : string.Format(" AND lower(trim(a.INVOICE)) LIKE '%{0}%' ", invoice.ToLower().Trim());
                    string sqlCliente = string.IsNullOrEmpty(cboCliente.SelectedValue) ? " " : string.Format(" AND lower(trim(a.IDCLIENTE)) ='{0}' ", cboCliente.SelectedValue);
                    string sqlPacklist = string.IsNullOrEmpty(packlist) ? " " : string.Format(" AND lower(trim(a.PACKLIST)) LIKE '%{0}%' ", packlist.ToLower().Trim());
                    //
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    string sql = string.Format(@"SELECT  a.IDAIR_SHIPMENT AS Id,
                                             COALESCE(a.PWCE, '?') PWCE,       
                                             COALESCE(a.PEDIDO, '?') PEDIDO, 
                                             COALESCE(a.PACKLIST, '-') PACKLIST,                                          
                                             a.INVOICE,
                                             a.MATERIAL,
                                             a.QUANTIDADE,
                                             a.VLR_FOB,
                                             a.HAWB,
                                             a.MAWB,
                                             a.DI,
                                             a.DATA_DI,
                                             UPPER(a.CANAL_RF) AS CANAL_RF,
                                             UPPER(a.CANAL_SEFAZ) AS CANAL_SEFAZ,
                                             a.LIBERACAO,
                                             a.REMARK,
                                             a.DATA_ENVIO,
                                             CASE a.LIBERADO
                                                WHEN 1 THEN 'SIM'
                                                ELSE 'NÃO'
                                             END LIBERADO,
                                             a.ETA_MAO AS ETAMAO,
                                             a.CRITICO                                         
                                     FROM importacao.air_shipment a
                                     WHERE a.LIBERADO = {0}{1}{2}{3}{4} ORDER BY a.ETA_MAO DESC", liberado, sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    int row = 0;
                    int rowCount = Objconn.Tabela.Rows.Count;
                    if (rowCount > 0)
                    {
                        Session["refresh"] = Objconn.Tabela;
                        GridAereo.DataSource = Objconn.Tabela;//Session["refresh"];
                        GridAereo.DataBind();

                        //congela cabeçalho
                        MantemCongeladoGridAereo();
 
                        //foreach (GridViewRow rw in GridAereo.Rows)                      
                        foreach (DataRow rw in ((DataTable)Session["refresh"]).Rows)
                        {
                            for (int i = 0; i < GridAereo.Rows.Count; i++)
                            {

                                if (Objconn.Tabela.Rows[i]["CRITICO"].ToString().Equals("1"))
                                {
                                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCritico")).ImageUrl = vermelho;
                                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCritico")).Visible = true;
                                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCritico")).ToolTip = "Crítico";
                                }
                                else
                                {
                                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCritico")).Visible = false;
                                }

                                //string id = GridUsuario.DataKeys[index]["id"].ToString();//id definido como dataKeys
                                if (GridAereo.DataKeys[i]["id"].ToString().Equals(rw[0].ToString()))
                                {
                                    string cor_canal_rf = rw["CANAL_RF"].ToString();//rw.Cells[5].Text;
                                    if (cor_canal_rf.Equals("VERDE"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = verde;
                                    }
                                    else if (cor_canal_rf.Equals("VERMELHO"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = vermelho;
                                    }
                                    else if (cor_canal_rf.Equals("AMARELO"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = amarelo;
                                    }
                                    else if (cor_canal_rf.Equals("CINZA"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = cinza;
                                    }
                                    //
                                    string cor_canal_sefaz = rw["CANAL_SEFAZ"].ToString();//rw.Cells[6].Text;
                                    if (cor_canal_sefaz.Equals("VERDE"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = verde;
                                    }
                                    else if (cor_canal_sefaz.Equals("VERMELHO"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = vermelho;
                                    }
                                    else if (cor_canal_sefaz.Equals("AMARELO"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = amarelo;
                                    }
                                    else if (cor_canal_sefaz.Equals("CINZA"))
                                    {
                                        ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = cinza;
                                    }

                                    row++;
                                }

                                string etaMAO = Objconn.Tabela.Rows[i]["ETAMAO"].ToString();
                                if (!string.IsNullOrEmpty(etaMAO))
                                {
                                    if (Convert.ToDateTime(etaMAO) < DateTime.Now.Date)
                                    {
                                        GridAereo.Rows[i].BackColor = System.Drawing.Color.Yellow;
                                        GridAereo.Rows[i].ToolTip = "Embarque chegou";
                                    }
                                }
                                else 
                                {
                                    GridAereo.Rows[i].BackColor = System.Drawing.Color.White;
                                }
                            }

                            //row++;
                        }
                        //
                        lbTotalRegistros.Text = rowCount.ToString();

                        Dados aereo = new Dados();
                        DataTable dt = new DataTable();
                        dt = aereo.RelatorioAereo(Convert.ToInt32(chkLiberado.Checked), sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
                        //
                        int row_Count = dt.Rows.Count;
                        if (row_Count > 0)
                        {
                            GridExcel.DataSource = dt;
                            GridExcel.DataBind();
                        }
                    }
                    else
                    {
                        GridAereo.DataSource = null;
                        GridAereo.DataBind();
                        //
                        lbTotalRegistros.Text = "0";

                        GridExcel.DataSource = null;
                        GridExcel.DataBind();
                    }
                }
                finally
                {
                    Objconn.Desconectar();
                }
            }
            catch (Exception erro)
            {
                lbAviso.Visible = true;
                lbAviso.Text = erro.Message;
            }
        }

        public void ShowGridInformacao(string Id)
        {

            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string sql = string.Format(@"SELECT a.IDAIR_SHIPMENT AS Id, a.PEDIDO, COALESCE(a.PWCE, '?') PWCE, COALESCE(a.PACKLIST, '-') PACKLIST,  a.INVOICE, a.MATERIAL AS material, a.ETD_ORIGIN AS etdOrigin, a.ETA_MAO AS etaMao, a.liberacao, a.DATA_DI AS dataDi, a.ETA_FOXCONN AS etaFoxconn,a.REMARK AS remark, a.DATA_ENVIO AS dtEnvio,
		                                b.NOME AS fornecedor,
                                        c.NOME AS local,
                                        e.NOME AS icoterm,
                                        f.NOME AS forwarder,
                                        g.NOME AS recinto,
                                        h.NOME AS despachante
                                 FROM IMPORTACAO.air_shipment a
                                 INNER JOIN IMPORTACAO.fornecedor b ON a.IDFORNECEDOR= b.IDFORNECEDOR
                                 INNER JOIN IMPORTACAO.local c ON a.IDLOCAL= c.IDLOCAL
                                 INNER JOIN IMPORTACAO.moeda d ON a.IDMOEDA = d.IDMOEDA
                                 INNER JOIN IMPORTACAO.icoterm e ON a.IDICOTERM = e.IDICOTERM
                                 INNER JOIN IMPORTACAO.forwarder f ON a.IDFORWARDER = f.IDFORWARDER
                                 INNER JOIN IMPORTACAO.recinto g ON a.IDRECINTO = g.IDRECINTO
                                 INNER JOIN IMPORTACAO.despachante h ON a.IDDESPACHANTE = h.IDDESPACHANTE
                                 WHERE a.IDAIR_SHIPMENT = {0}", Id);
                //
                Objconn.SetarSQL(sql);
                Objconn.Executar();
                //
                int rowCount = Objconn.Tabela.Rows.Count;
                if (rowCount > 0)
                {
                    GridInformacao.DataSource = Objconn.Tabela;
                    GridInformacao.DataBind();
                    //
                    lbInvoice.Text = Objconn.Tabela.Rows[0]["INVOICE"].ToString();
                }
                else
                {
                    GridInformacao.DataSource = null;
                    GridInformacao.DataBind();

                }
            }
            finally
            {
                Objconn.Desconectar();
            }
        }

        protected void GridAereo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region EXIBE OUTRO GRID COM MAIS INFORMAÇÃO

            if (e.CommandName == "selecionar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                //
                ShowGridInformacao(id.ToString());
                ModalPopupExtenderItem.Show();

                //mantém cabeçalho do GridAereo congelado 
                MantemCongeladoGridAereo(); 
            }

            #endregion
        }

        //protected void GridAereo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    #region PAGINAÇÃO DO GRID

        //    GridAereo.PageIndex = e.NewPageIndex;
        //    //
        //    GridAereo.DataSource = Session["refresh"];
        //    GridAereo.DataBind();

        //    int row = 0;
        //    foreach (DataRow rw in ((DataTable)Session["refresh"]).Rows)
        //    {
        //        for (int i = 0; i < GridAereo.Rows.Count; i++)
        //        {
        //            //string id = GridUsuario.DataKeys[index]["id"].ToString();//id definido como dataKeys
        //            if (GridAereo.DataKeys[i]["id"].ToString() == rw[0].ToString())
        //            {
        //                string cor_canal_rf = rw["CANAL_RF"].ToString();//rw.Cells[5].Text;
        //                if (cor_canal_rf.Equals("VERDE"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = verde;
        //                }
        //                else if (cor_canal_rf.Equals("VERMELHO"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = vermelho;
        //                }
        //                else if (cor_canal_rf.Equals("AMARELO"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = amarelo;
        //                }
        //                else if (cor_canal_rf.Equals("CINZA"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = cinza;
        //                }
        //                //
        //                string cor_canal_sefaz = rw["CANAL_SEFAZ"].ToString();//rw.Cells[7].Text;
        //                if (cor_canal_sefaz.Equals("VERDE"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = verde;
        //                }
        //                else if (cor_canal_sefaz.Equals("VERMELHO"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = vermelho;
        //                }
        //                else if (cor_canal_sefaz.Equals("AMARELO"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = amarelo;
        //                }
        //                else if (cor_canal_sefaz.Equals("CINZA"))
        //                {
        //                    ((Image)GridAereo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = cinza;
        //                }

        //                row++;
        //            }
        //        }
        //        //row++;
        //    }

        //    #endregion
        //}

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarreGrid();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */

            //PARA NÃO OCORRER ERROR:
            //Control 'MainContent_GridSolicitacoes' of type 'GridView' must be placed inside a form tag with runat=server.           
        }

        public void ExportarExcel()
        {
            GridExcel.Visible = true;//apenas para os dados não vierem vázios
            //
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Aereo.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridExcel.GridLines = GridLines.Both;//grid no excel com borda
            GridExcel.HeaderStyle.Font.Bold = true;
            GridExcel.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("default");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("novoAereo");
        }


    }
}