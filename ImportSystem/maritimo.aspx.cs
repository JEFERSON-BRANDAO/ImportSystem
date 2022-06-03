using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Classes;

namespace ImportSystem
{
    public partial class maritimo : System.Web.UI.Page
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

        public void MantemCongeladoGridMaritimo()
        {
            //congela cabeçalho
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridMaritimo.ClientID + "', 293, 870 , 30 ,true); </script>", false);
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
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {

                try
                {
                    int liberado = chkLiberado.Checked ? 1 : 0;
                    string invoice = txtInvoice.Text;
                    string pwce = txtPwce.Text;
                    string packlist = txtPacklist.Text;
                    string sqlPwce = string.IsNullOrEmpty(pwce) ? " " : string.Format(" AND lower(trim(a.PWCE)) ='{0}' ", pwce.ToLower().Trim());
                    string sqlInvoice = string.IsNullOrEmpty(invoice) ? " " : string.Format(" AND lower(trim(a.INVOICE)) LIKE '%{0}%' ", invoice.ToLower().Trim());
                    string sqlCliente = string.IsNullOrEmpty(cboCliente.SelectedValue) ? " " : string.Format(" AND lower(trim(a.IDCLIENTE)) ='{0}' ", cboCliente.SelectedValue);
                    string sqlPacklist = string.IsNullOrEmpty(packlist) ? " " : string.Format(" AND lower(trim(a.PACKLIST)) LIKE '%{0}%' ", packlist.ToLower().Trim());
                    //
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    string sql = string.Format(@"SELECT  a.IDSEA_SHIPMENT AS Id,
                                             COALESCE(a.PWCE, '?') PWCE,
                                             CONCAT('', COALESCE(a.PEDIDO,  '?'),'') AS PEDIDO,   
                                             CONCAT('', a.INVOICE,']') AS INVOICE,
                                             CONCAT('', a.NR_CONTAINER,'') AS NR_CONTAINER,
                                             a.FOB_USD,
                                             CONCAT('', a.BL,'') AS BL,                                 
                                             CONCAT('', a.DI,'') AS DI, 
                                             a.ETA_MAO AS ETAMAO,                                         
                                             UPPER(a.CANAL_RF) AS CANAL_RF,
                                             UPPER(a.CANAL_SEFAZ) AS CANAL_SEFAZ,
                                             a.LIBERACAO_IRF,
                                             CASE a.LIBERADO
                                                WHEN 1 THEN 'SIM'
                                                ELSE 'NÃO'
                                             END LIBERADO,
                                             a.CRITICO                                         
                                     FROM importacao.sea_shipment a
                                     WHERE a.LIBERADO ={0}{1}{2}{3}{4} ORDER BY a.ETA_MAO DESC", liberado, sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    int row = 0;
                    int rowCount = Objconn.Tabela.Rows.Count;
                    if (rowCount > 0)
                    {
                        Session["refresh"] = Objconn.Tabela;
                        GridMaritimo.DataSource = Objconn.Tabela;// Session["refresh"];
                        GridMaritimo.DataBind();

                        //congela cabeçalho
                        MantemCongeladoGridMaritimo();

                        //foreach (GridViewRow rw in GridAereo.Rows)                      
                        foreach (DataRow rw in ((DataTable)Session["refresh"]).Rows)
                        {
                            for (int i = 0; i < GridMaritimo.Rows.Count; i++)
                            {

                                //string id = GridUsuario.DataKeys[index]["id"].ToString();//id definido como dataKeys
                                if (GridMaritimo.DataKeys[i]["id"].ToString() == rw[0].ToString())
                                {
                                    string cor_canal_rf = rw["CANAL_RF"].ToString();//rw.Cells[5].Text;
                                    if (cor_canal_rf.Equals("VERDE"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = verde;
                                    }
                                    else if (cor_canal_rf.Equals("VERMELHO"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = vermelho;
                                    }
                                    else if (cor_canal_rf.Equals("AMARELO"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = amarelo;
                                    }
                                    else if (cor_canal_rf.Equals("CINZA"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = cinza;
                                    }
                                    //
                                    string cor_canal_sefaz = rw["CANAL_SEFAZ"].ToString();//rw.Cells[6].Text;
                                    if (cor_canal_sefaz.Equals("VERDE"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = verde;
                                    }
                                    else if (cor_canal_sefaz.Equals("VERMELHO"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = vermelho;
                                    }
                                    else if (cor_canal_sefaz.Equals("AMARELO"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = amarelo;
                                    }
                                    else if (cor_canal_sefaz.Equals("CINZA"))
                                    {
                                        ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = cinza;
                                    }

                                    //Font-Underline="True"
                                    //((Label)GridMaritimo.Rows[row].Cells[8].FindControl("lbEta_MAO")).Style.Add("fore-color", "#00FF00");
                                    //string eta_MAO = ((Label)GridMaritimo.Rows[row].Cells[8].FindControl("lbEta_MAO")).Text;

                                    //eta_MAO = string.IsNullOrEmpty(eta_MAO) ? DateTime.Now.Date.ToString("yyyy-MM-dd") : eta_MAO;
                                    //DateTime dataAtual = DateTime.Now.Date;
                                    //DateTime dataMAO = DateTime.Parse(eta_MAO);
                                    //TimeSpan dif = dataAtual.Subtract(dataMAO);
                                    //((HyperLink)GridMaritimo.Rows[row].Cells[7].FindControl("HyperLinkDemurrage")).Text = dif.TotalDays >= int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString()) ? "Demurrage" : string.Empty;
                                    string eta_MAO = GridMaritimo.Rows[row].Cells[8].Text;
                                    if (rw["LIBERADO"].ToString().Equals("NÃO"))
                                    {
                                        GridMaritimo.Rows[row].Cells[11].Visible = true;
                                        ((HyperLink)GridMaritimo.Rows[row].Cells[9].FindControl("HyperLinkDemurrage")).Text = string.IsNullOrEmpty(eta_MAO) ? string.Empty : "Demurrage";

                                        if (Objconn.Tabela.Rows[i]["CRITICO"].ToString().Equals("1"))
                                        {
                                            ((Image)GridMaritimo.Rows[row].Cells[10].FindControl("imgCritico")).ImageUrl = vermelho;
                                            ((Image)GridMaritimo.Rows[row].Cells[10].FindControl("imgCritico")).Visible = true;
                                            ((Image)GridMaritimo.Rows[row].Cells[10].FindControl("imgCritico")).ToolTip = "Crítico";
                                        }
                                        else
                                        {
                                            ((Image)GridMaritimo.Rows[row].Cells[10].FindControl("imgCritico")).Visible = false;
                                        }

                                    }
                                    else
                                    {

                                        GridMaritimo.Rows[row].Cells[11].Visible = false;
                                        //((HyperLink)GridMaritimo.Rows[row].Cells[7].FindControl("HyperLinkDemurrage")).Text = string.Empty;

                                        if (Objconn.Tabela.Rows[i]["CRITICO"].ToString().Equals("1"))
                                        {
                                            ((Image)GridMaritimo.Rows[row].Cells[9].FindControl("imgCritico")).ImageUrl = vermelho;
                                            ((Image)GridMaritimo.Rows[row].Cells[9].FindControl("imgCritico")).Visible = true;
                                            ((Image)GridMaritimo.Rows[row].Cells[9].FindControl("imgCritico")).ToolTip = "Crítico";
                                        }
                                        else
                                        {
                                            ((Image)GridMaritimo.Rows[row].Cells[9].FindControl("imgCritico")).Visible = false;
                                        }
                                    }

                                    row++;
                                }

                                string etaMAO = Objconn.Tabela.Rows[i]["ETAMAO"].ToString();
                                if (!string.IsNullOrEmpty(etaMAO))
                                {
                                    if (Convert.ToDateTime(etaMAO) < DateTime.Now.Date)
                                    {
                                        GridMaritimo.Rows[i].BackColor = System.Drawing.Color.Yellow;
                                        GridMaritimo.Rows[i].ToolTip = "Embarque chegou";
                                    }
                                }
                                else
                                {
                                    GridMaritimo.Rows[i].BackColor = System.Drawing.Color.White;
                                }
                            }

                            //row++;
                        }
                        //
                        lbTotalRegistros.Text = rowCount.ToString();
                        //
                        Dados maritimo = new Dados();
                        DataTable dt = new DataTable();
                        dt = maritimo.RelatorioMaritimo(Convert.ToInt32(chkLiberado.Checked), sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
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
                        GridMaritimo.DataSource = null;
                        GridMaritimo.DataBind();
                        //
                        lbTotalRegistros.Text = "0";

                        GridExcel.DataSource = null;
                        GridExcel.DataBind();
                    }
                }
                catch (Exception erro)
                {
                    lbAviso.Visible = true;
                    lbAviso.Text = erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
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
                string sql = string.Format(@" SELECT a.IDSEA_SHIPMENT AS Id, 
                                 COALESCE(a.PWCE, '?') PWCE,
                                 COALESCE(a.PACKLIST, '-') PACKLIST,
                                 a.PEDIDO,
                                 a.INVOICE,
                                 a.FOB_USD,
                                 a.ETD_HK,
                                 a.ETA_MAO,
                                 a.DI,
                                 a.DATA,
                                 a.NR_CONTAINER,
                                 a.ETA_FOXCONN,
                                 a.QTD_PALLETS,
                                 a.DATA_DEVOLUCAO,
                                 a.REMARKS,
                                 a.BLS_OCEANUS,
                                 a.DTA,
                                 a.LIBERACAO_IRF,
                                 a.EMBARQUE,
								 b.NOME AS modelo,
								 c.NOME AS exportador,           
								 d.NOME AS recinto,
								 e.NOME AS armador,
								 f.NOME AS transp_local,
								 g.NOME AS despachante,
								 h.PRODUTO AS produto
                                 FROM IMPORTACAO.sea_shipment a
                                 INNER JOIN IMPORTACAO.modelo b ON a.IDMODELO= b.IDMODELO
                                 INNER JOIN IMPORTACAO.exportador c ON a.IDEXPORTADOR= c.IDEXPORTADOR
								 INNER JOIN IMPORTACAO.recinto d ON a.IDRECINTO = d.IDRECINTO
                                 INNER JOIN IMPORTACAO.armador e ON a.IDARMADOR = e.IDARMADOR
                                 INNER JOIN IMPORTACAO.transp_local f ON a.IDTRANSP_LOCAL = f.IDTRANSP_LOCAL
								 INNER JOIN IMPORTACAO.despachante g ON a.IDDESPACHANTE = g.IDDESPACHANTE
								 INNER JOIN IMPORTACAO.suframa h ON a.IDSUFRAMA= h.IDSUFRAMA
                                 WHERE a.IDSEA_SHIPMENT = {0}", Id);
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

        protected void GridMaritimo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region EXIBE OUTRO GRID COM MAIS INFORMAÇÃO

            if (e.CommandName == "selecionar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                //
                ShowGridInformacao(id.ToString());
                ModalPopupExtenderItem.Show();

                //mantém cabeçalho do GridMaritimo congelado
                MantemCongeladoGridMaritimo();
            }

            #endregion
        }

        //protected void GridMaritimo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    #region PAGINAÇÃO DO GRID

        //    GridMaritimo.PageIndex = e.NewPageIndex;
        //    //
        //    //GridMaritimo.DataSource = Session["refresh"];
        //    //GridMaritimo.DataBind();

        //    CarreGrid();

        //    int row = 0;
        //    foreach (DataRow rw in ((DataTable)Session["refresh"]).Rows)
        //    {
        //        for (int i = 0; i < GridMaritimo.Rows.Count; i++)
        //        {
        //            //string id = GridUsuario.DataKeys[index]["id"].ToString();//id definido como dataKeys
        //            if (GridMaritimo.DataKeys[i]["id"].ToString() == rw[0].ToString())
        //            {
        //                string cor_canal_rf = rw["CANAL_RF"].ToString();//rw.Cells[5].Text;
        //                if (cor_canal_rf.Equals("VERDE"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = verde;
        //                }
        //                else if (cor_canal_rf.Equals("VERMELHO"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = vermelho;
        //                }
        //                else if (cor_canal_rf.Equals("AMARELO"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = amarelo;
        //                }
        //                else if (cor_canal_rf.Equals("CINZA"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[5].FindControl("imgCanal_rf")).ImageUrl = cinza;
        //                }
        //                //
        //                string cor_canal_sefaz = rw["CANAL_SEFAZ"].ToString();//rw.Cells[7].Text;
        //                if (cor_canal_sefaz.Equals("VERDE"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = verde;
        //                }
        //                else if (cor_canal_sefaz.Equals("VERMELHO"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = vermelho;
        //                }
        //                else if (cor_canal_sefaz.Equals("AMARELO"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = amarelo;
        //                }
        //                else if (cor_canal_sefaz.Equals("CINZA"))
        //                {
        //                    ((Image)GridMaritimo.Rows[row].Cells[6].FindControl("imgCanal_sefaz")).ImageUrl = cinza;
        //                }

        //                //
        //                string eta_MAO = ((Label)GridMaritimo.Rows[row].Cells[8].FindControl("lbEta_MAO")).Text;
        //                eta_MAO = string.IsNullOrEmpty(eta_MAO) ? DateTime.Now.Date.ToString("yyyy-MM-dd") : eta_MAO;
        //                DateTime dataAtual = DateTime.Now.Date;
        //                DateTime dataMAO = DateTime.Parse(eta_MAO);
        //                TimeSpan dif = dataAtual.Subtract(dataMAO);
        //                //((HyperLink)GridMaritimo.Rows[row].Cells[7].FindControl("HyperLinkDemurrage")).Text = dif.TotalDays >= int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString()) ? "Demurrage" : string.Empty;


        //                row++;
        //            }
        //        }
        //        //row++;
        //    }

        //    #endregion
        //}

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("novoMaritimo.aspx");
            Response.RedirectToRoute("novoMaritimo");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

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
            Response.AddHeader("content-disposition", "attachment; filename=Maritimo.xls");
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

    }
}