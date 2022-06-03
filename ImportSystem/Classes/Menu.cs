using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Descricao { get; set; }
        public Menu(int id, string descricao)
        {
            this.MenuId = id;
            this.Descricao = descricao;
        }
        public static List<Menu> GetMenu()
        {
            List<Menu> lista = new List<Menu>()     
        {
            new Menu(1, "Cadastro"),
            //new Menu(2, "Movimento"),
            //new Menu(3, "Relatórios")
        };
            return lista;
        }
    }
}