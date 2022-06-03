using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace ImportSystem
{
    public partial class novoMaritimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAviso.Visible = false;
            divFormulario.Visible = false;
            //
            if (!IsPostBack)
            {
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

                //
                ComboCanalRF();
                ComboCanalSefaz();
                ComboModelo();
                ComboExportador();
                ComboRecinto();
                ComboArmador();
                ComboTransp_Local();
                ComboDespachante();
                ComboProd_Suframa();
                ComboCliente();
                ComboIcoterm();
                //

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

                //if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                //{
                if (!string.IsNullOrEmpty((string)Page.RouteData.Values["id"]))
                {
                    int IdSea_shipiment = 0;
                    Int32.TryParse((string)Page.RouteData.Values["id"], out IdSea_shipiment);

                    Dados maritimo = new Dados();
                    int rowCount = maritimo.ListaMaritimo(IdSea_shipiment).Count;
                    if (rowCount > 0)
                    {
                        //exibe botao formulário
                        divFormulario.Visible = true;

                        #region PREENCHE OS CAMPOS

                        DataTable dtMaritimo = maritimo.ListaMaritimo(IdSea_shipiment)[0];
                        //
                        chkCritico.Checked = dtMaritimo.Rows[0]["CRITICO"].ToString().Equals("1") ? true : false;
                        txtPwce.Text = dtMaritimo.Rows[0]["PWCE"].ToString();
                        txtPacklist.Text = dtMaritimo.Rows[0]["PACKLIST"].ToString();
                        txtPedido.Text = dtMaritimo.Rows[0]["PEDIDO"].ToString();
                        txtInvoice.Text = dtMaritimo.Rows[0]["INVOICE"].ToString();
                        txtFobUSD.Text = dtMaritimo.Rows[0]["FOB_USD"].ToString();
                        //chkLiberado.Checked = Convert.ToBoolean(dtMaritimo.Rows[0]["LIBERADO"]);
                        txtBL.Text = dtMaritimo.Rows[0]["BL"].ToString();
                        txtDI.Text = dtMaritimo.Rows[0]["DI"].ToString();
                        cboCanalRF.SelectedValue = dtMaritimo.Rows[0]["CANAL_RF"].ToString();
                        cboCanalSEFAZ.SelectedValue = dtMaritimo.Rows[0]["CANAL_SEFAZ"].ToString();
                        txtLibIRF.Text = dtMaritimo.Rows[0]["LIBERACAO_IRF"].ToString();
                        cboModelo.SelectedValue = dtMaritimo.Rows[0]["MODELO"].ToString();
                        cboExportador.SelectedValue = dtMaritimo.Rows[0]["EXPORTADOR"].ToString();
                        txtEtdHK.Text = dtMaritimo.Rows[0]["ETD_HK"].ToString();
                        txtEtaMAO.Text = dtMaritimo.Rows[0]["ETA_MAO"].ToString();
                        cboRecinto.SelectedValue = dtMaritimo.Rows[0]["RECINTO"].ToString();
                        cboIcoterm.SelectedValue = dtMaritimo.Rows[0]["IDICOTERM"].ToString();
                        txtDataDI.Text = dtMaritimo.Rows[0]["DATA"].ToString();
                        cboArmador.SelectedValue = dtMaritimo.Rows[0]["ARMADOR"].ToString();
                        txtEtaFoxconn.Text = dtMaritimo.Rows[0]["ETA_FOXCONN"].ToString();
                        txtNrContainer.Text = dtMaritimo.Rows[0]["NR_CONTAINER"].ToString();
                        txtQtdPallet.Text = dtMaritimo.Rows[0]["QTD_PALLETS"].ToString();
                        txtDataDevolucao.Text = dtMaritimo.Rows[0]["DATA_DEVOLUCAO"].ToString();
                        txtRemarks.Text = dtMaritimo.Rows[0]["REMARKS"].ToString();
                        cboTranspLocal.SelectedValue = dtMaritimo.Rows[0]["TRANSP_LOCAL"].ToString();
                        cboDespachante.SelectedValue = dtMaritimo.Rows[0]["DESPACHANTE"].ToString();
                        txtBLsOceanus.Text = dtMaritimo.Rows[0]["BLS_OCEANUS"].ToString();
                        txtDTA.Text = dtMaritimo.Rows[0]["DTA"].ToString();
                        cboProdSuframa.SelectedValue = dtMaritimo.Rows[0]["PRODUTO"].ToString();
                        txtEmbarque.Text = dtMaritimo.Rows[0]["EMBARQUE"].ToString();
                        cboCliente.SelectedValue = dtMaritimo.Rows[0]["CLIENTE"].ToString();

                        #endregion
                    }
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("maritimo");
        }

        public void ComboCanalRF()
        {
            cboCanalRF.Items.Insert(0, new ListItem("[Selecione]", string.Empty));
            cboCanalRF.Items.Insert(1, new ListItem("VERDE", "VERDE"));
            cboCanalRF.Items.Insert(2, new ListItem("VERMELHO", "VERMELHO"));
            cboCanalRF.Items.Insert(3, new ListItem("AMARELO", "AMARELO"));
            cboCanalRF.Items.Insert(4, new ListItem("CINZA", "CINZA"));
        }

        public void ComboCanalSefaz()
        {
            cboCanalSEFAZ.Items.Insert(0, new ListItem("[Selecione]", string.Empty));
            cboCanalSEFAZ.Items.Insert(1, new ListItem("VERDE", "VERDE"));
            cboCanalSEFAZ.Items.Insert(2, new ListItem("VERMELHO", "VERMELHO"));
            cboCanalSEFAZ.Items.Insert(3, new ListItem("AMARELO", "AMARELO"));
            cboCanalSEFAZ.Items.Insert(4, new ListItem("CINZA", "CINZA"));
        }

        public void ComboModelo()
        {
            Dados lista = new Dados();
            //
            cboModelo.DataSource = lista.ListaModelo();
            cboModelo.DataTextField = "NOME";
            cboModelo.DataValueField = "ID";
            cboModelo.DataBind();
            cboModelo.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboExportador()
        {
            Dados lista = new Dados();
            //
            cboExportador.DataSource = lista.ListaExportador();
            cboExportador.DataTextField = "NOME";
            cboExportador.DataValueField = "ID";
            cboExportador.DataBind();
            cboExportador.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboRecinto()
        {
            Dados lista = new Dados();
            //
            cboRecinto.DataSource = lista.ListaRecinto();
            cboRecinto.DataTextField = "NOME";
            cboRecinto.DataValueField = "ID";
            cboRecinto.DataBind();
            cboRecinto.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboArmador()
        {
            Dados lista = new Dados();
            //
            cboArmador.DataSource = lista.ListaArmador();
            cboArmador.DataTextField = "NOME";
            cboArmador.DataValueField = "ID";
            cboArmador.DataBind();
            cboArmador.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboTransp_Local()
        {
            Dados lista = new Dados();
            //
            cboTranspLocal.DataSource = lista.ListaTranspLocal();
            cboTranspLocal.DataTextField = "NOME";
            cboTranspLocal.DataValueField = "ID";
            cboTranspLocal.DataBind();
            cboTranspLocal.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboDespachante()
        {
            Dados lista = new Dados();
            //
            cboDespachante.DataSource = lista.ListaDespachante();
            cboDespachante.DataTextField = "NOME";
            cboDespachante.DataValueField = "ID";
            cboDespachante.DataBind();
            cboDespachante.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboProd_Suframa()
        {
            Dados lista = new Dados();
            //
            cboProdSuframa.DataSource = lista.ListaProduto();
            cboProdSuframa.DataTextField = "PRODUTO";
            cboProdSuframa.DataValueField = "ID";
            cboProdSuframa.DataBind();
            cboProdSuframa.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboCliente()
        {
            Dados lista = new Dados();
            //
            cboCliente.DataSource = lista.ListaCliente();
            cboCliente.DataTextField = "NOME";
            cboCliente.DataValueField = "ID";
            cboCliente.DataBind();
            cboCliente.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboIcoterm()
        {
            Dados lista = new Dados();
            //
            cboIcoterm.DataSource = lista.ListaIcoTerm();
            cboIcoterm.DataTextField = "NOME";
            cboIcoterm.DataValueField = "ID";
            cboIcoterm.DataBind();
            cboIcoterm.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        private bool ExisteCampoVazio()
        {
            //txtLibIRF.Text.Equals(string.Empty) || txtEtaFoxconn.Text.Equals(string.Empty) ||   txtDataDevolucao.Text.Equals(string.Empty) txtEtdHK.Text.Equals(string.Empty) || txtEtaMAO.Text.Equals(string.Empty) || txtDataDI.Text.Equals(string.Empty) ||

            if (txtInvoice.Text.Equals(string.Empty) || txtFobUSD.Text.Equals(string.Empty) ||
                txtBL.Text.Equals(string.Empty) ||
                txtNrContainer.Text.Equals(string.Empty) || txtQtdPallet.Text.Equals(string.Empty) || cboCliente.SelectedValue.ToString().Equals(string.Empty) ||
                txtRemarks.Text.Equals(string.Empty) || txtBLsOceanus.Text.Equals(string.Empty) || cboIcoterm.SelectedValue.ToString().Equals(string.Empty) ||
                cboModelo.SelectedValue.ToString().Equals(string.Empty) || cboExportador.SelectedValue.ToString().Equals(string.Empty) ||
                cboRecinto.SelectedValue.ToString().Equals(string.Empty) || cboArmador.SelectedValue.ToString().Equals(string.Empty) ||
                cboTranspLocal.SelectedValue.ToString().Equals(string.Empty) || cboDespachante.SelectedValue.ToString().Equals(string.Empty) ||
                cboProdSuframa.SelectedValue.ToString().Equals(string.Empty)


                )
            {
                return true;
            }

            return false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            if (!string.IsNullOrEmpty((string)Page.RouteData.Values["id"]))
            {
                if (!ExisteCampoVazio())
                {
                    if (Page.IsValid)
                    {
                        if ((!string.IsNullOrEmpty(txtLibIRF.Text)) && (!string.IsNullOrEmpty(txtLibIRF.Text)))
                        {
                            if (Convert.ToDateTime(txtLibIRF.Text) < Convert.ToDateTime(txtDataDI.Text))
                            {
                                lbAviso.Visible = true;
                                lbAviso.Text = "Data da Liberação não pode ser menor que data da DI";
                                return;
                            }
                        }
                        //
                        #region UPDATE

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        //
                        try
                        {
                            try
                            {
                                Objconn.Conectar();
                                Objconn.Parametros.Clear();
                                //
                                int Id = 0;
                                //Int32.TryParse(Request.QueryString["id"], out Id);
                                Int32.TryParse((string)Page.RouteData.Values["id"], out Id);
                                //
                                int critico = chkCritico.Checked.Equals(true) ? 1 : 0;
                                string pwce = string.IsNullOrEmpty(txtPwce.Text) ? "null" : " '" + txtPwce.Text.Trim() + "'";
                                string packlist = string.IsNullOrEmpty(txtPacklist.Text) ? "null" : " '" + txtPacklist.Text.Trim() + "'";
                                string pedido = string.IsNullOrEmpty(txtPedido.Text) ? "null" : " '" + txtPedido.Text.Trim() + "'";
                                string invoice = txtInvoice.Text.Trim();
                                string fobUSD = txtFobUSD.Text;
                                int liberado = string.IsNullOrEmpty(txtDataDevolucao.Text) ? 0 : 1;  //string.IsNullOrEmpty(txtDataDevolucao.Text) ? 0 : 1;// chkLiberado.Checked ? 1 : 0;
                                string BL = txtBL.Text;
                                string DI = txtDI.Text;
                                string canal_RF = cboCanalRF.SelectedValue;
                                string canal_Sefaz = cboCanalSEFAZ.SelectedValue;
                                string liberacaoIRF = string.IsNullOrEmpty(txtLibIRF.Text) ? "null" : " '" + Convert.ToDateTime(txtLibIRF.Text).ToString("yyyy-MM-dd") + "'";
                                int modelo = int.Parse(cboModelo.SelectedValue);
                                int exportador = int.Parse(cboExportador.SelectedValue);
                                string etd_HK = string.IsNullOrEmpty(txtEtdHK.Text) ? "null" : " '" + Convert.ToDateTime(txtEtdHK.Text).ToString("yyyy-MM-dd") + "'";
                                string eta_MAO = string.IsNullOrEmpty(txtEtaMAO.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaMAO.Text).ToString("yyyy-MM-dd") + "'";
                                int recinto = int.Parse(cboRecinto.SelectedValue);
                                string data = string.IsNullOrEmpty(txtDataDI.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDI.Text).ToString("yyyy-MM-dd") + "'";
                                int armador = int.Parse(cboArmador.SelectedValue);
                                string eta_Foxonn = string.IsNullOrEmpty(txtEtaFoxconn.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaFoxconn.Text).ToString("yyyy-MM-dd") + "'";
                                string nr_Container = txtNrContainer.Text;
                                int qtdPallets = int.Parse(txtQtdPallet.Text);
                                string dataDevolucao = string.IsNullOrEmpty(txtDataDevolucao.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                                string remarks = txtRemarks.Text;
                                int transp_local = int.Parse(cboTranspLocal.SelectedValue);
                                int despachante = int.Parse(cboDespachante.SelectedValue);
                                string BLs_Oceanus = txtBLsOceanus.Text;
                                string DTA = txtDTA.Text;
                                int produto = int.Parse(cboProdSuframa.SelectedValue);
                                string embarque = string.IsNullOrEmpty(txtEmbarque.Text) ? "null" : " '" + txtEmbarque.Text + "'";
                                int cliente = int.Parse(cboCliente.SelectedValue);
                                int icoterm = int.Parse(cboIcoterm.SelectedValue);
                                //
                                string Sql = string.Format(@"UPDATE importacao.sea_shipment  SET 
                                                                               pwce              =  {0},
                                                                               packlist          =  {1},
                                                                               pedido            =  {2},
                                                                               invoice           = '{3}',
                                                                               fob_usd           = '{4}',    
                                                                               liberado          =  {5},                                                                
                                                                               bl                = '{6}',
                                                                               di                = '{7}',
                                                                               canal_rf          = '{8}',
                                                                               canal_sefaz       = '{9}',
                                                                               liberacao_irf     =  {10},
                                                                               idmodelo          = '{11}',
                                                                               idexportador      = '{12}',
                                                                               etd_hk            =  {13},
                                                                               eta_mao           =  {14},
                                                                               idrecinto         = '{15}',
                                                                               data              =  {16},
                                                                               idarmador         = '{17}',
                                                                               eta_foxconn       =  {18},
                                                                               nr_container      = '{19}',
                                                                               qtd_pallets       = '{20}',
                                                                               data_devolucao    =  {21},
                                                                               remarks           = '{22}',
                                                                               idtransp_local    = '{23}',
                                                                               iddespachante     = '{24}',
                                                                               bls_oceanus       = '{25}',
                                                                               dta               = '{26}',     
                                                                               idsuframa         = '{27}',  
                                                                               embarque          =  {28},                                                                       
                                                                               idcliente         =  {29},
                                                                               idicoterm         =  {30},
                                                                               critico           =  {31}
                                                                         WHERE idsea_shipment    =  {32}",
                                                                         pwce, packlist, pedido, invoice, fobUSD, liberado, BL, DI, canal_RF,
                                                                         canal_Sefaz, liberacaoIRF, modelo, exportador,
                                                                         etd_HK, eta_MAO, recinto, data, armador, eta_Foxonn, nr_Container,
                                                                         qtdPallets, dataDevolucao, remarks, transp_local, despachante,
                                                                         BLs_Oceanus, DTA, produto, embarque, cliente, icoterm, critico, Id);
                                //
                                Objconn.SetarSQL(Sql);
                                Objconn.Executar();
                                //
                                if (Objconn.Isvalid)
                                {
                                    //Response.Redirect("maritimo.aspx");
                                    Response.RedirectToRoute("maritimo");
                                }
                                else
                                {
                                    lbAviso.Visible = true;
                                    lbAviso.Text = "Erro::" + Objconn.Message;
                                }
                            }
                            catch (Exception erro)
                            {
                                lbAviso.Visible = true;
                                lbAviso.Text = "Erro::" + erro.Message;
                            }

                        }
                        finally
                        {
                            Objconn.Desconectar();
                        }

                        #endregion

                    }
                }

            }
            else
            {
                if (!ExisteCampoVazio())
                {
                    if (Page.IsValid)
                    {
                        if ((!string.IsNullOrEmpty(txtLibIRF.Text)) && (!string.IsNullOrEmpty(txtLibIRF.Text)))
                        {
                            if (Convert.ToDateTime(txtLibIRF.Text) < Convert.ToDateTime(txtDataDI.Text))
                            {
                                lbAviso.Visible = true;
                                lbAviso.Text = "Data da Liberação não pode ser menor que data da DI";
                                return;
                            }
                        }
                        //
                        #region INSERT

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        //
                        try
                        {
                            try
                            {
                                Objconn.Conectar();
                                Objconn.Parametros.Clear();
                                //
                                int critico = chkCritico.Checked.Equals(true) ? 1 : 0;
                                string pwce = string.IsNullOrEmpty(txtPwce.Text) ? "null" : " '" + txtPwce.Text.Trim() + "'";
                                string packlist = string.IsNullOrEmpty(txtPacklist.Text) ? "null" : " '" + txtPacklist.Text.Trim() + "'";
                                string pedido = string.IsNullOrEmpty(txtPedido.Text) ? "null" : " '" + txtPedido.Text.Trim() + "'";
                                string invoice = txtInvoice.Text.Trim();
                                string fobUSD = txtFobUSD.Text;
                                int liberado = string.IsNullOrEmpty(txtDataDevolucao.Text) ? 0 : 1;//string.IsNullOrEmpty(txtDataDevolucao.Text) ? 0 : 1;//chkLiberado.Checked ? 1 : 0;
                                string BL = txtBL.Text;
                                string DI = txtDI.Text;
                                string canal_RF = cboCanalRF.SelectedValue;
                                string canal_Sefaz = cboCanalSEFAZ.SelectedValue;
                                string liberacaoIRF = string.IsNullOrEmpty(txtLibIRF.Text) ? "null" : " '" + Convert.ToDateTime(txtLibIRF.Text).ToString("yyyy-MM-dd") + "'";
                                int modelo = int.Parse(cboModelo.SelectedValue);
                                int exportador = int.Parse(cboExportador.SelectedValue);
                                string etd_HK = string.IsNullOrEmpty(txtEtdHK.Text) ? "null" : " '" + Convert.ToDateTime(txtEtdHK.Text).ToString("yyyy-MM-dd") + "'";
                                string eta_MAO = string.IsNullOrEmpty(txtEtaMAO.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaMAO.Text).ToString("yyyy-MM-dd") + "'";
                                int recinto = int.Parse(cboRecinto.SelectedValue);
                                string data = string.IsNullOrEmpty(txtDataDI.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDI.Text).ToString("yyyy-MM-dd") + "'";
                                int armador = int.Parse(cboArmador.SelectedValue);
                                string eta_Foxonn = string.IsNullOrEmpty(txtEtaFoxconn.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaFoxconn.Text).ToString("yyyy-MM-dd") + "'";
                                string nr_Container = txtNrContainer.Text;
                                int qtdPallets = int.Parse(txtQtdPallet.Text);
                                string dataDevolucao = string.IsNullOrEmpty(txtDataDevolucao.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                                string remarks = txtRemarks.Text;
                                int transp_local = int.Parse(cboTranspLocal.SelectedValue);
                                int despachante = int.Parse(cboDespachante.SelectedValue);
                                string BLs_Oceanus = txtBLsOceanus.Text;
                                string DTA = txtDTA.Text;
                                int produto = int.Parse(cboProdSuframa.SelectedValue);
                                string embarque = string.IsNullOrEmpty(txtEmbarque.Text) ? "null" : " '" + txtEmbarque.Text + "'";
                                int cliente = int.Parse(cboCliente.SelectedValue);
                                int icoterm = int.Parse(cboIcoterm.SelectedValue);
                                //                           
                                string Sql = string.Format(@"INSERT INTO importacao.sea_shipment 
                                                                              (pwce,
                                                                               packlist,
                                                                               pedido,
                                                                               invoice,
                                                                               fob_usd,
                                                                               liberado,                                                           
                                                                               bl,
                                                                               di,
                                                                               canal_rf,
                                                                               canal_sefaz,
                                                                               liberacao_irf,
                                                                               idmodelo,
                                                                               idexportador,
                                                                               etd_hk,
                                                                               eta_mao,
                                                                               idrecinto,
                                                                               data,
                                                                               idarmador,
                                                                               eta_foxconn,
                                                                               nr_container,
                                                                               qtd_pallets,
                                                                               data_devolucao,
                                                                               remarks,
                                                                               idtransp_local,
                                                                               iddespachante,
                                                                               bls_oceanus,
                                                                               dta,                                                                    
                                                                               idsuframa,
                                                                               embarque,
                                                                               idcliente,
                                                                               idicoterm,
                                                                               critico)
                                                                         VALUES
                                                                               ({0},{1},{2},'{3}','{4}',{5},'{6}','{7}',
                                                                                '{8}','{9}',{10},'{11}','{12}',{13},{14},{15},
                                                                                {16},{17},{18},'{19}','{20}',{21},'{22}',
                                                                               '{23}','{24}','{25}','{26}','{27}',{28},{29},{30},{31})",
                                                                                pwce, packlist, pedido, invoice, fobUSD, liberado, BL, DI, canal_RF,
                                                                                canal_Sefaz, liberacaoIRF, modelo, exportador,
                                                                                etd_HK, eta_MAO, recinto, data, armador, eta_Foxonn,
                                                                                nr_Container, qtdPallets, dataDevolucao, remarks,
                                                                                transp_local, despachante, BLs_Oceanus, DTA, produto,
                                                                                embarque, cliente, icoterm, critico);



                                //
                                Objconn.SetarSQL(Sql);
                                Objconn.Executar();
                                //
                                if (Objconn.Isvalid)
                                {
                                    //Response.Redirect("maritimo.aspx");
                                    Response.RedirectToRoute("maritimo");
                                }
                                else
                                {
                                    lbAviso.Visible = true;
                                    lbAviso.Text = "Erro::" + Objconn.Message;
                                }
                            }
                            catch (Exception erro)
                            {
                                lbAviso.Visible = true;
                                lbAviso.Text = "Erro::" + erro.Message;
                            }
                        }
                        finally
                        {
                            Objconn.Desconectar();
                        }

                        #endregion

                    }
                }
            }
        }

        protected void btnFormulario_Click(object sender, ImageClickEventArgs e)
        {
            ////Response.RedirectToRoute("formularioMaritimo");
            //if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            //{
            //    int IdAir_shipiment = 0;
            //    Int32.TryParse(Request.QueryString["id"], out IdAir_shipiment);
            //    Response.RedirectToRoute("formularioMaritimo?id=" + IdAir_shipiment);
            //}
            //else
            //{
            //    Response.RedirectToRoute("formularioMaritimo");
            //}
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int IdSea_shipiment = 0;
                Int32.TryParse(Request.QueryString["id"], out IdSea_shipiment);
                Response.RedirectToRoute("formularioMaritimo", new { id = IdSea_shipiment });

            }
            else
            {
                Response.RedirectToRoute("formularioMaritimo");
            }
        }

    }
}