using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
// ===============================
// AUTHOR       : JEFFERSON BRANDÃO DA COSTA - ANALISTA/PROGRAMADOR
// CREATE DATE  : 24/09/2019
// DESCRIPTION  : Sistema controle de Importação
// SPECIAL NOTES:
// ===============================
// Change History: Add informaçoes para FBRLA
// Date: 25/05/2021
//==================================

namespace ImportSystem
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkSair.HRef = "Logout";

            Response.Cache.SetCacheability(HttpCacheability.NoCache);//limpa cache das paginas     

            //int anoCriacao = 2019;
            //int anoAtual = DateTime.Now.Year;
            //string texto = anoCriacao == anoAtual ? " Foxconn FBRLA All Rights Reserved." : "-" + anoAtual + " Foxconn FBRLA All Rights Reserved.";
            //
            // lbRodape.Text = "Copyright © " + anoCriacao + texto + " v1.0.0.2";

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
            //
            if (!IsPostBack)
            {
                // lbData.Text = DateTime.Now.ToString("D");

            }
            //
            MontarMenu();

        }

        public void MontarMenu()
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
            //
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

        protected bool UsuarioLogado()
        {
            string Id = "0";

            try
            {
                Id = Session["id"].ToString();
            }
            catch (Exception)
            {
                Session["id"] = "0";
                //Response.Redirect("Login.aspx");
                Response.RedirectToRoute("login");
            }

            //verifica se usuario está logado
            if (Id == "1")
            {
                return true;
            }
            else
            {
                Session["id"] = "0";
                //Response.Redirect("Login.aspx");
                Response.RedirectToRoute("login");
                return false;
            }

        }
    }
}
