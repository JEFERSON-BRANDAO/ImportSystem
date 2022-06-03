using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class ControleAcesso
    {
        public string Permissao(int IdUsuario)
        {
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            Objconn.Conectar();
            Objconn.Parametros.Clear();
            string sql = string.Format("SELECT TIPO FROM importacao.usuario WHERE IDUSUARIO = {0}", IdUsuario);
            Objconn.SetarSQL(sql);
            Objconn.Executar();
            Objconn.Desconectar();
            //
            if (Objconn.Tabela.Rows.Count > 0)
            {
                return Objconn.Tabela.Rows[0]["TIPO"].ToString();
            }

            return "Não é administrador.";
        }
    }
}