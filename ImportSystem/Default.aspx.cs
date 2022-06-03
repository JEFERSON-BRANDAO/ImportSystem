using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace ImportSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkSair.HRef = "Logout";

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
                #region SAUDAÇÃO

                int anoCriacao = 2019;
                int anoAtual = DateTime.Now.Year;
                string texto = anoCriacao == anoAtual ? " Foxconn FBRLA All Rights Reserved." : "-" + anoAtual + " Foxconn FBRLA All Rights Reserved.";
                //
                lbRodape.Text = "Copyright © " + anoCriacao + texto + " v1.0.0.2";

                string saudacao = "";

                if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour <= 11)
                {
                    saudacao = "Bom dia, ";
                }
                else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
                {
                    saudacao = "Boa tarde, ";
                }
                else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
                {
                    saudacao = "Boa noite, ";

                }
                //
                lbUsuario.Text = saudacao + " " + getUsuarioLogado();
                //Session["UsuarioLogado"] = lbUsuario.Text;
                Session["RodaPe"] = lbRodape.Text;

                #endregion

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

    }
}