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
    public partial class novoAereo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtQuantidade.Attributes["type"] = "number";
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
                ComboFornecedor();
                ComboLocal();
                ComboMoeda();
                ComboIcoterm();
                ComboForwarder();
                ComboRecinto();
                ComboDespachante();
                ComboCanalSefaz();
                ComboCanalRF();
                ComboCliente();
                ComboModelo();


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
                if (!string.IsNullOrEmpty((string)Page.RouteData.Values["id"]))
                {
                    int IdAir_shipiment = 0;
                    Int32.TryParse((string)Page.RouteData.Values["id"], out IdAir_shipiment);
                    //Int32.TryParse(Request.QueryString["id"], out IdAir_shipiment);
                    //
                    Dados aereo = new Dados();
                    int rowCount = aereo.ListaAereo(IdAir_shipiment).Count;
                    if (rowCount > 0)
                    {
                        //exibe botao formulário
                        divFormulario.Visible = true;

                        #region PREENCHE OS CAMPOS

                        DataTable dtAereo = aereo.ListaAereo(IdAir_shipiment)[0];
                        //                       
                        chkCritico.Checked = dtAereo.Rows[0]["CRITICO"].ToString().Equals("1") ? true : false;
                        txtPwce.Text = dtAereo.Rows[0]["PWCE"].ToString();
                        txtPackList.Text = dtAereo.Rows[0]["PACKLIST"].ToString();
                        txtPedido.Text = dtAereo.Rows[0]["PEDIDO"].ToString();
                        txtInvoice.Text = dtAereo.Rows[0]["INVOICE"].ToString();
                        txtMaterial.Text = dtAereo.Rows[0]["MATERIAL"].ToString();
                        //chkLiberado.Checked = Convert.ToBoolean(dtAereo.Rows[0]["LIBERADO"]);
                        txtValorFOB.Text = dtAereo.Rows[0]["VLR_FOB"].ToString();
                        txtHawb.Text = dtAereo.Rows[0]["HAWB"].ToString();
                        txtMawb.Text = dtAereo.Rows[0]["MAWB"].ToString();
                        txtETDOrigin.Text = dtAereo.Rows[0]["ETD_ORIGIN"].ToString();
                        txtETDMia.Text = dtAereo.Rows[0]["ETD_MIA"].ToString();
                        cboModelo.SelectedValue = dtAereo.Rows[0]["MODELO"].ToString();
                        txtEtaMao.Text = dtAereo.Rows[0]["ETA_MAO"].ToString();
                        txtDI.Text = dtAereo.Rows[0]["DI"].ToString();
                        txtDataDI.Text = dtAereo.Rows[0]["DATA_DI"].ToString();
                        cboCanalRF.SelectedValue = dtAereo.Rows[0]["CANAL_RF"].ToString();
                        cboCanalSEFAZ.SelectedValue = dtAereo.Rows[0]["CANAL_SEFAZ"].ToString();
                        txtEtaFoxconn.Text = dtAereo.Rows[0]["ETA_FOXCONN"].ToString();
                        txtRemark.Text = dtAereo.Rows[0]["REMARK"].ToString();
                        txtDataEnvio.Text = dtAereo.Rows[0]["DATA_ENVIO"].ToString();
                        //
                        txtQuantidade.Text = dtAereo.Rows[0]["QUANTIDADE"].ToString();
                        //txtQuantidade.Attributes["value"] = txtQuantidade.Text;
                        //
                        cboFornecedor.SelectedValue = dtAereo.Rows[0]["FORNECEDOR"].ToString();
                        cboLocal.SelectedValue = dtAereo.Rows[0]["LOCAL"].ToString();
                        cboMoeda.SelectedValue = dtAereo.Rows[0]["MOEDA"].ToString();
                        cboIcoterm.SelectedValue = dtAereo.Rows[0]["ICOTERM"].ToString();
                        cboForwarder.SelectedValue = dtAereo.Rows[0]["FORWARDER"].ToString();
                        cboRecinto.SelectedValue = dtAereo.Rows[0]["RECINTO"].ToString();
                        cboDespachante.SelectedValue = dtAereo.Rows[0]["DESPACHANTE"].ToString();
                        txtLiberacao.Text = dtAereo.Rows[0]["LIBERACAO"].ToString();
                        txtEmbarque.Text = dtAereo.Rows[0]["EMBARQUE"].ToString();
                        cboCliente.SelectedValue = dtAereo.Rows[0]["CLIENTE"].ToString();

                        #endregion
                    }
                }
            }
        }

        public void ComboFornecedor()
        {
            Dados lista = new Dados();
            //
            cboFornecedor.DataSource = lista.ListaFornecedor();
            cboFornecedor.DataTextField = "NOME";
            cboFornecedor.DataValueField = "ID";
            cboFornecedor.DataBind();
            cboFornecedor.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboLocal()
        {
            Dados lista = new Dados();
            //
            cboLocal.DataSource = lista.ListaLocal();
            cboLocal.DataTextField = "NOME";
            cboLocal.DataValueField = "ID";
            cboLocal.DataBind();
            cboLocal.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

        }

        public void ComboMoeda()
        {
            Dados lista = new Dados();
            //
            cboMoeda.DataSource = lista.ListaMoeda();
            cboMoeda.DataTextField = "NOME";
            cboMoeda.DataValueField = "ID";
            cboMoeda.DataBind();
            cboMoeda.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

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

        public void ComboForwarder()
        {
            Dados lista = new Dados();
            //
            cboForwarder.DataSource = lista.ListaForwarder();
            cboForwarder.DataTextField = "NOME";
            cboForwarder.DataValueField = "ID";
            cboForwarder.DataBind();
            cboForwarder.Items.Insert(0, new ListItem("[Selecione]", string.Empty));

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

        public void ComboCanalSefaz()
        {
            cboCanalSEFAZ.Items.Insert(0, new ListItem("[Selecione]", string.Empty));
            cboCanalSEFAZ.Items.Insert(1, new ListItem("VERDE", "VERDE"));
            cboCanalSEFAZ.Items.Insert(2, new ListItem("VERMELHO", "VERMELHO"));
            cboCanalSEFAZ.Items.Insert(3, new ListItem("AMARELO", "AMARELO"));
            cboCanalSEFAZ.Items.Insert(4, new ListItem("CINZA", "CINZA"));
        }

        public void ComboCanalRF()
        {
            cboCanalRF.Items.Insert(0, new ListItem("[Selecione]", string.Empty));
            cboCanalRF.Items.Insert(1, new ListItem("VERDE", "VERDE"));
            cboCanalRF.Items.Insert(2, new ListItem("VERMELHO", "VERMELHO"));
            cboCanalRF.Items.Insert(3, new ListItem("AMARELO", "AMARELO"));
            cboCanalRF.Items.Insert(4, new ListItem("CINZA", "CINZA"));
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("aereo.aspx");
            Response.RedirectToRoute("aereo");
        }

        private bool ExisteCampoVazio()
        {
            if (txtPwce.Text.Equals(string.Empty) || txtInvoice.Text.Equals(string.Empty) || txtValorFOB.Text.Equals(string.Empty) ||
                txtRemark.Text.Equals(string.Empty) || txtQuantidade.Text.Equals(string.Empty) || cboModelo.SelectedValue.ToString().Equals(string.Empty) ||
                cboFornecedor.SelectedValue.ToString().Equals(string.Empty) || cboLocal.SelectedValue.ToString().Equals(string.Empty) ||
                cboMoeda.SelectedValue.ToString().Equals(string.Empty) || cboIcoterm.SelectedValue.ToString().Equals(string.Empty) ||
                cboForwarder.SelectedValue.ToString().Equals(string.Empty) || cboRecinto.SelectedValue.ToString().Equals(string.Empty) ||
                cboDespachante.SelectedValue.ToString().Equals(string.Empty)
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
                    //if ((RegularExpressionValidatorDataDI.IsValid) && (RegularExpressionValidatorDataEnvio.IsValid) && (RegularExpressionValidatorNumero.IsValid))
                    if (Page.IsValid)
                    {
                        #region UPDATE

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        //
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
                            string packlist = string.IsNullOrEmpty(txtPackList.Text) ? "null" : " '" + txtPackList.Text.Trim() + "'";
                            string pedido = string.IsNullOrEmpty(txtPedido.Text) ? "null" : " '" + txtPedido.Text.Trim() + "'";
                            string invoice = txtInvoice.Text.Trim();
                            string material = string.IsNullOrEmpty(txtMaterial.Text) ? "null" : " '" + txtMaterial.Text.Trim() + "'";
                            int liberado = string.IsNullOrEmpty(txtLiberacao.Text) ? 0 : 1;//chkLiberado.Checked ? 1 : 0;  //string.IsNullOrEmpty(txtLiberacao.Text) ? 0 : 1;//chkLiberado.Checked ? 1 : 0;
                            string valorFOB = txtValorFOB.Text;
                            string hawb = string.IsNullOrEmpty(txtHawb.Text) ? "null" : " '" + txtHawb.Text + "'";
                            string mawb = string.IsNullOrEmpty(txtMawb.Text) ? "null" : " '" + txtMawb.Text + "'";
                            string etdOrigin = string.IsNullOrEmpty(txtETDOrigin.Text) ? "null" : " '" + Convert.ToDateTime(txtETDOrigin.Text).ToString("yyyy-MM-dd") + "'";
                            string etdMia = string.IsNullOrEmpty(txtETDMia.Text) ? "null" : " '" + Convert.ToDateTime(txtETDMia.Text).ToString("yyyy-MM-dd") + "'";
                            string etaMao = string.IsNullOrEmpty(txtEtaMao.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaMao.Text).ToString("yyyy-MM-dd") + "'";
                            string di = string.IsNullOrEmpty(txtDI.Text) ? "null" : " '" + txtDI.Text + "'";
                            string dataDi = string.IsNullOrEmpty(txtDataDI.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDI.Text).ToString("yyyy-MM-dd") + "'";
                            string etaFoxconn = string.IsNullOrEmpty(txtEtaFoxconn.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaFoxconn.Text).ToString("yyyy-MM-dd") + "'";
                            string remark = txtRemark.Text;
                            string dataEnvio = string.IsNullOrEmpty(txtDataEnvio.Text) ? "null" : " '" + Convert.ToDateTime(txtDataEnvio.Text).ToString("yyyy-MM-dd") + "'";
                            int quantidade = int.Parse(txtQuantidade.Text); //txtQuantidade.Attributes["value"].ToString();
                            string canalRF = string.IsNullOrEmpty(cboCanalRF.SelectedValue) ? "null" : " '" + cboCanalRF.SelectedValue + "'";
                            string canalSEFAZ = string.IsNullOrEmpty(cboCanalSEFAZ.SelectedValue) ? "null" : " '" + cboCanalSEFAZ.SelectedValue + "'";
                            int fornecedor = int.Parse(cboFornecedor.SelectedValue);
                            int local = int.Parse(cboLocal.SelectedValue);
                            int moeda = int.Parse(cboMoeda.SelectedValue);
                            int icoterm = int.Parse(cboIcoterm.SelectedValue);
                            int forwarder = int.Parse(cboForwarder.SelectedValue);
                            int recinto = int.Parse(cboRecinto.SelectedValue);
                            int despachante = int.Parse(cboDespachante.SelectedValue);
                            string liberacao = string.IsNullOrEmpty(txtLiberacao.Text) ? "null" : " '" + Convert.ToDateTime(txtLiberacao.Text).ToString("yyyy-MM-dd") + "'";
                            string embarque = string.IsNullOrEmpty(txtEmbarque.Text) ? "null" : " '" + txtEmbarque.Text + "'";
                            int cliente = int.Parse(cboCliente.SelectedValue);
                            int modelo = int.Parse(cboModelo.SelectedValue);
                            //
                            string Sql = string.Format(@"UPDATE importacao.air_shipment  SET 
                                                                               pwce              =  {0},
                                                                               packlist          =  {1},
                                                                               pedido            =  {2},
                                                                               invoice           = '{3}',
                                                                               material          =  {4},                                                                   
                                                                               liberado          =  {5},
                                                                               vlr_fob           = '{6}',
                                                                               hawb              = {7},
                                                                               mawb              = {8},
                                                                               etd_origin        = {9},
                                                                               etd_mia           = {10},
                                                                               eta_mao           = {11},
                                                                               di                = {12},
                                                                               data_Di           = {13},
                                                                               eta_foxconn       = {14},
                                                                               remark            = '{15}',
                                                                               data_envio        = {16},
                                                                               quantidade        = '{17}',
                                                                               canal_rf          = {18},
                                                                               canal_sefaz       = {19},
                                                                               idfornecedor      = '{20}',
                                                                               idlocal           = '{21}',
                                                                               idmoeda           = '{22}',
                                                                               idicoterm         = '{23}',
                                                                               idforwarder       = '{24}',
                                                                               idrecinto         = '{25}',
                                                                               iddespachante     = '{26}',
                                                                               liberacao         =  {27},
                                                                               embarque          =  {28},
                                                                               idcliente         =  {29},
                                                                               idmodelo          =  {30},
                                                                               critico           =  {31}
                                                                         WHERE idair_shipment    =  {32}",
                                                                               pwce, packlist, pedido, invoice, material, liberado, valorFOB,
                                                                               hawb, mawb, etdOrigin, etdMia, etaMao, di, dataDi, etaFoxconn, remark,
                                                                               dataEnvio, quantidade, canalRF, canalSEFAZ, fornecedor, local, moeda, icoterm,
                                                                               forwarder, recinto, despachante, liberacao, embarque, cliente, modelo, critico, Id);
                            //
                            Objconn.SetarSQL(Sql);
                            Objconn.Executar();

                        }
                        finally
                        {
                            Objconn.Desconectar();
                        }
                        //
                        if (Objconn.Isvalid)
                        {
                            //Response.Redirect("aereo.aspx");
                            Response.RedirectToRoute("aereo");
                        }
                        else
                        {
                            lbAviso.Visible = true;
                            lbAviso.Text = "Erro::" + Objconn.Message;
                        }

                        #endregion
                    }
                }

            }
            else
            {
                if (!ExisteCampoVazio())
                {
                    //if ((RegularExpressionValidatorDataDI.IsValid) && (RegularExpressionValidatorDataEnvio.IsValid) && (RegularExpressionValidatorNumero.IsValid))
                    if (Page.IsValid)
                    {
                        #region INSERT

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        //
                        try
                        {
                            Objconn.Conectar();
                            Objconn.Parametros.Clear();
                            //
                            int critico = chkCritico.Checked.Equals(true) ? 1 : 0;
                            string pwce = string.IsNullOrEmpty(txtPwce.Text) ? "null" : " '" + txtPwce.Text.Trim() + "'";
                            string packlist = string.IsNullOrEmpty(txtPackList.Text) ? "null" : " '" + txtPackList.Text.Trim() + "'";
                            string pedido = string.IsNullOrEmpty(txtPedido.Text) ? "null" : " '" + txtPedido.Text.Trim() + "'";
                            string invoice = txtInvoice.Text.Trim();
                            string material = string.IsNullOrEmpty(txtMaterial.Text) ? "null" : " '" + txtMaterial.Text.Trim() + "'";
                            int liberado = string.IsNullOrEmpty(txtLiberacao.Text) ? 0 : 1;//string.IsNullOrEmpty(txtLiberacao.Text) ? 0 : 1;//chkLiberado.Checked ? 1 : 0;
                            string valorFOB = txtValorFOB.Text;
                            string hawb = string.IsNullOrEmpty(txtHawb.Text) ? "null" : " '" + txtHawb.Text + "'";
                            string mawb = string.IsNullOrEmpty(txtMawb.Text) ? "null" : " '" + txtMawb.Text + "'";
                            string etdOrigin = string.IsNullOrEmpty(txtETDOrigin.Text) ? "null" : " '" + Convert.ToDateTime(txtETDOrigin.Text).ToString("yyyy-MM-dd") + "'";
                            string etdMia = string.IsNullOrEmpty(txtETDMia.Text) ? "null" : " '" + Convert.ToDateTime(txtETDMia.Text).ToString("yyyy-MM-dd") + "'";
                            string etaMao = string.IsNullOrEmpty(txtEtaMao.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaMao.Text).ToString("yyyy-MM-dd") + "'";
                            string di = string.IsNullOrEmpty(txtDI.Text) ? "null" : " '" + txtDI.Text + "'";
                            string dataDi = string.IsNullOrEmpty(txtDataDI.Text) ? "null" : " '" + Convert.ToDateTime(txtDataDI.Text).ToString("yyyy-MM-dd") + "'";
                            string etaFoxconn = string.IsNullOrEmpty(txtEtaFoxconn.Text) ? "null" : " '" + Convert.ToDateTime(txtEtaFoxconn.Text).ToString("yyyy-MM-dd") + "'";
                            string remark = txtRemark.Text;
                            string dataEnvio = string.IsNullOrEmpty(txtDataEnvio.Text) ? "null" : " '" + Convert.ToDateTime(txtDataEnvio.Text).ToString("yyyy-MM-dd") + "'";
                            int quantidade = int.Parse(txtQuantidade.Text); //txtQuantidade.Attributes["value"].ToString();
                            string canalRF = string.IsNullOrEmpty(cboCanalRF.SelectedValue) ? "null" : " '" + cboCanalRF.SelectedValue + "'";
                            string canalSEFAZ = string.IsNullOrEmpty(cboCanalSEFAZ.SelectedValue) ? "null" : " '" + cboCanalSEFAZ.SelectedValue + "'";
                            int fornecedor = int.Parse(cboFornecedor.SelectedValue);
                            int local = int.Parse(cboLocal.SelectedValue);
                            int moeda = int.Parse(cboMoeda.SelectedValue);
                            int icoterm = int.Parse(cboIcoterm.SelectedValue);
                            int forwarder = int.Parse(cboForwarder.SelectedValue);
                            int recinto = int.Parse(cboRecinto.SelectedValue);
                            int despachante = int.Parse(cboDespachante.SelectedValue);
                            string liberacao = string.IsNullOrEmpty(txtLiberacao.Text) ? "null" : " '" + Convert.ToDateTime(txtLiberacao.Text).ToString("yyyy-MM-dd") + "'";
                            string embarque = string.IsNullOrEmpty(txtEmbarque.Text) ? "null" : " '" + txtEmbarque.Text + "'";
                            int cliente = int.Parse(cboCliente.SelectedValue);
                            int modelo = int.Parse(cboModelo.SelectedValue);
                            //
                            string Sql = string.Format(@"INSERT INTO importacao.air_shipment (
                                                                             pwce,
                                                                             packlist,
                                                                             pedido,
                                                                             invoice,
                                                                             material,                                                                   
                                                                             liberado,
                                                                             vlr_fob,
                                                                             hawb,
                                                                             mawb,
                                                                             etd_origin,
                                                                             etd_mia,
                                                                             eta_mao,
                                                                             di,
                                                                             data_Di,
                                                                             eta_foxconn,
                                                                             remark,
                                                                             data_envio,
                                                                             quantidade,
                                                                             canal_rf,
                                                                             canal_sefaz,
                                                                             idfornecedor,
                                                                             idlocal,
                                                                             idmoeda,
                                                                             idicoterm,
                                                                             idforwarder,
                                                                             idrecinto,
                                                                             iddespachante,
                                                                             liberacao,
                                                                             embarque,
                                                                             idcliente,
                                                                             idmodelo,
                                                                             critico)
                                                                      VALUES
                                                                            ({0},{1},{2},'{3}',{4},{5},'{6}',{7},{8},{9},{10},{11},{12},{13},{14},'{15}',{16},'{17}',{18},{19},{20},'{21}','{22}','{23}','{24}','{25}','{26}',{27},{28},{29},{30},{31})",
                                                                             pwce, packlist, pedido, invoice, material, liberado, valorFOB, hawb, mawb, etdOrigin, etdMia, etaMao, di, dataDi, etaFoxconn, remark, dataEnvio, quantidade, canalRF, canalSEFAZ,
                                                                             fornecedor, local, moeda, icoterm, forwarder, recinto, despachante, liberacao, embarque, cliente, modelo, critico);

                            //
                            Objconn.SetarSQL(Sql);
                            Objconn.Executar();
                        }
                        finally
                        {
                            Objconn.Desconectar();
                        }
                        //
                        if (Objconn.Isvalid)
                        {
                            //Response.Redirect("aereo.aspx");
                            Response.RedirectToRoute("aereo");
                        }
                        else
                        {
                            lbAviso.Visible = true;
                            lbAviso.Text = "Erro::" + Objconn.Message;
                        }

                        #endregion
                    }
                }
            }
        }

        protected void btnFormulario_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int IdAir_shipiment = 0;
                Int32.TryParse(Request.QueryString["id"], out IdAir_shipiment);
                Response.RedirectToRoute("formularioAereo", new { id = IdAir_shipiment });

            }
            else
            {
                Response.RedirectToRoute("formularioAereo");
            }
        }

    }
}