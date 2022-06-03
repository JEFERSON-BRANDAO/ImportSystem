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
    public partial class demurrage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAviso.Visible = false;

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

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int IdSea_shipiment = 0;
                    Int32.TryParse(Request.QueryString["id"], out IdSea_shipiment);
                    TimeSpan diferenca;
                    //
                    Dados dados = new Dados();
                    int rowCount = dados.ListaDemurrage(IdSea_shipiment).Count;
                    if (rowCount > 0)
                    {
                        #region PREENCHE OS CAMPOS

                        rowCount = dados.ListaMaritimo(IdSea_shipiment).Count;
                        if (rowCount > 0)
                        {
                            DataTable dtMaritimo = dados.ListaMaritimo(IdSea_shipiment)[0];
                            //
                            string Eta_MAO = dtMaritimo.Rows[0]["ETA_MAO"].ToString();

                            if (!string.IsNullOrEmpty(Eta_MAO))
                            {
                                txtEta_MAO.Text = Eta_MAO;
                                txtETA_Foxconn.Text = dtMaritimo.Rows[0]["ETA_FOXCONN"].ToString();
                                txtDtIdealDevolucao.Text = Convert.ToDateTime(Eta_MAO).AddDays(int.Parse(ConfigurationManager.AppSettings["DevolucaoIdeal"].ToString())).ToString("dd/MM/yyyy");
                                txtVencDemurrage.Text = Convert.ToDateTime(Eta_MAO).AddDays(int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString())).ToString("dd/MM/yyyy");
                                diferenca = DateTime.Parse(txtVencDemurrage.Text).Subtract(DateTime.Now.Date);
                                lbContagem.Text = diferenca.TotalDays > 0 ? "Resta(m) " + diferenca.TotalDays + " dia(s) para o vencimento da Demurrage" : "Demurrage vencida";
                                //
                                diferenca = (DateTime.Now.Date).Subtract(DateTime.Parse(Eta_MAO));
                                txtQtdDiaria.Text = diferenca.TotalDays.ToString();
                            }

                            string Eta_FOXCONN = dtMaritimo.Rows[0]["ETA_FOXCONN"].ToString();
                            txtETA_Foxconn.Text = Eta_FOXCONN;
                            if (string.IsNullOrEmpty(Eta_FOXCONN))
                            {
                                lbDiaria.Text = "-";
                            }
                            else
                            {
                                diferenca = DateTime.Now.Date.Subtract(DateTime.Parse(Eta_FOXCONN).AddDays(1));
                                lbDiaria.Text = "Total diárias de prancha após  24h  de free time está em: " + diferenca.TotalDays.ToString() + " dia(s).";
                            }

                            Registrar("AUTO");//registra demurrage para poder enviar avio por email sobre vencimento
                        }

                        //
                        DataTable dtDemurrage = dados.ListaDemurrage(IdSea_shipiment)[0];
                        txtOrigem.Text = dtDemurrage.Rows[0]["ORIGEM"].ToString();
                        txtDestino.Text = dtDemurrage.Rows[0]["DESTINO"].ToString();
                        //
                        txtSolRetirada.Text = string.IsNullOrEmpty(dtDemurrage.Rows[0]["SOL_RETIRADA"].ToString()) ? string.Empty : Convert.ToDateTime(dtDemurrage.Rows[0]["SOL_RETIRADA"].ToString()).ToString("dd/MM/yyyy");
                        txtEntregaDepot.Text = string.IsNullOrEmpty(dtDemurrage.Rows[0]["ENTREGA_DEPOT"].ToString()) ? string.Empty : Convert.ToDateTime(dtDemurrage.Rows[0]["ENTREGA_DEPOT"].ToString()).ToString("dd/MM/yyyy");
                        //txtQtdDiaria.Text = dtDemurrage.Rows[0]["QTD_DIARIA"].ToString();

                        #endregion
                    }
                    else
                    {
                        rowCount = dados.ListaMaritimo(IdSea_shipiment).Count;
                        if (rowCount > 0)
                        {

                            DataTable dtMaritimo = dados.ListaMaritimo(IdSea_shipiment)[0];
                            //
                            string Eta_MAO = dtMaritimo.Rows[0]["ETA_MAO"].ToString();

                            if (!string.IsNullOrEmpty(Eta_MAO))
                            {
                                txtEta_MAO.Text = Eta_MAO;
                                txtDtIdealDevolucao.Text = Convert.ToDateTime(Eta_MAO).AddDays(int.Parse(ConfigurationManager.AppSettings["DevolucaoIdeal"].ToString())).ToString("dd/MM/yyyy");

                                txtVencDemurrage.Text = Convert.ToDateTime(Eta_MAO).AddDays(int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString())).ToString("dd/MM/yyyy");
                                diferenca = DateTime.Parse(txtVencDemurrage.Text).Subtract(DateTime.Now.Date);
                                lbContagem.Text = diferenca.TotalDays > 0 ? "Resta(m) " + diferenca.TotalDays + " dia(s) para o vencimento da Demurrage" : "Demurrage vencida";

                                diferenca = (DateTime.Now.Date).Subtract(DateTime.Parse(Eta_MAO));
                                txtQtdDiaria.Text = diferenca.TotalDays.ToString();
                            }
                            //
                            string Eta_FOXCONN = dtMaritimo.Rows[0]["ETA_FOXCONN"].ToString();
                            txtETA_Foxconn.Text = Eta_FOXCONN;
                            if (string.IsNullOrEmpty(Eta_FOXCONN))
                            {
                                lbDiaria.Text = "-";
                            }
                            else
                            {
                                diferenca = DateTime.Parse(Eta_FOXCONN).AddDays(1).Subtract(DateTime.Now.Date);
                                lbDiaria.Text = "Total diárias de prancha após  24h  de free time está em: " + diferenca.TotalDays.ToString() + " dia(s).";
                            }

                            Registrar("AUTO");//registra demurrage para poder enviar avio por email sobre vencimento

                        }
                        else
                        {
                            //Response.Redirect("maritimo.aspx");
                            Response.RedirectToRoute("maritimo");
                        }
                    }
                }
                else
                {
                    //Response.Redirect("maritimo.aspx");
                    Response.RedirectToRoute("maritimo");
                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("maritimo.aspx");
            Response.RedirectToRoute("maritimo");
        }

        public bool ExisteDemurrage(string Id)
        {
            int rowCount = 0;
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string sql = string.Format(@"SELECT COUNT(b.IDDEMURRAGE) rowCount FROM  importacao.sea_shipment a
                                   INNER JOIN importacao.demurrage b ON a.IDDEMURRAGE = b.IDDEMURRAGE
                                   WHERE a.IDSEA_SHIPMENT ={0} ", Id);
                //
                Objconn.SetarSQL(sql);
                Objconn.Executar();
                //
                rowCount = Objconn.Tabela.Rows.Count;
                if (rowCount > 0)
                {
                    rowCount = int.Parse(Objconn.Tabela.Rows[0]["rowCount"].ToString());
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return rowCount > 0 ? true : false;
        }

        public void Registrar(string registro)
        {
            if (registro == "AUTO")
            {
                if (ExisteDemurrage(Request.QueryString["id"]))
                {
                    #region UPDATE

                    MySQLDbConnect Objconn = new MySQLDbConnect();
                    string status = string.Empty;
                    //
                    try
                    {
                        try
                        {
                            Objconn.Conectar();
                            Objconn.Parametros.Clear();
                            //
                            int IDSEA_SHIPMENT = 0;
                            Int32.TryParse(Request.QueryString["id"], out IDSEA_SHIPMENT);
                            //
                            string origem = string.IsNullOrEmpty(txtOrigem.Text) ? "null" : "'" + txtOrigem.Text + "'";
                            string destino = string.IsNullOrEmpty(txtDestino.Text) ? "null" : "'" + txtDestino.Text + "'";
                            string dataIdealDevo = string.IsNullOrEmpty(txtDtIdealDevolucao.Text) ? "null" : "'" + Convert.ToDateTime(txtDtIdealDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                            string vencDemurrage = string.IsNullOrEmpty(txtVencDemurrage.Text) ? "null" : "'" + Convert.ToDateTime(txtVencDemurrage.Text).ToString("yyyy-MM-dd") + "'";
                            string solRetirada = string.IsNullOrEmpty(txtSolRetirada.Text) ? "null" : "'" + Convert.ToDateTime(txtSolRetirada.Text).ToString("yyyy-MM-dd") + "'";
                            string entregaDepot = string.IsNullOrEmpty(txtEntregaDepot.Text) ? "null" : "'" + Convert.ToDateTime(txtEntregaDepot.Text).ToString("yyyy-MM-dd") + "'";
                            int qtdDiaria = string.IsNullOrEmpty(txtQtdDiaria.Text) ? 0 : int.Parse(txtQtdDiaria.Text);
                            //
                            //                            string Sql = @"UPDATE importacao.demurrage SET origem         = " + origem + @",
                            //                                                                           destino        = " + destino + @", 
                            //                                                                           data_ideal_dev = " + dataIdealDevo + @",    
                            //                                                                           vencimento     = " + vencDemurrage + @",                                                                
                            //                                                                           sol_retirada   = " + solRetirada + @",
                            //                                                                           entrega_depot  = " + entregaDepot + @",
                            //                                                                           qtd_diaria     = " + qtdDiaria + @"                                                                             
                            //                                                                     WHERE iddemurrage IN (SELECT IDDEMURRAGE FROM  importacao.sea_shipment WHERE IDSEA_SHIPMENT=" + IDSEA_SHIPMENT + ")";
                            string Sql = string.Format(@"UPDATE importacao.demurrage SET origem = {0},
                                                                                 destino        = {1}, 
                                                                                 data_ideal_dev = {2},    
                                                                                 vencimento     = {3},                                                                
                                                                                 sol_retirada   = {4},
                                                                                 entrega_depot  = {5},
                                                                                 qtd_diaria     = {6}                                                                             
                                                                     WHERE iddemurrage IN (SELECT IDDEMURRAGE FROM  importacao.sea_shipment WHERE IDSEA_SHIPMENT={7})", origem, destino, dataIdealDevo, vencDemurrage, solRetirada, entregaDepot, qtdDiaria, IDSEA_SHIPMENT);
                            //                            
                            Objconn.SetarSQL(Sql);
                            Objconn.Executar();


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

                    //
                    if (Objconn.Isvalid)
                    {
                        status = "OK";
                    }

                    //
                    if (status != "OK")
                    {
                        lbAviso.Visible = true;
                        lbAviso.Text = "Erro::" + Objconn.Message;
                    }

                    #endregion
                }
                else
                {
                    #region INSERT

                    MySQLDbConnect Objconn = new MySQLDbConnect();
                    string status = string.Empty;
                    //
                    try
                    {
                        try
                        {
                            Objconn.Conectar();
                            Objconn.Parametros.Clear();
                            // 
                            string origem = string.IsNullOrEmpty(txtOrigem.Text) ? "null" : "'" + txtOrigem.Text + "'";
                            string destino = string.IsNullOrEmpty(txtDestino.Text) ? "null" : "'" + txtDestino.Text + "'";
                            string dataIdealDevo = string.IsNullOrEmpty(txtDtIdealDevolucao.Text) ? "null" : "'" + Convert.ToDateTime(txtDtIdealDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                            string vencDemurrage = string.IsNullOrEmpty(txtVencDemurrage.Text) ? "null" : "'" + Convert.ToDateTime(txtVencDemurrage.Text).ToString("yyyy-MM-dd") + "'";
                            string solRetirada = string.IsNullOrEmpty(txtSolRetirada.Text) ? "null" : "'" + Convert.ToDateTime(txtSolRetirada.Text).ToString("yyyy-MM-dd") + "'";
                            string entregaDepot = string.IsNullOrEmpty(txtEntregaDepot.Text) ? "null" : "'" + Convert.ToDateTime(txtEntregaDepot.Text).ToString("yyyy-MM-dd") + "'";
                            int qtdDiaria = string.IsNullOrEmpty(txtQtdDiaria.Text) ? 0 : int.Parse(txtQtdDiaria.Text);
                            int contagem_dias = int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString());
                            //
                            //                            string Sql = @"INSERT INTO importacao.demurrage (origem,
                            //                                                                             destino,                                                 
                            //                                                                             data_ideal_dev,
                            //                                                                             vencimento,
                            //                                                                             sol_retirada,
                            //                                                                             entrega_depot,
                            //                                                                             qtd_diaria,
                            //                                                                             contagem_dias)
                            //                                                                       VALUES
                            //                                                                             (" + origem + ","
                            //                                                                                 + destino + ","
                            //                                                                                 + dataIdealDevo + ","
                            //                                                                                 + vencDemurrage + ","
                            //                                                                                 + solRetirada + ","
                            //                                                                                 + entregaDepot + ","
                            //                                                                                 + qtdDiaria + ","
                            //                                                                                 + contagem_dias + ");Select @@Identity;";

                            string Sql = string.Format(@"INSERT INTO importacao.demurrage
                                                                            (origem,
                                                                             destino,                                                 
                                                                             data_ideal_dev,
                                                                             vencimento,
                                                                             sol_retirada,
                                                                             entrega_depot,
                                                                             qtd_diaria,
                                                                             contagem_dias)
                                                                       VALUES
                                                                             ({0},
                                                                              {1},
                                                                              {2},
                                                                              {3},
                                                                              {4},
                                                                              {5},
                                                                              {6},
                                                                              {7});Select @@Identity;", origem, destino, dataIdealDevo, vencDemurrage, solRetirada, entregaDepot, qtdDiaria, contagem_dias);

                            //
                            Objconn.SetarSQL(Sql);
                            Objconn.Executar();


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

                    //
                    if (Objconn.Isvalid)
                    {
                        status = "OK";
                    }

                    //
                    if (status == "OK")
                    {
                        status = string.Empty;

                        try
                        {
                            try
                            {
                                int IDSEA_SHIPMENT = 0;
                                Int32.TryParse(Request.QueryString["id"], out IDSEA_SHIPMENT);
                                string IDDEMURRAGE = Objconn.Tabela.Rows[0][0].ToString();
                                //
                                Objconn.Conectar();
                                Objconn.Parametros.Clear();
                                //
                                string Sql = string.Format("UPDATE importacao.sea_shipment SET IDDEMURRAGE ='{0}' WHERE IDSEA_SHIPMENT ={1}", IDDEMURRAGE, IDSEA_SHIPMENT);
                                Objconn.SetarSQL(Sql);
                                Objconn.Executar();
                                //
                                if (Objconn.Isvalid)
                                {
                                    status = "OK";
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

                        //
                        if (status != "OK")
                        {
                            lbAviso.Visible = true;
                            lbAviso.Text = "Erro::" + Objconn.Message;
                        }

                    }
                    else
                    {
                        lbAviso.Visible = true;
                        lbAviso.Text = "Erro::" + Objconn.Message;
                    }

                    #endregion
                }

            }
            else
            {
                if (Page.IsValid)
                {
                    if (ExisteDemurrage(Request.QueryString["id"]))
                    {
                        #region UPDATE

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        string status = string.Empty;
                        //
                        try
                        {
                            try
                            {
                                Objconn.Conectar();
                                Objconn.Parametros.Clear();
                                //
                                int IDSEA_SHIPMENT = 0;
                                Int32.TryParse(Request.QueryString["id"], out IDSEA_SHIPMENT);
                                //
                                string origem = string.IsNullOrEmpty(txtOrigem.Text) ? "null" : "'" + txtOrigem.Text + "'";
                                string destino = string.IsNullOrEmpty(txtDestino.Text) ? "null" : "'" + txtDestino.Text + "'";
                                string dataIdealDevo = string.IsNullOrEmpty(txtDtIdealDevolucao.Text) ? "null" : "'" + Convert.ToDateTime(txtDtIdealDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                                string vencDemurrage = string.IsNullOrEmpty(txtVencDemurrage.Text) ? "null" : "'" + Convert.ToDateTime(txtVencDemurrage.Text).ToString("yyyy-MM-dd") + "'";
                                string solRetirada = string.IsNullOrEmpty(txtSolRetirada.Text) ? "null" : "'" + Convert.ToDateTime(txtSolRetirada.Text).ToString("yyyy-MM-dd") + "'";
                                string entregaDepot = string.IsNullOrEmpty(txtEntregaDepot.Text) ? "null" : "'" + Convert.ToDateTime(txtEntregaDepot.Text).ToString("yyyy-MM-dd") + "'";
                                int qtdDiaria = string.IsNullOrEmpty(txtEntregaDepot.Text) ? 0 : int.Parse(txtQtdDiaria.Text);
                                //
                                //                                string Sql = @"UPDATE importacao.demurrage SET origem         = " + origem + @",
                                //                                                                           destino        = " + destino + @", 
                                //                                                                           data_ideal_dev = " + dataIdealDevo + @",    
                                //                                                                           vencimento     = " + vencDemurrage + @",                                                                
                                //                                                                           sol_retirada   = " + solRetirada + @",
                                //                                                                           entrega_depot  = " + entregaDepot + @",
                                //                                                                           qtd_diaria     = " + qtdDiaria + @"                                                                             
                                //                                                                     WHERE iddemurrage IN (SELECT IDDEMURRAGE FROM  importacao.sea_shipment WHERE IDSEA_SHIPMENT=" + IDSEA_SHIPMENT + ")";
                                //                                
                                string Sql = string.Format(@"UPDATE importacao.demurrage SET origem = {0},
                                                                                 destino        = {1}, 
                                                                                 data_ideal_dev = {2},    
                                                                                 vencimento     = {3},                                                                
                                                                                 sol_retirada   = {4},
                                                                                 entrega_depot  = {5},
                                                                                 qtd_diaria     = {6}                                                                             
                                                                     WHERE iddemurrage IN (SELECT IDDEMURRAGE FROM  importacao.sea_shipment WHERE IDSEA_SHIPMENT={7})", origem, destino, dataIdealDevo, vencDemurrage, solRetirada, entregaDepot, qtdDiaria, IDSEA_SHIPMENT);

                                Objconn.SetarSQL(Sql);
                                Objconn.Executar();


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

                        //
                        if (Objconn.Isvalid)
                        {
                            status = "OK";
                        }

                        //
                        if (status == "OK")
                        {
                            //Response.Redirect("maritimo.aspx");
                            Response.RedirectToRoute("maritimo");
                        }
                        else
                        {
                            lbAviso.Visible = true;
                            lbAviso.Text = "Erro::" + Objconn.Message;
                        }

                        #endregion
                    }
                    else
                    {
                        #region INSERT

                        MySQLDbConnect Objconn = new MySQLDbConnect();
                        string status = string.Empty;
                        //
                        try
                        {
                            try
                            {
                                Objconn.Conectar();
                                Objconn.Parametros.Clear();
                                // 
                                string origem = string.IsNullOrEmpty(txtOrigem.Text) ? "null" : "'" + txtOrigem.Text + "'";
                                string destino = string.IsNullOrEmpty(txtDestino.Text) ? "null" : "'" + txtDestino.Text + "'";
                                string dataIdealDevo = string.IsNullOrEmpty(txtDtIdealDevolucao.Text) ? "null" : "'" + Convert.ToDateTime(txtDtIdealDevolucao.Text).ToString("yyyy-MM-dd") + "'";
                                string vencDemurrage = string.IsNullOrEmpty(txtVencDemurrage.Text) ? "null" : "'" + Convert.ToDateTime(txtVencDemurrage.Text).ToString("yyyy-MM-dd") + "'";
                                string solRetirada = string.IsNullOrEmpty(txtSolRetirada.Text) ? "null" : "'" + Convert.ToDateTime(txtSolRetirada.Text).ToString("yyyy-MM-dd") + "'";
                                string entregaDepot = string.IsNullOrEmpty(txtEntregaDepot.Text) ? "null" : "'" + Convert.ToDateTime(txtEntregaDepot.Text).ToString("yyyy-MM-dd") + "'";
                                int qtdDiaria = string.IsNullOrEmpty(txtEntregaDepot.Text) ? 0 : int.Parse(txtQtdDiaria.Text);
                                int contagem_dias = int.Parse(ConfigurationManager.AppSettings["VencimentoDemurrage"].ToString());
                                //
                                //                                string Sql = @"INSERT INTO importacao.demurrage (origem,
                                //                                                                             destino,                                                 
                                //                                                                             data_ideal_dev,
                                //                                                                             vencimento,
                                //                                                                             sol_retirada,
                                //                                                                             entrega_depot,
                                //                                                                             qtd_diaria,
                                //                                                                             contagem_dias)
                                //                                                                       VALUES
                                //                                                                             (" + origem + ","
                                //                                                                                     + destino + ","
                                //                                                                                     + dataIdealDevo + ","
                                //                                                                                     + vencDemurrage + ","
                                //                                                                                     + solRetirada + ","
                                //                                                                                     + entregaDepot + ","
                                //                                                                                     + qtdDiaria + ","
                                //                                                                                     + contagem_dias + ");Select @@Identity;";
                                string Sql = string.Format(@"INSERT INTO importacao.demurrage
                                                                            (origem,
                                                                             destino,                                                 
                                                                             data_ideal_dev,
                                                                             vencimento,
                                                                             sol_retirada,
                                                                             entrega_depot,
                                                                             qtd_diaria,
                                                                             contagem_dias)
                                                                       VALUES
                                                                             ({0},
                                                                              {1},
                                                                              {2},
                                                                              {3},
                                                                              {4},
                                                                              {5},
                                                                              {6},
                                                                              {7});Select @@Identity;", origem, destino, dataIdealDevo, vencDemurrage, solRetirada, entregaDepot, qtdDiaria, contagem_dias);


                                //
                                Objconn.SetarSQL(Sql);
                                Objconn.Executar();


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

                        //
                        if (Objconn.Isvalid)
                        {
                            status = "OK";
                        }

                        //
                        if (status == "OK")
                        {
                            status = string.Empty;

                            try
                            {
                                try
                                {
                                    int IDSEA_SHIPMENT = 0;
                                    Int32.TryParse(Request.QueryString["id"], out IDSEA_SHIPMENT);
                                    string IDDEMURRAGE = Objconn.Tabela.Rows[0][0].ToString();
                                    //
                                    Objconn.Conectar();
                                    Objconn.Parametros.Clear();
                                    //
                                    string Sql = "UPDATE importacao.sea_shipment SET IDDEMURRAGE ='" + IDDEMURRAGE + "' WHERE IDSEA_SHIPMENT =" + IDSEA_SHIPMENT;
                                    Objconn.SetarSQL(Sql);
                                    Objconn.Executar();
                                    //
                                    if (Objconn.Isvalid)
                                    {
                                        status = "OK";
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

                            //
                            if (status == "OK")
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Registrar(string.Empty);
        }
    }
}