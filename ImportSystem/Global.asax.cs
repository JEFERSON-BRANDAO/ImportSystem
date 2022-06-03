using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace ImportSystem
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("login", "Login", "~/Login.aspx");
            routes.MapPageRoute("default", "Home", "~/Default.aspx");
            routes.MapPageRoute("aereo", "Aereo", "~/aereo.aspx");
            //
            routes.MapPageRoute("novoAereo", "novoAereo", "~/novoAereo.aspx");
            routes.MapPageRoute("Novo_Aereo", "novoAereo/{id}", "~/novoAereo.aspx");

            routes.MapPageRoute("maritimo", "Maritimo", "~/maritimo.aspx");
            //
            routes.MapPageRoute("novoMaritimo", "novoMaritimo", "~/novoMaritimo.aspx");
            routes.MapPageRoute("novo_Maritimo", "novoMaritimo/{id}", "~/novoMaritimo.aspx");


            routes.MapPageRoute("cadastro", "Cadastro", "~/cadastro.aspx");
            routes.MapPageRoute("demurrage", "Demurrage", "~/demurrage.aspx");
            routes.MapPageRoute("saindo", "Logout", "~/sair.aspx");
            //
            //routes.MapPageRoute("formularioAereo", "FormularioAereo", "~/FormularioAereo.aspx");
            routes.MapPageRoute("formularioAereo", "FormularioAereo/{id}", "~/FormularioAereo.aspx");
            //routes.MapPageRoute("formularioMaritimo", "FormularioMaritimo", "~/FormularioMaritimo.aspx");
            routes.MapPageRoute("formularioMaritimo", "FormularioMaritimo/{id}", "~/FormularioMaritimo.aspx");

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
