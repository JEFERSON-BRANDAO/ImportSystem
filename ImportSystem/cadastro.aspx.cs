using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;
using System.Text.RegularExpressions;

namespace ImportSystem
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            if (!Page.IsPostBack)
            {
                #region SAUDAÇÃO

                lbUsuario.Text = getUsuarioLogado();//(string)Session["UsuarioLogado"];
                lbRodape.Text = (string)Session["RodaPe"];

                #endregion
                //
                this.VinculaMenu();
                //
                ControleAcesso acesso = new ControleAcesso();
                string tipoUsuario = acesso.Permissao(Id);

                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                {
                    //solucao temporaria para controle
                    if (tipoUsuario != "ADMINISTRADOR")
                    {
                        PanelUsuario.Enabled = false;
                        panelArmador.Enabled = false;
                        panelDespachante.Enabled = false;
                        panelExportador.Enabled = false;
                        panelFornecedor.Enabled = false;
                        panelForwarder.Enabled = false;
                        panelIco_term.Enabled = false;
                        panelLocal.Enabled = false;
                        panelModelo.Enabled = false;
                        panelMoeda.Enabled = false;
                        panelRecinto.Enabled = false;
                        panelSuframa.Enabled = false;
                        panelTranspLocal.Enabled = false;

                    }
                    else
                    {
                        PanelUsuario.Enabled = true;
                        panelArmador.Enabled = true;
                        panelDespachante.Enabled = true;
                        panelExportador.Enabled = true;
                        panelFornecedor.Enabled = true;
                        panelForwarder.Enabled = true;
                        panelIco_term.Enabled = true;
                        panelLocal.Enabled = true;
                        panelModelo.Enabled = true;
                        panelMoeda.Enabled = true;
                        panelRecinto.Enabled = true;
                        panelSuframa.Enabled = true;
                        panelTranspLocal.Enabled = true;
                    }


                    #region PANELS

                    tv1.ExpandDepth = 1;//deixa treeview extendido
                    //
                    if (Request.QueryString["p"] == "usuario")
                    {
                        PanelVazio.Visible = false;
                        //panel usuário
                        PanelUsuario.Visible = true;
                        Usuario();

                    }

                    //
                    if (Request.QueryString["p"] == "fornecedor")
                    {
                        PanelVazio.Visible = false;
                        //panel fornecedor
                        panelFornecedor.Visible = true;
                        Fornecedor();

                    }

                    if (Request.QueryString["p"] == "local")
                    {
                        PanelVazio.Visible = false;
                        //panel local
                        panelLocal.Visible = true;
                        Local();

                    }

                    if (Request.QueryString["p"] == "modelo")
                    {
                        PanelVazio.Visible = false;
                        //panel modelo
                        panelModelo.Visible = true;
                        Modelo();

                    }

                    if (Request.QueryString["p"] == "exportador")
                    {
                        PanelVazio.Visible = false;
                        //panel exportador
                        panelExportador.Visible = true;
                        Exportador();

                    }

                    if (Request.QueryString["p"] == "despachante")
                    {
                        PanelVazio.Visible = false;
                        //panel despachante
                        panelDespachante.Visible = true;
                        Despachante();

                    }

                    if (Request.QueryString["p"] == "forwarder")
                    {
                        PanelVazio.Visible = false;
                        //panel forwarder
                        panelForwarder.Visible = true;
                        ForWarder();

                    }

                    if (Request.QueryString["p"] == "transporte")
                    {
                        PanelVazio.Visible = false;
                        //panel transporte local
                        panelTranspLocal.Visible = true;
                        TranpLocal();

                    }

                    if (Request.QueryString["p"] == "recinto")
                    {
                        PanelVazio.Visible = false;
                        //panel recinto
                        panelRecinto.Visible = true;
                        Recinto();

                    }

                    if (Request.QueryString["p"] == "moeda")
                    {
                        PanelVazio.Visible = false;
                        //panel moeda
                        panelMoeda.Visible = true;
                        Moeda();

                    }

                    if (Request.QueryString["p"] == "suframa")
                    {
                        PanelVazio.Visible = false;
                        //panel produto suframa
                        panelSuframa.Visible = true;
                        Suframa();

                    }

                    if (Request.QueryString["p"] == "ico_term")
                    {
                        PanelVazio.Visible = false;
                        //panel ico term
                        panelIco_term.Visible = true;
                        IcoTerm();

                    }

                    if (Request.QueryString["p"] == "armador")
                    {
                        PanelVazio.Visible = false;
                        //panel armador
                        panelArmador.Visible = true;
                        Armador();

                    }

                    #endregion
                }
                else
                {
                    PanelVazio.Visible = true;
                }
            }

        }

        protected string getUsuarioLogado()
        {
            int Id = 0;

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
            MySQLDbConnect Objconn = new MySQLDbConnect();

            Objconn.Conectar();
            Objconn.Parametros.Clear();
            string sql = string.Format("select login AS LOGIN from importacao.usuario WHERE idusuario = {0}", Id);
            Objconn.SetarSQL(sql);
            Objconn.Executar();
            Objconn.Desconectar();
            //
            if (Objconn.Tabela.Rows.Count > 0)
            {
                return Objconn.Tabela.Rows[0]["LOGIN"].ToString();
            }
            //
            Session["id"] = 0;
            //Response.Redirect("Login.aspx");
            Response.RedirectToRoute("login");
            return "Não Logado.";

        }

        public void VinculaMenu()
        {
            foreach (Classes.Menu m in Classes.Menu.GetMenu())
            {
                TreeNode menu = new TreeNode(m.Descricao);
                foreach (SubMenu s in SubMenu.GetSubMenu())
                {
                    if (m.MenuId == s.MenuId)
                    {
                        TreeNode sub = new TreeNode(s.Descricao, "", "", s.URL, "");
                        menu.ChildNodes.Add(sub);
                    }
                }
                //
                tv1.Nodes.Add(menu);
            }
        }

        #region USUARIO

        public void Usuario()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaUsuario().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaUsuario();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridUsuario.DataSource = Session["refresh"];
                GridUsuario.DataBind();
                //
                List<Dados.Usuario> dadosLista = new List<Dados.Usuario>();
                dadosLista = ((List<Dados.Usuario>)Session["refresh"]);
                //
                for (int linha = 0; linha < dadosLista.Count; linha++)
                {
                    for (int i = 0; i < GridUsuario.Rows.Count; i++)
                    {
                        if (((Label)GridUsuario.Rows[i].Cells[0].FindControl("lbId")).Text == dadosLista[linha].id)
                        {
                            ((CheckBox)GridUsuario.Rows[i].Cells[4].FindControl("chkAtivo")).Checked = Convert.ToBoolean(dadosLista[linha].status);
                            ((CheckBox)GridUsuario.Rows[i].Cells[5].FindControl("chkAdministrador")).Checked = Convert.ToBoolean(dadosLista[linha].tipo);
                        }

                        //para valor no textbox da senha nao ser perdido
                        ((TextBox)GridUsuario.Rows[i].Cells[0].FindControl("txtSenha")).Attributes["value"] = ((TextBox)GridUsuario.Rows[i].Cells[0].FindControl("txtSenha")).Text;
                        // txtSenha.Attributes["value"] = txtSenha.Text;
                    }
                }

            }
            else
            {
                GridUsuario.DataSource = null;
                GridUsuario.DataBind();
            }

        }

        protected void GridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUsuario.PageIndex = e.NewPageIndex;
            //
            GridUsuario.DataSource = Session["refresh"];
            GridUsuario.DataBind();
            //
            List<Dados.Usuario> dadosLista = new List<Dados.Usuario>();
            dadosLista = ((List<Dados.Usuario>)Session["refresh"]);
            //
            for (int linha = 0; linha < dadosLista.Count; linha++)
            {
                for (int i = 0; i < GridUsuario.Rows.Count; i++)
                {
                    if (((Label)GridUsuario.Rows[i].Cells[0].FindControl("lbId")).Text == dadosLista[linha].id)
                    {
                        ((CheckBox)GridUsuario.Rows[i].Cells[4].FindControl("chkAtivo")).Checked = Convert.ToBoolean(dadosLista[linha].status);
                        ((CheckBox)GridUsuario.Rows[i].Cells[5].FindControl("chkAdministrador")).Checked = Convert.ToBoolean(dadosLista[linha].tipo);
                    }

                    //para valor no textbox da senha nao ser perdido
                    ((TextBox)GridUsuario.Rows[i].Cells[0].FindControl("txtSenha")).Attributes["value"] = ((TextBox)GridUsuario.Rows[i].Cells[0].FindControl("txtSenha")).Text;
                    // txtSenha.Attributes["value"] = txtSenha.Text;
                }
            }

        }

        protected void btnUsuarioSalvar_Click(object sender, EventArgs e)
        {
            //verifica se email é válido
            if (!RegularExpressionValidatorEmail.IsValid)
            {
                return;
            }
            //string teste = "removendo espaços        de uma string                   ";
            //teste = Regex.Replace(teste, @"\s", "");
            //Regex regex = new Regex(@"\s{2,}");//expressao regular 
            //string login = regex.Replace(txtLogin.Text, string.Empty).ToLower();//txtLogin.Text.ToLower().Trim();

            string login = Regex.Replace(txtLogin.Text, @"\s", "").ToLower();//txtLogin.Text.ToLower().Trim();
            string senha = Regex.Replace(txtSenha.Text, @"\s", "");//txtSenha.Text.Trim();
            string email = Regex.Replace(txtEMail.Text, @"\s", "").ToLower();//txtEMail.Text.ToLower().Trim();
            int status = chkAtivo.Checked ? 1 : 0;
            string tipoUsuario = chkAdministrador.Checked ? "ADMINISTRADOR" : "USUARIO";

            //Verifica campo vázio
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                return;
            }

            //verifica se login já existe
            Existe existe = new Existe();
            if (existe.Usuario(login).Equals("true"))
            {
                lbUsuarioAviso.Visible = true;
                lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                lbUsuarioAviso.Text = "Erro:: Login já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.usuario (login, senha, email, status, tipo)
                                                    VALUES('" + login + "','" + senha + "','" + email + "','" + status + "','" + tipoUsuario + "' )";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Usuario();//refresh no grid

                        //limpa os campos
                        txtLogin.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        txtEMail.Text = string.Empty;

                        lbUsuarioAviso.Visible = true;
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Blue;
                        lbUsuarioAviso.Text = "Usuário criado com sucesso!";
                    }
                    else
                    {
                        lbUsuarioAviso.Visible = true;
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                        lbUsuarioAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbUsuarioAviso.Visible = true;
                    lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                    lbUsuarioAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnUsuarioCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idUsuario = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.usuario WHERE idusuario = " + idUsuario;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Usuario();//refresh no grid
                        lbUsuarioAviso.Text = "Usuário deletado com sucesso!";
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Blue;
                        lbUsuarioAviso.Visible = true;
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Item removido com sucesso.');", true);

                    }
                    else
                    {
                        lbUsuarioAviso.Text = "ERRO: " + Objconn.Message;
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                        lbUsuarioAviso.Visible = true;
                    }
                }
                catch (Exception erro)
                {
                    lbUsuarioAviso.Visible = true;
                    lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                    lbUsuarioAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        //ImageButton b = (ImageButton)e.CommandSource;
                        //b.CommandArgument = ((GridViewRow)sender).RowIndex.ToString(); 

                        //int rowCount = ((List<Dados.Usuario>)Session["refresh"]).Count;
                        //List<Dados.Usuario> dadosLista = new List<Dados.Usuario>();
                        //dadosLista = ((List<Dados.Usuario>)Session["refresh"]);
                        //                      

                        //int index = Convert.ToInt32(e.CommandArgument);//indice da linha
                        //comentado porque não funciona com paginação ao nevegar
                        //string id = GridUsuario.DataKeys[index]["id"].ToString();//id definido como dataKeys

                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idUsuario = string.Empty;
                        string login = string.Empty;
                        string senha = string.Empty;
                        string email = string.Empty;
                        int status = 1;
                        string tipoUsuario = "USUARIO";
                        //                       
                        for (int i = 0; i < GridUsuario.Rows.Count; i++)
                        {
                            idUsuario = ((Label)GridUsuario.Rows[i].Cells[0].FindControl("lbId")).Text;

                            //
                            if (id_ == idUsuario)
                            {
                                //string teste = "removendo espaços        de uma string                   ";
                                //teste = Regex.Replace(teste, @"\s", "");

                                //Regex regex = new Regex(@"\s{2,}");//expressao regular 
                                //string login = regex.Replace(txtLogin.Text, string.Empty).ToLower();
                                //string b = ((ImageButton)GridUsuario.Rows[i].Cells[5].FindControl("btnEditar")).CommandArgument.ToString();
                                //login = regex.Replace(((TextBox)GridUsuario.Rows[i].Cells[1].FindControl("txtUsuario")).Text, string.Empty).ToLower();  //((TextBox)GridUsuario.Rows[i].Cells[1].FindControl("txtUsuario")).Text.Trim().ToLower();

                                login = Regex.Replace(((TextBox)GridUsuario.Rows[i].Cells[1].FindControl("txtUsuario")).Text, @"\s", "").ToLower();
                                senha = Regex.Replace(((TextBox)GridUsuario.Rows[i].Cells[2].FindControl("txtSenha")).Text, @"\s", "");   //((TextBox)GridUsuario.Rows[i].Cells[2].FindControl("txtSenha")).Text;
                                email = Regex.Replace(((TextBox)GridUsuario.Rows[i].Cells[3].FindControl("txtEmail")).Text, @"\s", "").ToLower();   //((TextBox)GridUsuario.Rows[i].Cells[3].FindControl("txtEmail")).Text.Trim().ToLower();
                                status = Convert.ToInt32(((CheckBox)GridUsuario.Rows[i].Cells[4].FindControl("chkAtivo")).Checked);//GridUsuario.Rows[i].Cells[4].Text == "SIM" ? 1 : 0;
                                tipoUsuario = ((CheckBox)GridUsuario.Rows[i].Cells[5].FindControl("chkAdministrador")).Checked.Equals(true) ? "ADMINISTRADOR" : "USUARIO";
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();

                        string Sql = string.Format(@"UPDATE importacao.usuario SET 
                                                             login   ='{0}',
                                                             senha   ='{1}',
                                                             email   ='{2}',
                                                             status  ='{3}',
                                                             Tipo    ='{4}'
                                                            WHERE idusuario = {5}", login, senha, email, status, tipoUsuario, idUsuario);

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Usuario();//refresh no grid
                        lbUsuarioAviso.Text = "Alteração realizada com sucesso!";
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Blue;
                        lbUsuarioAviso.Visible = true;

                    }
                    else
                    {
                        lbUsuarioAviso.Text = "ERRO: " + Objconn.Message;
                        lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                        lbUsuarioAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbUsuarioAviso.Visible = true;
                    lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                    lbUsuarioAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region FORNECEDOR

        public void Fornecedor()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaFornecedor().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaFornecedor();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridFornecedor.DataSource = Session["refresh"];
                GridFornecedor.DataBind();
            }
            else
            {
                GridFornecedor.DataSource = null;
                GridFornecedor.DataBind();
            }

        }

        protected void GridFornecedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFornecedor.PageIndex = e.NewPageIndex;
            //
            GridFornecedor.DataSource = Session["refresh"];
            GridFornecedor.DataBind();
        }

        protected void btnFornecedorSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtFornecedor.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se fornecedor já existe
            Existe existe = new Existe();
            if (existe.Fornecedor(nome).Equals("true"))
            {
                lbUsuarioAviso.Visible = true;
                lbUsuarioAviso.ForeColor = System.Drawing.Color.Red;
                lbUsuarioAviso.Text = "Erro:: Fornecedor já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.fornecedor  (nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Fornecedor();//refresh no grid

                        //limpa os campos
                        txtFornecedor.Text = string.Empty;
                        //
                        lbFornecedorAviso.Visible = true;
                        lbFornecedorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbFornecedorAviso.Text = "Fornecedor cadastrado com sucesso!";
                    }
                    else
                    {
                        lbFornecedorAviso.Visible = true;
                        lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                        lbFornecedorAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbFornecedorAviso.Visible = true;
                    lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                    lbFornecedorAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnFornecedorCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idFornecedor = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.fornecedor WHERE idfornecedor = " + idFornecedor;
                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Fornecedor();//refresh no grid
                            lbFornecedorAviso.Text = "Fornecedor deletado com sucesso!";
                            lbFornecedorAviso.ForeColor = System.Drawing.Color.Blue;
                            lbFornecedorAviso.Visible = true;

                        }
                        else
                        {
                            lbFornecedorAviso.Text = "ERRO: " + Objconn.Message;
                            lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                            lbFornecedorAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbFornecedorAviso.Visible = true;
                        lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                        lbFornecedorAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Fornecedor> dadosLista = new List<Dados.Fornecedor>();
                        dadosLista = ((List<Dados.Fornecedor>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idFornecedor = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridFornecedor.Rows.Count; i++)
                        {
                            idFornecedor = ((Label)GridFornecedor.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idFornecedor)
                            {
                                nome = ((TextBox)GridFornecedor.Rows[i].Cells[1].FindControl("txtFornecedor")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.fornecedor SET nome  ='" + nome + "'" +
                                             "WHERE idfornecedor = " + idFornecedor;

                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Fornecedor();//refresh no grid
                            lbFornecedorAviso.Text = "Alteração realizada com sucesso!";
                            lbFornecedorAviso.ForeColor = System.Drawing.Color.Blue;
                            lbFornecedorAviso.Visible = true;

                        }
                        else
                        {
                            lbFornecedorAviso.Text = "ERRO: " + Objconn.Message;
                            lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                            lbFornecedorAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbFornecedorAviso.Visible = true;
                        lbFornecedorAviso.ForeColor = System.Drawing.Color.Red;
                        lbFornecedorAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
        }

        #endregion
        //
        #region LOCAL

        public void Local()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaLocal().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaLocal();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridLocal.DataSource = Session["refresh"];
                GridLocal.DataBind();
            }
            else
            {
                GridLocal.DataSource = null;
                GridLocal.DataBind();
            }

        }

        protected void GridLocal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLocal.PageIndex = e.NewPageIndex;
            //
            GridLocal.DataSource = Session["refresh"];
            GridLocal.DataBind();
        }

        protected void btnLocalSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtLocal.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se local já existe
            Existe existe = new Existe();
            if (existe.Local(nome).Equals("true"))
            {
                lbLocalAviso.Visible = true;
                lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                lbLocalAviso.Text = "Erro:: Local já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.local(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Local();//refresh no grid

                        //limpa os campos
                        txtLocal.Text = string.Empty;
                        //
                        lbLocalAviso.Visible = true;
                        lbLocalAviso.ForeColor = System.Drawing.Color.Blue;
                        lbLocalAviso.Text = "Local cadastrado com sucesso!";
                    }
                    else
                    {
                        lbLocalAviso.Visible = true;
                        lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbLocalAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbLocalAviso.Visible = true;
                    lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                    lbLocalAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnLocalCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridLocal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idLocal = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.local WHERE idlocal = " + idLocal;
                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Local();//refresh no grid
                            lbLocalAviso.Text = "Local deletado com sucesso!";
                            lbLocalAviso.ForeColor = System.Drawing.Color.Blue;
                            lbLocalAviso.Visible = true;

                        }
                        else
                        {
                            lbLocalAviso.Text = "ERRO: " + Objconn.Message;
                            lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                            lbLocalAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbLocalAviso.Visible = true;
                        lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbLocalAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Local> dadosLista = new List<Dados.Local>();
                        dadosLista = ((List<Dados.Local>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idLocal = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridLocal.Rows.Count; i++)
                        {
                            idLocal = ((Label)GridLocal.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idLocal)
                            {
                                nome = ((TextBox)GridLocal.Rows[i].Cells[1].FindControl("txtLocal")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.local SET nome  ='" + nome + "'" +
                                             "WHERE idlocal = " + idLocal;

                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Local();//refresh no grid
                            lbLocalAviso.Text = "Alteração realizada com sucesso!";
                            lbLocalAviso.ForeColor = System.Drawing.Color.Blue;
                            lbLocalAviso.Visible = true;

                        }
                        else
                        {
                            lbLocalAviso.Text = "ERRO: " + Objconn.Message;
                            lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                            lbLocalAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbLocalAviso.Visible = true;
                        lbLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbLocalAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
        }

        #endregion
        //
        #region MODELO

        public void Modelo()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaModelo().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaModelo();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridModelo.DataSource = Session["refresh"];
                GridModelo.DataBind();
            }
            else
            {
                GridModelo.DataSource = null;
                GridModelo.DataBind();
            }

        }

        protected void GridModelo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridModelo.PageIndex = e.NewPageIndex;
            //
            GridModelo.DataSource = Session["refresh"];
            GridModelo.DataBind();
        }

        protected void btnModeloSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtModelo.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se modelo já existe
            Existe existe = new Existe();
            if (existe.Modelo(nome).Equals("true"))
            {
                lbModeloAviso.Visible = true;
                lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                lbModeloAviso.Text = "Erro:: Modelo já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.modelo(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Modelo();//refresh no grid

                        //limpa os campos
                        txtModelo.Text = string.Empty;
                        //
                        lbModeloAviso.Visible = true;
                        lbModeloAviso.ForeColor = System.Drawing.Color.Blue;
                        lbModeloAviso.Text = "Modelo cadastrado com sucesso!";
                    }
                    else
                    {
                        lbModeloAviso.Visible = true;
                        lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                        lbModeloAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbModeloAviso.Visible = true;
                    lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                    lbModeloAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnModeloCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridModelo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idModelo = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.modelo WHERE idmodelo = " + idModelo;
                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Modelo();//refresh no grid
                            lbModeloAviso.Text = "Modelo deletado com sucesso!";
                            lbModeloAviso.ForeColor = System.Drawing.Color.Blue;
                            lbModeloAviso.Visible = true;

                        }
                        else
                        {
                            lbModeloAviso.Text = "ERRO: " + Objconn.Message;
                            lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                            lbModeloAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbModeloAviso.Visible = true;
                        lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                        lbModeloAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Modelo> dadosLista = new List<Dados.Modelo>();
                        dadosLista = ((List<Dados.Modelo>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idModelo = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridModelo.Rows.Count; i++)
                        {
                            idModelo = ((Label)GridModelo.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idModelo)
                            {
                                nome = ((TextBox)GridModelo.Rows[i].Cells[1].FindControl("txtModelo")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.modelo SET nome  ='" + nome + "'" +
                                             "WHERE idmodelo = " + idModelo;

                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Modelo();//refresh no grid
                            lbModeloAviso.Text = "Alteração realizada com sucesso!";
                            lbModeloAviso.ForeColor = System.Drawing.Color.Blue;
                            lbModeloAviso.Visible = true;

                        }
                        else
                        {
                            lbModeloAviso.Text = "ERRO: " + Objconn.Message;
                            lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                            lbModeloAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbModeloAviso.Visible = true;
                        lbModeloAviso.ForeColor = System.Drawing.Color.Red;
                        lbModeloAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
        }

        #endregion
        //
        #region EXPORTADOR

        public void Exportador()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaExportador().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaExportador();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridExportador.DataSource = Session["refresh"];
                GridExportador.DataBind();
            }
            else
            {
                GridExportador.DataSource = null;
                GridExportador.DataBind();
            }

        }

        protected void GridExportador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridExportador.PageIndex = e.NewPageIndex;
            //
            GridExportador.DataSource = Session["refresh"];
            GridExportador.DataBind();
        }

        protected void btnExportadorSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtExportador.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se exportador já existe
            Existe existe = new Existe();
            if (existe.Exportador(nome).Equals("true"))
            {
                lbExportadorAviso.Visible = true;
                lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                lbExportadorAviso.Text = "Erro:: Exportador já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.exportador(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Exportador();//refresh no grid

                        //limpa os campos
                        txtExportador.Text = string.Empty;
                        //
                        lbExportadorAviso.Visible = true;
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbExportadorAviso.Text = "Exportador cadastrado com sucesso!";
                    }
                    else
                    {
                        lbExportadorAviso.Visible = true;
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                        lbExportadorAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbExportadorAviso.Visible = true;
                    lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbExportadorAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnExportadorCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridExportador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idexportador = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.exportador WHERE idexportador = " + idexportador;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Exportador();//refresh no grid
                        lbExportadorAviso.Text = "Exportador deletado com sucesso!";
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbExportadorAviso.Visible = true;

                    }
                    else
                    {
                        lbExportadorAviso.Text = "ERRO: " + Objconn.Message;
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                        lbExportadorAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbExportadorAviso.Visible = true;
                    lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbExportadorAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Exportador> dadosLista = new List<Dados.Exportador>();
                        dadosLista = ((List<Dados.Exportador>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idExportador = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridExportador.Rows.Count; i++)
                        {
                            idExportador = ((Label)GridExportador.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idExportador)
                            {
                                nome = ((TextBox)GridExportador.Rows[i].Cells[1].FindControl("txtExportador")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.exportador SET nome  ='" + nome + "'" +
                                             "WHERE idexportador = " + idExportador;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Exportador();//refresh no grid
                        lbExportadorAviso.Text = "Alteração realizada com sucesso!";
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbExportadorAviso.Visible = true;

                    }
                    else
                    {
                        lbExportadorAviso.Text = "ERRO: " + Objconn.Message;
                        lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                        lbExportadorAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbExportadorAviso.Visible = true;
                    lbExportadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbExportadorAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region DESPACHANTE

        public void Despachante()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaDespachante().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaDespachante();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridDespachante.DataSource = Session["refresh"];
                GridDespachante.DataBind();
            }
            else
            {
                GridDespachante.DataSource = null;
                GridDespachante.DataBind();
            }

        }

        protected void GridDespachante_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDespachante.PageIndex = e.NewPageIndex;
            //
            GridDespachante.DataSource = Session["refresh"];
            GridDespachante.DataBind();
        }

        protected void btnDespachanteSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtDespachante.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se despachante já existe
            Existe existe = new Existe();
            if (existe.Despachante(nome).Equals("true"))
            {
                lbDespachanteAviso.Visible = true;
                lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                lbDespachanteAviso.Text = "Erro:: Despachante já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.despachante(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Despachante();//refresh no grid

                        //limpa os campos
                        txtDespachante.Text = string.Empty;
                        //
                        lbDespachanteAviso.Visible = true;
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Blue;
                        lbDespachanteAviso.Text = "Despachante cadastrado com sucesso!";
                    }
                    else
                    {
                        lbDespachanteAviso.Visible = true;
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                        lbDespachanteAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbDespachanteAviso.Visible = true;
                    lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                    lbDespachanteAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnDespachanteCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridDespachante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int iddespachante = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.despachante WHERE iddespachante = " + iddespachante;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Despachante();//refresh no grid
                        lbDespachanteAviso.Text = "Despachante deletado com sucesso!";
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Blue;
                        lbDespachanteAviso.Visible = true;

                    }
                    else
                    {
                        lbDespachanteAviso.Text = "ERRO: " + Objconn.Message;
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                        lbDespachanteAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbDespachanteAviso.Visible = true;
                    lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                    lbDespachanteAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Despachante> dadosLista = new List<Dados.Despachante>();
                        dadosLista = ((List<Dados.Despachante>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string iddespachante = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridDespachante.Rows.Count; i++)
                        {
                            iddespachante = ((Label)GridDespachante.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == iddespachante)
                            {
                                nome = ((TextBox)GridDespachante.Rows[i].Cells[1].FindControl("txtDespachante")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.despachante SET nome  ='" + nome + "'" +
                                             "WHERE iddespachante = " + iddespachante;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Despachante();//refresh no grid
                        lbDespachanteAviso.Text = "Alteração realizada com sucesso!";
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Blue;
                        lbDespachanteAviso.Visible = true;

                    }
                    else
                    {
                        lbDespachanteAviso.Text = "ERRO: " + Objconn.Message;
                        lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                        lbDespachanteAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbDespachanteAviso.Visible = true;
                    lbDespachanteAviso.ForeColor = System.Drawing.Color.Red;
                    lbDespachanteAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }


        #endregion
        //
        #region FORWARDER

        public void ForWarder()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaForwarder().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaForwarder();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridForwarder.DataSource = Session["refresh"];
                GridForwarder.DataBind();
            }
            else
            {
                GridForwarder.DataSource = null;
                GridForwarder.DataBind();
            }

        }

        protected void GridForwarder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridForwarder.PageIndex = e.NewPageIndex;
            //
            GridForwarder.DataSource = Session["refresh"];
            GridForwarder.DataBind();
        }

        protected void btnForwarderSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtForwarder.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se despachante já existe
            Existe existe = new Existe();
            if (existe.Forwarder(nome).Equals("true"))
            {
                lbForwarderAviso.Visible = true;
                lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                lbForwarderAviso.Text = "Erro:: Forwarder já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.forwarder(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        ForWarder();//refresh no grid

                        //limpa os campos
                        txtForwarder.Text = string.Empty;
                        //
                        lbForwarderAviso.Visible = true;
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Blue;
                        lbForwarderAviso.Text = "Forwarder cadastrado com sucesso!";
                    }
                    else
                    {
                        lbForwarderAviso.Visible = true;
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                        lbForwarderAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbForwarderAviso.Visible = true;
                    lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                    lbForwarderAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnForwarderCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridForwarder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idforwarder = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.forwarder WHERE idforwarder = " + idforwarder;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        ForWarder();//refresh no grid
                        lbForwarderAviso.Text = "Forwarder deletado com sucesso!";
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Blue;
                        lbForwarderAviso.Visible = true;

                    }
                    else
                    {
                        lbForwarderAviso.Text = "ERRO: " + Objconn.Message;
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                        lbForwarderAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbForwarderAviso.Visible = true;
                    lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                    lbForwarderAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Forwarder> dadosLista = new List<Dados.Forwarder>();
                        dadosLista = ((List<Dados.Forwarder>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idforwarder = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridForwarder.Rows.Count; i++)
                        {
                            idforwarder = ((Label)GridForwarder.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idforwarder)
                            {
                                nome = ((TextBox)GridForwarder.Rows[i].Cells[1].FindControl("txtForwarder")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.forwarder SET nome  ='" + nome + "'" +
                                             "WHERE idforwarder = " + idforwarder;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        ForWarder();//refresh no grid
                        lbForwarderAviso.Text = "Alteração realizada com sucesso!";
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Blue;
                        lbForwarderAviso.Visible = true;

                    }
                    else
                    {
                        lbForwarderAviso.Text = "ERRO: " + Objconn.Message;
                        lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                        lbForwarderAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbForwarderAviso.Visible = true;
                    lbForwarderAviso.ForeColor = System.Drawing.Color.Red;
                    lbForwarderAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region TRANSPORTE LOCAL

        public void TranpLocal()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaTranspLocal().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaTranspLocal();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridTranspLocal.DataSource = Session["refresh"];
                GridTranspLocal.DataBind();
            }
            else
            {
                GridTranspLocal.DataSource = null;
                GridTranspLocal.DataBind();
            }

        }

        protected void GridTranspLocal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTranspLocal.PageIndex = e.NewPageIndex;
            //
            GridTranspLocal.DataSource = Session["refresh"];
            GridTranspLocal.DataBind();
        }

        protected void btnTranspLocalSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtTranspLocal.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se transporte local já existe
            Existe existe = new Existe();
            if (existe.Tranp_local(nome).Equals("true"))
            {
                lbTranspLocalAviso.Visible = true;
                lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                lbTranspLocalAviso.Text = "Erro:: Tranporte local já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.transp_local(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        TranpLocal();//refresh no grid

                        //limpa os campos
                        txtTranspLocal.Text = string.Empty;
                        //
                        lbTranspLocalAviso.Visible = true;
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Blue;
                        lbTranspLocalAviso.Text = "Transporte local cadastrado com sucesso!";
                    }
                    else
                    {
                        lbTranspLocalAviso.Visible = true;
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbTranspLocalAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbTranspLocalAviso.Visible = true;
                    lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                    lbTranspLocalAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnTranspLocalCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridTranspLocal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idTranspLocal = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.transp_local WHERE idtransp_local = " + idTranspLocal;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Executar())
                    {
                        TranpLocal();//refresh no grid
                        lbTranspLocalAviso.Text = "Transporte Local deletado com sucesso!";
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Blue;
                        lbTranspLocalAviso.Visible = true;

                    }
                    else
                    {
                        lbTranspLocalAviso.Text = "ERRO: " + Objconn.Message;
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbTranspLocalAviso.Visible = true;
                    }


                }
                catch (Exception erro)
                {
                    lbTranspLocalAviso.Visible = true;
                    lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                    lbTranspLocalAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Transp_Local> dadosLista = new List<Dados.Transp_Local>();
                        dadosLista = ((List<Dados.Transp_Local>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idTransp_local = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridTranspLocal.Rows.Count; i++)
                        {
                            idTransp_local = ((Label)GridTranspLocal.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idTransp_local)
                            {
                                nome = ((TextBox)GridTranspLocal.Rows[i].Cells[1].FindControl("txtTranpLocal")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.transp_local SET nome  ='" + nome + "'" +
                                             "WHERE idtransp_local = " + idTransp_local;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        TranpLocal();//refresh no grid
                        lbTranspLocalAviso.Text = "Alteração realizada com sucesso!";
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Blue;
                        lbTranspLocalAviso.Visible = true;

                    }
                    else
                    {
                        lbTranspLocalAviso.Text = "ERRO: " + Objconn.Message;
                        lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                        lbTranspLocalAviso.Visible = true;
                    }


                }
                catch (Exception erro)
                {
                    lbTranspLocalAviso.Visible = true;
                    lbTranspLocalAviso.ForeColor = System.Drawing.Color.Red;
                    lbTranspLocalAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region RECINTO

        public void Recinto()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaRecinto().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaRecinto();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridRecinto.DataSource = Session["refresh"];
                GridRecinto.DataBind();
            }
            else
            {
                GridRecinto.DataSource = null;
                GridRecinto.DataBind();
            }

        }

        protected void btnRecintoSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtRecinto.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se transporte local já existe
            Existe existe = new Existe();
            if (existe.Recinto(nome).Equals("true"))
            {
                lbRecintoAviso.Visible = true;
                lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                lbRecintoAviso.Text = "Erro:: Recinto já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.recinto(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Recinto();//refresh no grid

                        //limpa os campos
                        txtRecinto.Text = string.Empty;
                        //
                        lbRecintoAviso.Visible = true;
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbRecintoAviso.Text = "Recinto cadastrado com sucesso!";
                    }
                    else
                    {
                        lbRecintoAviso.Visible = true;
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                        lbRecintoAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbRecintoAviso.Visible = true;
                    lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                    lbRecintoAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void GridRecinto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridRecinto.PageIndex = e.NewPageIndex;
            //
            GridRecinto.DataSource = Session["refresh"];
            GridRecinto.DataBind();
        }

        protected void btnRecintoCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridRecinto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idrecinto = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.recinto WHERE idrecinto = " + idrecinto;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Recinto();//refresh no grid
                        lbRecintoAviso.Text = "Recinto deletado com sucesso!";
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbRecintoAviso.Visible = true;

                    }
                    else
                    {
                        lbRecintoAviso.Text = "ERRO: " + Objconn.Message;
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                        lbRecintoAviso.Visible = true;
                    }


                }
                catch (Exception erro)
                {
                    lbRecintoAviso.Visible = true;
                    lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                    lbRecintoAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Recinto> dadosLista = new List<Dados.Recinto>();
                        dadosLista = ((List<Dados.Recinto>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idrecinto = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridRecinto.Rows.Count; i++)
                        {
                            idrecinto = ((Label)GridRecinto.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idrecinto)
                            {
                                nome = ((TextBox)GridRecinto.Rows[i].Cells[1].FindControl("txtRecinto")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.recinto SET nome  ='" + nome + "'" +
                                             "WHERE idrecinto = " + idrecinto;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Recinto();//refresh no grid
                        lbRecintoAviso.Text = "Alteração realizada com sucesso!";
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbRecintoAviso.Visible = true;

                    }
                    else
                    {
                        lbRecintoAviso.Text = "ERRO: " + Objconn.Message;
                        lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                        lbRecintoAviso.Visible = true;
                    }


                }
                catch (Exception erro)
                {
                    lbRecintoAviso.Visible = true;
                    lbRecintoAviso.ForeColor = System.Drawing.Color.Red;
                    lbRecintoAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region MOEDA

        public void Moeda()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaMoeda().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaMoeda();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridMoeda.DataSource = Session["refresh"];
                GridMoeda.DataBind();
            }
            else
            {
                GridMoeda.DataSource = null;
                GridMoeda.DataBind();
            }

        }

        protected void GridMoeda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMoeda.PageIndex = e.NewPageIndex;
            //
            GridMoeda.DataSource = Session["refresh"];
            GridMoeda.DataBind();
        }

        protected void btnMoedaSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtMoeda.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se transporte local já existe
            Existe existe = new Existe();
            if (existe.Moeda(nome).Equals("true"))
            {
                lbMoedaAviso.Visible = true;
                lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                lbMoedaAviso.Text = "Erro:: Moeda já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.moeda(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Moeda();//refresh no grid

                        //limpa os campos
                        txtMoeda.Text = string.Empty;
                        //
                        lbMoedaAviso.Visible = true;
                        lbMoedaAviso.ForeColor = System.Drawing.Color.Blue;
                        lbMoedaAviso.Text = "Moeda cadastrada com sucesso!";
                    }
                    else
                    {
                        lbMoedaAviso.Visible = true;
                        lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                        lbMoedaAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbMoedaAviso.Visible = true;
                    lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                    lbMoedaAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion

        }

        protected void btnMoedaCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridMoeda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idMoeda = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.moeda WHERE idmoeda = " + idMoeda;
                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Moeda();//refresh no grid
                            lbMoedaAviso.Text = "Moeda deletada com sucesso!";
                            lbMoedaAviso.ForeColor = System.Drawing.Color.Blue;
                            lbMoedaAviso.Visible = true;

                        }
                        else
                        {
                            lbMoedaAviso.Text = "ERRO: " + Objconn.Message;
                            lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                            lbMoedaAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbMoedaAviso.Visible = true;
                        lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                        lbMoedaAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Moeda> dadosLista = new List<Dados.Moeda>();
                        dadosLista = ((List<Dados.Moeda>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idMoeda = string.Empty;
                        string moeda = string.Empty;
                        //                       
                        for (int i = 0; i < GridMoeda.Rows.Count; i++)
                        {
                            idMoeda = ((Label)GridMoeda.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idMoeda)
                            {
                                moeda = ((TextBox)GridMoeda.Rows[i].Cells[1].FindControl("txtMoeda")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.moeda SET nome  ='" + moeda + "'" +
                                             "WHERE idmoeda = " + idMoeda;

                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            Moeda();//refresh no grid
                            lbMoedaAviso.Text = "Alteração realizada com sucesso!";
                            lbMoedaAviso.ForeColor = System.Drawing.Color.Blue;
                            lbMoedaAviso.Visible = true;

                        }
                        else
                        {
                            lbMoedaAviso.Text = "ERRO: " + Objconn.Message;
                            lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                            lbMoedaAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbMoedaAviso.Visible = true;
                        lbMoedaAviso.ForeColor = System.Drawing.Color.Red;
                        lbMoedaAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
        }

        #endregion
        //
        #region PRODUTO SUFRAMA

        public void Suframa()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaProduto().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaProduto();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridProduto.DataSource = Session["refresh"];
                GridProduto.DataBind();
            }
            else
            {
                GridProduto.DataSource = null;
                GridProduto.DataBind();
            }

        }

        protected void GridProduto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridProduto.PageIndex = e.NewPageIndex;
            //
            GridProduto.DataSource = Session["refresh"];
            GridProduto.DataBind();
        }

        protected void btnProdutoSalvar_Click(object sender, EventArgs e)
        {
            string produto = txtProduto.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(produto))
            {
                return;
            }

            //verifica se transporte local já existe
            Existe existe = new Existe();
            if (existe.Suframa(produto).Equals("true"))
            {
                lbProdutoAviso.Visible = true;
                lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                lbProdutoAviso.Text = "Erro:: Produto já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.suframa(produto)
                                                    VALUES('" + produto + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Suframa();//refresh no grid

                        //limpa os campos
                        txtProduto.Text = string.Empty;
                        //
                        lbProdutoAviso.Visible = true;
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbProdutoAviso.Text = "Produto cadastrado com sucesso!";
                    }
                    else
                    {
                        lbProdutoAviso.Visible = true;
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                        lbProdutoAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbProdutoAviso.Visible = true;
                    lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                    lbProdutoAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnProdutoCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridProduto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idsuframa = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.suframa WHERE idsuframa = " + idsuframa;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Suframa();//refresh no grid
                        lbProdutoAviso.Text = "Produto deletado com sucesso!";
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbProdutoAviso.Visible = true;

                    }
                    else
                    {
                        lbProdutoAviso.Text = "ERRO: " + Objconn.Message;
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                        lbProdutoAviso.Visible = true;
                    }


                }
                catch (Exception erro)
                {
                    lbProdutoAviso.Visible = true;
                    lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                    lbProdutoAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Suframa> dadosLista = new List<Dados.Suframa>();
                        dadosLista = ((List<Dados.Suframa>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idSuframa = string.Empty;
                        string produto = string.Empty;
                        //                       
                        for (int i = 0; i < GridProduto.Rows.Count; i++)
                        {
                            idSuframa = ((Label)GridProduto.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idSuframa)
                            {
                                produto = ((TextBox)GridProduto.Rows[i].Cells[1].FindControl("txtProduto")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.suframa SET produto  ='" + produto + "'" +
                                             "WHERE idsuframa = " + idSuframa;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Suframa();//refresh no grid
                        lbProdutoAviso.Text = "Alteração realizada com sucesso!";
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Blue;
                        lbProdutoAviso.Visible = true;

                    }
                    else
                    {
                        lbProdutoAviso.Text = "ERRO: " + Objconn.Message;
                        lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                        lbProdutoAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbProdutoAviso.Visible = true;
                    lbProdutoAviso.ForeColor = System.Drawing.Color.Red;
                    lbProdutoAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
        }

        #endregion
        //
        #region ICOTERM

        public void IcoTerm()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaIcoTerm().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaIcoTerm();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridIcoTerm.DataSource = Session["refresh"];
                GridIcoTerm.DataBind();
            }
            else
            {
                GridIcoTerm.DataSource = null;
                GridIcoTerm.DataBind();
            }

        }

        protected void GridIcoTerm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridIcoTerm.PageIndex = e.NewPageIndex;
            //
            GridIcoTerm.DataSource = Session["refresh"];
            GridIcoTerm.DataBind();
        }

        protected void btnIcoTermSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtIconTerm.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se ico term já existe
            Existe existe = new Existe();
            if (existe.Ico_Term(nome).Equals("true"))
            {
                lbIcoTermAviso.Visible = true;
                lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                lbIcoTermAviso.Text = "Erro:: Icoterm já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.icoterm(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        IcoTerm();//refresh no grid

                        //limpa os campos
                        txtIconTerm.Text = string.Empty;
                        //
                        lbIcoTermAviso.Visible = true;
                        lbIcoTermAviso.ForeColor = System.Drawing.Color.Blue;
                        lbIcoTermAviso.Text = "Icoterm cadastrado com sucesso!";
                    }
                    else
                    {
                        lbIcoTermAviso.Visible = true;
                        lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                        lbIcoTermAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbIcoTermAviso.Visible = true;
                    lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                    lbIcoTermAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnIcoTermCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridIcoTerm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idIcoTerm = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.icoterm WHERE idicoterm = " + idIcoTerm;
                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            IcoTerm();//refresh no grid
                            lbIcoTermAviso.Text = "Icoterm deletado com sucesso!";
                            lbIcoTermAviso.ForeColor = System.Drawing.Color.Blue;
                            lbIcoTermAviso.Visible = true;

                        }
                        else
                        {
                            lbIcoTermAviso.Text = "ERRO: " + Objconn.Message;
                            lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                            lbIcoTermAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbIcoTermAviso.Visible = true;
                        lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                        lbIcoTermAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Icoterm> dadosLista = new List<Dados.Icoterm>();
                        dadosLista = ((List<Dados.Icoterm>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idIcoTerm = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridIcoTerm.Rows.Count; i++)
                        {
                            idIcoTerm = ((Label)GridIcoTerm.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idIcoTerm)
                            {
                                nome = ((TextBox)GridIcoTerm.Rows[i].Cells[1].FindControl("txtIcoTerm")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.icoterm SET nome  ='" + nome + "'" +
                                             "WHERE idicoterm = " + idIcoTerm;

                        Objconn.SetarSQL(Sql);
                        //
                        if (Objconn.Executar())
                        {
                            IcoTerm();//refresh no grid
                            lbIcoTermAviso.Text = "Alteração realizada com sucesso!";
                            lbIcoTermAviso.ForeColor = System.Drawing.Color.Blue;
                            lbIcoTermAviso.Visible = true;

                        }
                        else
                        {
                            lbIcoTermAviso.Text = "ERRO: " + Objconn.Message;
                            lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                            lbIcoTermAviso.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        lbIcoTermAviso.Visible = true;
                        lbIcoTermAviso.ForeColor = System.Drawing.Color.Red;
                        lbIcoTermAviso.Text = "Erro::" + erro.Message;
                    }

                }
                finally
                {
                    Objconn.Desconectar();
                }

            }

            #endregion
        }

        #endregion
        //
        #region ARMADOR

        public void Armador()
        {
            Dados objDados = new Dados();
            int rowCount = objDados.ListaArmador().Count;
            //
            if (rowCount > 0)
            {
                Session["refresh"] = objDados.ListaArmador();
                //Session.Add("refresh", objDados.ListaUsuario());
                GridArmador.DataSource = Session["refresh"];
                GridArmador.DataBind();
            }
            else
            {
                GridArmador.DataSource = null;
                GridArmador.DataBind();
            }

        }

        protected void GridArmador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridArmador.PageIndex = e.NewPageIndex;
            //
            GridArmador.DataSource = Session["refresh"];
            GridArmador.DataBind();
        }

        protected void btnArmadorSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtArmador.Text;

            //Verifica campo vázio
            if (string.IsNullOrEmpty(nome))
            {
                return;
            }

            //verifica se armador já existe
            Existe existe = new Existe();
            if (existe.Armador(nome).Equals("true"))
            {
                lbArmadorAviso.Visible = true;
                lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                lbArmadorAviso.Text = "Erro:: Armador já existe";
                return;
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
                    string Sql = @"INSERT INTO importacao.armador(nome)
                                                    VALUES('" + nome + "')";
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        Armador();//refresh no grid

                        //limpa os campos
                        txtArmador.Text = string.Empty;
                        //
                        lbArmadorAviso.Visible = true;
                        lbArmadorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbArmadorAviso.Text = "Armador cadastrado com sucesso!";
                    }
                    else
                    {
                        lbArmadorAviso.Visible = true;
                        lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                        lbArmadorAviso.Text = "Erro::" + Objconn.Message;
                    }
                }
                catch (Exception erro)
                {
                    lbArmadorAviso.Visible = true;
                    lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbArmadorAviso.Text = "Erro::" + erro.Message;
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            #endregion
        }

        protected void btnAramadorCancelar_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Default.aspx");
            Response.RedirectToRoute("default");
        }

        protected void GridArmador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region REMOVE
            //
            if (e.CommandName == "remover")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        int idArmador = Convert.ToInt32(e.CommandArgument);
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = "DELETE FROM importacao.armador WHERE idarmador = " + idArmador;
                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }

                    if (Objconn.Isvalid)
                    {
                        Armador();//refresh no grid
                        lbArmadorAviso.Text = "Armador deletado com sucesso!";
                        lbArmadorAviso.ForeColor = System.Drawing.Color.Blue;
                        lbArmadorAviso.Visible = true;

                    }
                    else
                    {
                        lbArmadorAviso.Text = "ERRO: " + Objconn.Message;
                        lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                        lbArmadorAviso.Visible = true;
                    }

                }
                catch (Exception erro)
                {
                    lbArmadorAviso.Visible = true;
                    lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbArmadorAviso.Text = "Erro::" + erro.Message;
                }

            }

            #endregion
            //
            #region EDITA
            //
            if (e.CommandName == "editar")
            {
                MySQLDbConnect Objconn = new MySQLDbConnect();
                //
                try
                {
                    try
                    {
                        List<Dados.Armador> dadosLista = new List<Dados.Armador>();
                        dadosLista = ((List<Dados.Armador>)Session["refresh"]);
                        //                      
                        string id_ = e.CommandArgument.ToString();//id selecionado
                        string idArmador = string.Empty;
                        string nome = string.Empty;
                        //                       
                        for (int i = 0; i < GridArmador.Rows.Count; i++)
                        {
                            idArmador = ((Label)GridArmador.Rows[i].Cells[0].FindControl("lbId")).Text;
                            //
                            if (id_ == idArmador)
                            {
                                nome = ((TextBox)GridArmador.Rows[i].Cells[1].FindControl("txtArmador")).Text;
                                break;
                            }
                        }
                        //                   
                        Objconn.Conectar();
                        Objconn.Parametros.Clear();
                        //
                        string Sql = @"UPDATE importacao.armador SET nome  ='" + nome + "'" +
                                             "WHERE idarmador = " + idArmador;

                        Objconn.SetarSQL(Sql);
                        //
                        Objconn.Executar();

                    }
                    finally
                    {
                        Objconn.Desconectar();
                    }


                }
                catch (Exception erro)
                {
                    lbArmadorAviso.Visible = true;
                    lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbArmadorAviso.Text = "Erro::" + erro.Message;
                }

                if (Objconn.Isvalid)
                {
                    Armador();//refresh no grid
                    lbArmadorAviso.Text = "Alteração realizada com sucesso!";
                    lbArmadorAviso.ForeColor = System.Drawing.Color.Blue;
                    lbArmadorAviso.Visible = true;

                }
                else
                {
                    lbArmadorAviso.Text = "ERRO: " + Objconn.Message;
                    lbArmadorAviso.ForeColor = System.Drawing.Color.Red;
                    lbArmadorAviso.Visible = true;
                }

            }

            #endregion
        }

        #endregion

    }
}