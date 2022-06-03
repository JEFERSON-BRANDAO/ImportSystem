using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class SubMenu
    {
        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        public SubMenu(int menuId, int subMenuId, string descricao, string url)
        {
            this.MenuId = menuId;
            this.SubMenuId = subMenuId;
            this.Descricao = descricao;
            this.URL = url;
        }
        public static List<SubMenu> GetSubMenu()
        {
            List<SubMenu> lista = new List<SubMenu>()
        {
            new SubMenu(1, 1, "Usuário", "cadastro?p=usuario"),
            new SubMenu(1, 2, "Fornecedor", "cadastro?p=fornecedor"),
            new SubMenu(1, 3, "Local", "cadastro?p=local"),
            new SubMenu(1, 4, "Modelo", "cadastro?p=modelo"),
            new SubMenu(1, 5, "Exportador", "cadastro?p=exportador"),
            new SubMenu(1, 6, "Despachante", "cadastro?p=despachante"),
            new SubMenu(1, 7, "Forwarder", "cadastro?p=forwarder"),
            new SubMenu(1, 8, "Transporte Local", "cadastro?p=transporte"),
            new SubMenu(1, 9, "Recinto", "cadastro?p=recinto"),
            new SubMenu(1, 10, "Moeda", "cadastro?p=moeda"),
            new SubMenu(1, 11, "Produto SUFRAMA", "cadastro?p=suframa"),
            new SubMenu(1, 12, "IcoTerm", "cadastro?p=ico_term"),
            new SubMenu(1, 13, "Armador", "cadastro?p=armador"),
        };
            return lista;
        }
    }
}