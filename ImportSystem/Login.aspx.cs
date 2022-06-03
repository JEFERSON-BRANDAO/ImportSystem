using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Drawing;

namespace ImportSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = "0";
                //
                try
                {
                    Id = Session["id"].ToString();
                }
                catch (Exception)
                {
                    Session["id"] = "0";
                    //Response.Redirect("Login.aspx");
                    Response.RedirectToRoute("default");
                }
            }

            //
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                Session["id"] = "0";
            IniciaSessao();

        }

        protected void IniciaSessao()
        {
            try
            {
                string id = "0";
                id = Session["id"].ToString();
                if (id == "0")
                {
                }
            }
            catch (Exception msgERRO)
            {
                Session["id"] = "0";
                lbAvisoLogar.InnerText = msgERRO.Message; //mostra erro de excessao
                lbAvisoLogar.Visible = true;
            }

        }

        protected void btLogar_Click(object sender, EventArgs e)
        {
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
                    string sql = string.Format(@"SELECT idusuario AS ID,
                                               login AS USUARIO, 
                                               senha AS SENHA,
                                               status
                                       FROM importacao.usuario   
                                       WHERE login = '{0}' AND senha = '{1}'", nome_login.Value.Trim().ToLower(), senha.Value.Trim());
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //

                }
                catch (Exception erro)
                {
                    lbAvisoLogar.Visible = true;
                    lbAvisoLogar.InnerText = "Erro: " + erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            //
            if (Objconn.Tabela.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(Objconn.Tabela.Rows[0][0]);
                Session["id"] = Id;
                status = string.IsNullOrEmpty(Objconn.Tabela.Rows[0]["status"].ToString()) ? "0" : Objconn.Tabela.Rows[0]["status"].ToString();
                //
                if (status.Equals("1"))
                {
                    //Response.Redirect("Default.aspx");
                    Response.RedirectToRoute("default");
                }
                else
                {
                    lbAvisoLogar.Visible = true;
                    lbAvisoLogar.InnerText = "Usuário desativado.";
                }
            }
            else
            {
                lbAvisoLogar.Visible = true;
                lbAvisoLogar.InnerText = "Usuário ou senha inválido.";
            }

        }
    }
}