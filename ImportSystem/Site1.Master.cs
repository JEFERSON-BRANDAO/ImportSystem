using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImportSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);//limpa cache das paginas 
           
            int anoCriacao = 2016;
            int anoAtual = DateTime.Now.Year;
            string texto = anoCriacao == anoAtual ? " Foxconn FBRLA All Rights Reserved." : "-" + anoAtual + " Foxconn FBRLA All Rights Reserved.";
            //
            //lblRodape.Text = "Copyright © " + anoCriacao + texto;

             
        }

    }
}