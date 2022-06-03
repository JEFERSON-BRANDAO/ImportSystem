using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Classes;
using System.Data;

namespace Classes
{
    public class Dados
    {
        public class Usuario
        {
            public string id { get; set; }
            public string usuario { get; set; }
            public string senha { get; set; }
            public string email { get; set; }
            public string status { get; set; }
            public string tipo { get; set; }

        }

        public class Fornecedor
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Local
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Modelo
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Exportador
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Despachante
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Forwarder
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Transp_Local
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Recinto
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Suframa
        {
            public string id { get; set; }
            public string produto { get; set; }

        }

        public class Moeda
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Icoterm
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Armador
        {
            public string id { get; set; }
            public string nome { get; set; }

        }

        public class Cliente
        {
            public string id { get; set; }
            public string nome { get; set; }

        }
        //
        public List<Usuario> ListaUsuario()
        {
            #region INFORMAÇÃO DE USUÁRIO

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Usuario> Lista = new List<Usuario>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idusuario AS ID,
                                                  login AS USUARIO, 
                                                  senha AS SENHA,
                                                  email AS EMAIL,
                                                  CASE status
                                                     WHEN 1 THEN 'true'
                                                     WHEN 0 THEN 'false'
                                                  ELSE
                                                     ''
                                                  END AS STATUS,
                                                  
                                                 CASE tipo
                                                     WHEN 'ADMINISTRADOR' THEN 'true'
                                                     WHEN 'USUARIO' THEN 'false'
                                                  ELSE
                                                     'false'
                                                  END AS TIPO                   
                                           FROM importacao.usuario
                                           ORDER BY login";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Usuario objUsuario = new Usuario();
                        objUsuario.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objUsuario.usuario = Objconn.Tabela.Rows[i]["USUARIO"].ToString();
                        objUsuario.senha = Objconn.Tabela.Rows[i]["SENHA"].ToString();
                        objUsuario.email = Objconn.Tabela.Rows[i]["EMAIL"].ToString();
                        objUsuario.status = Objconn.Tabela.Rows[i]["STATUS"].ToString();
                        objUsuario.tipo = Objconn.Tabela.Rows[i]["TIPO"].ToString();
                        //   
                        Lista.Add(objUsuario);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Fornecedor> ListaFornecedor()
        {
            #region INFORMAÇÃO DE FORNECEDOR

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Fornecedor> Lista = new List<Fornecedor>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idfornecedor AS ID,
                                                  nome AS NOME    
                                           FROM importacao.fornecedor
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Fornecedor objFornecedor = new Fornecedor();
                        objFornecedor.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objFornecedor.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objFornecedor);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Local> ListaLocal()
        {
            #region INFORMAÇÃO DE LOCAIS

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Local> Lista = new List<Local>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idlocal AS ID,
                                                  nome AS NOME    
                                           FROM importacao.local
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Local objLocal = new Local();
                        objLocal.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objLocal.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objLocal);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Modelo> ListaModelo()
        {
            #region INFORMAÇÃO DE MODELOS

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Modelo> Lista = new List<Modelo>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idmodelo AS ID,
                                                  nome AS NOME    
                                           FROM importacao.modelo
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Modelo objModelo = new Modelo();
                        objModelo.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objModelo.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objModelo);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Exportador> ListaExportador()
        {
            #region INFORMAÇÃO DE EXPORTADOR

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Exportador> Lista = new List<Exportador>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idexportador AS ID,
                                                  nome AS NOME    
                                           FROM importacao.exportador
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Exportador objExportador = new Exportador();
                        objExportador.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objExportador.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objExportador);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Despachante> ListaDespachante()
        {
            #region INFORMAÇÃO DE DESPACHANTE

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Despachante> Lista = new List<Despachante>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT iddespachante AS ID,
                                                  nome AS NOME    
                                           FROM importacao.despachante
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Despachante objDespachante = new Despachante();
                        objDespachante.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objDespachante.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objDespachante);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Forwarder> ListaForwarder()
        {
            #region INFORMAÇÃO DE FORWARDER

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Forwarder> Lista = new List<Forwarder>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idforwarder AS ID,
                                                  nome AS NOME    
                                           FROM importacao.forwarder
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Forwarder objForwarder = new Forwarder();
                        objForwarder.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objForwarder.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objForwarder);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Transp_Local> ListaTranspLocal()
        {
            #region INFORMAÇÃO DE TRANSPORTE LOCAL

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Transp_Local> Lista = new List<Transp_Local>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @" SELECT idtransp_local AS ID,
                                                  nome AS NOME    
                                           FROM importacao.transp_local
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Transp_Local objTransp_Local = new Transp_Local();
                        objTransp_Local.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objTransp_Local.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objTransp_Local);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Recinto> ListaRecinto()
        {
            #region INFORMAÇÃO DE RECINTO

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Recinto> Lista = new List<Recinto>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idrecinto AS ID,
                                                  nome AS NOME    
                                           FROM importacao.recinto
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Recinto objRecinto = new Recinto();
                        objRecinto.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objRecinto.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objRecinto);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Moeda> ListaMoeda()
        {
            #region INFORMAÇÃO DE MOEDA

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Moeda> Lista = new List<Moeda>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idmoeda AS ID,
                                                  nome AS NOME    
                                           FROM importacao.moeda
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Moeda objMoeda = new Moeda();
                        objMoeda.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objMoeda.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objMoeda);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Suframa> ListaProduto()
        {
            #region INFORMAÇÃO DE PRODUTOS SUFRAMA

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Suframa> Lista = new List<Suframa>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idsuframa AS ID,
                                                  produto AS PRODUTO    
                                           FROM importacao.suframa
                                           ORDER BY produto";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Suframa objSuframa = new Suframa();
                        objSuframa.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objSuframa.produto = Objconn.Tabela.Rows[i]["PRODUTO"].ToString();
                        //   
                        Lista.Add(objSuframa);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Icoterm> ListaIcoTerm()
        {
            #region INFORMAÇÃO DE ICO TERM

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Icoterm> Lista = new List<Icoterm>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idicoterm AS ID,
                                                  nome AS NOME    
                                           FROM importacao.icoterm
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Icoterm objIcoterm = new Icoterm();
                        objIcoterm.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objIcoterm.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objIcoterm);
                    }
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Armador> ListaArmador()
        {
            #region INFORMAÇÃO DE ARMADOR

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Armador> Lista = new List<Armador>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idarmador AS ID,
                                                  nome AS NOME    
                                           FROM importacao.armador
                                           ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Armador objArmador = new Armador();
                        objArmador.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objArmador.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objArmador);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<Cliente> ListaCliente()
        {
            #region INFORMAÇÃO DE CLIENTES

            MySQLDbConnect Objconn = new MySQLDbConnect();
            List<Cliente> Lista = new List<Cliente>();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                //
                string Sql = @"SELECT idcliente AS ID,
                                      nome AS NOME    
                                     FROM importacao.cliente
                                     ORDER BY nome";
                //
                Objconn.SetarSQL(Sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    for (int i = 0; i < Objconn.Tabela.Rows.Count; i++)
                    {
                        Cliente objCliente = new Cliente();
                        objCliente.id = Objconn.Tabela.Rows[i]["ID"].ToString();
                        objCliente.nome = Objconn.Tabela.Rows[i]["NOME"].ToString();
                        //   
                        Lista.Add(objCliente);
                    }

                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return Lista;

            #endregion
        }

        public List<DataTable> ListaAereo(int IdAir_shipiment)
        {
            List<DataTable> lista = new List<DataTable>();
            //
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    #region QUERY

                    string sql = @"SELECT a.IDAIR_SHIPMENT AS Id,
                                              COALESCE(a.PWCE, '?') PWCE,
                                              a.PACKLIST,
                                              a.PEDIDO, 
		                                      a.INVOICE,
                                              a.MATERIAL, 
                                              a.LIBERADO,                                              
                                              a.VLR_FOB,
                                              a.HAWB, 
                                              a.MAWB,      
                                              date_format(str_to_date(a.ETD_ORIGIN, '%Y-%m-%D'), '%d/%m/%Y') AS ETD_ORIGIN, 
                                              date_format(str_to_date(a.ETA_MAO, '%Y-%m-%D'), '%d/%m/%Y') AS ETA_MAO, 
                                              a.DI,
                                              date_format(str_to_date(a.DATA_DI, '%Y-%m-%D'), '%d/%m/%Y') AS DATA_DI, 
                                              a.CANAL_RF,
                                              a.CANAL_SEFAZ,
                                              date_format(str_to_date(a.ETA_FOXCONN, '%Y-%m-%D'), '%d/%m/%Y') AS ETA_FOXCONN, 
                                              a.REMARK,
                                              date_format(str_to_date(a.DATA_ENVIO, '%Y-%m-%D'), '%d/%m/%Y') AS DATA_ENVIO, 
                                              date_format(str_to_date(a.LIBERACAO, '%Y-%m-%D'), '%d/%m/%Y') AS LIBERACAO, 
                                              a.QUANTIDADE, 
                                              a.EMBARQUE,
                                              a.IDMODELO MODELO,
                                              date_format(str_to_date(a.ETD_MIA, '%Y-%m-%D'), '%d/%m/%Y') AS ETD_MIA, 
                                              a.CRITICO,                                         
		                                      b.IDFORNECEDOR AS FORNECEDOR,
                                              c.IDLOCAL AS LOCAL,
                                              d.IDMOEDA AS MOEDA,
                                              e.IDICOTERM AS ICOTERM,
                                              f.IDFORWARDER AS FORWARDER,
                                              g.IDRECINTO AS RECINTO,
                                              h.IDDESPACHANTE AS DESPACHANTE,
                                              i.IDCLIENTE AS CLIENTE
                                     FROM IMPORTACAO.air_shipment a
                                     INNER JOIN IMPORTACAO.fornecedor b ON a.IDFORNECEDOR= b.IDFORNECEDOR
                                     INNER JOIN IMPORTACAO.local c ON a.IDLOCAL= c.IDLOCAL
                                     INNER JOIN IMPORTACAO.moeda d ON a.IDMOEDA = d.IDMOEDA
                                     INNER JOIN IMPORTACAO.icoterm e ON a.IDICOTERM = e.IDICOTERM
                                     INNER JOIN IMPORTACAO.forwarder f ON a.IDFORWARDER = f.IDFORWARDER
                                     INNER JOIN IMPORTACAO.recinto g ON a.IDRECINTO = g.IDRECINTO
                                     INNER JOIN IMPORTACAO.despachante h ON a.IDDESPACHANTE = h.IDDESPACHANTE
LEFT OUTER JOIN IMPORTACAO.cliente i ON a.IDCLIENTE = i.IDCLIENTE
                                     WHERE a.IDAIR_SHIPMENT = " + IdAir_shipiment;

                    #endregion
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Tabela.Rows.Count > 0)
                    {
                        #region PREENCHE LISTA

                        lista.Add(Objconn.Tabela);

                        #endregion
                    }
                }
                catch
                {
                    //
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return lista;

        }

        public DataTable RelatorioAereo(int liberado, string sqlPwce, string sqlInvoice, string sqlCliente, string sqlPacklist)
        {
            DataTable dt = new DataTable();
            //
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    #region QUERY

                    string sql = string.Format(@"SELECT a.IDAIR_SHIPMENT AS Id,
                                              COALESCE(a.PWCE, '?') PWCE,
                                              COALESCE(a.PACKLIST, '-') PACKLIST,
                                              a.PEDIDO, 
		                                      a.INVOICE,
                                              a.MATERIAL, 
                                              CASE a.LIBERADO
                                                 WHEN 0 THEN 'NÃO'
                                              ELSE 'SIM'
                                              END LIBERADO,                                             
                                              a.VLR_FOB,
                                              a.HAWB,  
                                              a.MAWB, 
                                              date_format(str_to_date(a.ETD_ORIGIN, '%Y-%m-%D'), '%d/%m/%Y') AS ETD_ORIGIN, 
                                              date_format(str_to_date(a.ETA_MAO, '%Y-%m-%D'), '%d/%m/%Y') AS ETA_MAO, 
                                              a.DI,
                                              date_format(str_to_date(a.DATA_DI, '%Y-%m-%D'), '%d/%m/%Y') AS DATA_DI, 
                                              a.CANAL_RF,
                                              a.CANAL_SEFAZ,
                                              date_format(str_to_date(a.ETA_FOXCONN, '%Y-%m-%D'), '%d/%m/%Y') AS ETA_FOXCONN, 
                                              a.REMARK,
                                              date_format(str_to_date(a.DATA_ENVIO, '%Y-%m-%D'), '%d/%m/%Y') AS DATA_ENVIO, 
                                              date_format(str_to_date(a.LIBERACAO, '%Y-%m-%D'), '%d/%m/%Y') AS LIBERACAO, 
                                              a.QUANTIDADE, 
                                              a.EMBARQUE,
                                              date_format(str_to_date(a.ETD_MIA, '%Y-%m-%D'), '%d/%m/%Y') AS ETD_MIA, 
                                              a.CRITICO,                                         
		                                      b.NOME AS FORNECEDOR,
                                              c.NOME AS LOCAL,
                                              d.NOME AS MOEDA,
                                              e.IDICOTERM,
                                              e.NOME AS ICOTERM,
                                              f.NOME AS FORWARDER,
                                              g.NOME AS RECINTO,
                                              h.NOME AS DESPACHANTE
                                     FROM IMPORTACAO.air_shipment a
                                     INNER JOIN IMPORTACAO.fornecedor b ON a.IDFORNECEDOR= b.IDFORNECEDOR
                                     INNER JOIN IMPORTACAO.local c ON a.IDLOCAL= c.IDLOCAL
                                     INNER JOIN IMPORTACAO.moeda d ON a.IDMOEDA = d.IDMOEDA
                                     INNER JOIN IMPORTACAO.icoterm e ON a.IDICOTERM = e.IDICOTERM
                                     INNER JOIN IMPORTACAO.forwarder f ON a.IDFORWARDER = f.IDFORWARDER
                                     INNER JOIN IMPORTACAO.recinto g ON a.IDRECINTO = g.IDRECINTO
                                     INNER JOIN IMPORTACAO.despachante h ON a.IDDESPACHANTE = h.IDDESPACHANTE
                                     WHERE a.LIBERADO = {0}{1}{2}{3}{4}", liberado, sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
                    //"ORDER BY a.IDAIR_SHIPMENT DESC";

                    #endregion
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Tabela.Rows.Count > 0)
                    {
                        #region PREENCHE LISTA

                        dt = Objconn.Tabela;

                        #endregion
                    }
                }
                catch
                {
                    //
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return dt;

        }

        public List<DataTable> ListaMaritimo(int IdSea_shipiment)
        {
            List<DataTable> lista = new List<DataTable>();
            //
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    #region QUERY

                    string sql = @"SELECT a.IDSEA_SHIPMENT AS Id,
                                     COALESCE(a.PWCE, '?') PWCE,  
                                     COALESCE(a.PACKLIST, '-') PACKLIST,
                                     a.PEDIDO,
                                     a.INVOICE,
                                     a.FOB_USD,
                                     a.BL, 
                                     date_format(str_to_date(a.ETD_HK , '%Y-%m-%D'), '%d/%m/%Y') AS ETD_HK,
                                     date_format(str_to_date(a.ETA_MAO , '%Y-%m-%D'), '%d/%m/%Y') AS ETA_MAO, 
                                     a.DI,
                                     UPPER(a.CANAL_RF) AS CANAL_RF,
                                     UPPER(a.CANAL_SEFAZ) AS CANAL_SEFAZ,
                                     date_format(str_to_date(a.DATA, '%Y-%m-%D'), '%d/%m/%Y') AS DATA, 
                                     a.NR_CONTAINER,
                                     date_format(str_to_date(a.ETA_FOXCONN , '%Y-%m-%D'), '%d/%m/%Y') AS ETA_FOXCONN,  
                                     a.QTD_PALLETS,
                                     date_format(str_to_date(a.DATA_DEVOLUCAO , '%Y-%m-%D'), '%d/%m/%Y') AS DATA_DEVOLUCAO,  
                                     a.REMARKS,
                                     a.BLS_OCEANUS,
                                     a.DTA,
                                     date_format(str_to_date(a.LIBERACAO_IRF, '%Y-%m-%D'), '%d/%m/%Y') AS LIBERACAO_IRF,
                                     a.LIBERADO,
                                     a.EMBARQUE,
                                     a.CRITICO,
								     b.IDMODELO AS MODELO,
								     c.IDEXPORTADOR AS EXPORTADOR,           
								     d.IDRECINTO AS RECINTO,
								     e.IDARMADOR AS ARMADOR,
								     f.IDTRANSP_LOCAL AS TRANSP_LOCAL,
								     g.IDDESPACHANTE AS DESPACHANTE,
								     h.IDSUFRAMA AS PRODUTO,
i.IDCLIENTE AS CLIENTE,
 j.IDICOTERM,
 j.NOME AS ICOTERM
                                     FROM IMPORTACAO.sea_shipment a
                                     INNER JOIN IMPORTACAO.modelo b ON a.IDMODELO= b.IDMODELO
                                     INNER JOIN IMPORTACAO.exportador c ON a.IDEXPORTADOR= c.IDEXPORTADOR
								     INNER JOIN IMPORTACAO.recinto d ON a.IDRECINTO = d.IDRECINTO
                                     INNER JOIN IMPORTACAO.armador e ON a.IDARMADOR = e.IDARMADOR
                                     INNER JOIN IMPORTACAO.transp_local f ON a.IDTRANSP_LOCAL = f.IDTRANSP_LOCAL
								     INNER JOIN IMPORTACAO.despachante g ON a.IDDESPACHANTE = g.IDDESPACHANTE
								     INNER JOIN IMPORTACAO.suframa h ON a.IDSUFRAMA= h.IDSUFRAMA
LEFT OUTER JOIN IMPORTACAO.cliente i ON a.IDCLIENTE = i.IDCLIENTE
LEFT OUTER JOIN IMPORTACAO.icoterm j ON a.IDICOTERM = j.IDICOTERM
                                     WHERE a.IDSEA_SHIPMENT = " + IdSea_shipiment;

                    #endregion
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Tabela.Rows.Count > 0)
                    {
                        #region PREENCHE LISTA

                        lista.Add(Objconn.Tabela);

                        #endregion
                    }
                }
                catch
                {
                    //
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return lista;

        }

        public DataTable RelatorioMaritimo(int liberado, string sqlPwce, string sqlInvoice, string sqlCliente, string sqlPacklist)
        {

            DataTable dt = new DataTable();
            //
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    #region QUERY

                    string sql = string.Format(@"SELECT a.IDSEA_SHIPMENT AS Id, 
                                     COALESCE(a.PWCE, '?') PWCE,
                                     COALESCE(a.PACKLIST, '-') PACKLIST,
                                     a.PEDIDO,
                                     a.INVOICE,
                                     a.FOB_USD,
                                     a.BL, 
                                     date_format(str_to_date(a.ETD_HK , '%Y-%m-%D'), '%d/%m/%Y') AS ETD_HK,
                                     date_format(str_to_date(a.ETA_MAO , '%Y-%m-%D'), '%d/%m/%Y') AS ETA_MAO, 
                                     a.DI,
                                     UPPER(a.CANAL_RF) AS CANAL_RF,
                                     UPPER(a.CANAL_SEFAZ) AS CANAL_SEFAZ,
                                     date_format(str_to_date(a.DATA, '%Y-%m-%D'), '%d/%m/%Y') AS DATA, 
                                     a.NR_CONTAINER,
                                     date_format(str_to_date(a.ETA_FOXCONN , '%Y-%m-%D'), '%d/%m/%Y') AS ETA_FOXCONN,  
                                     a.QTD_PALLETS,
                                     date_format(str_to_date(a.DATA_DEVOLUCAO , '%Y-%m-%D'), '%d/%m/%Y') AS DATA_DEVOLUCAO,  
                                     a.REMARKS,
                                     a.BLS_OCEANUS,
                                     a.DTA,
                                     a.EMBARQUE,
                                     a.CRITICO,
                                     date_format(str_to_date(a.LIBERACAO_IRF, '%Y-%m-%D'), '%d/%m/%Y') AS LIBERACAO_IRF,
                                     CASE a.LIBERADO
                                       WHEN 0 THEN 'NÃO'
                                       ELSE 'SIM'
                                     END LIBERADO,
								     b.NOME AS MODELO,
								     c.NOME AS EXPORTADOR,           
								     d.NOME AS RECINTO,
								     e.NOME AS ARMADOR,
								     f.NOME AS TRANSP_LOCAL,
								     g.NOME AS DESPACHANTE,
								     h.PRODUTO AS PRODUTO
                                     FROM IMPORTACAO.sea_shipment a
                                     INNER JOIN IMPORTACAO.modelo b ON a.IDMODELO= b.IDMODELO
                                     INNER JOIN IMPORTACAO.exportador c ON a.IDEXPORTADOR= c.IDEXPORTADOR
								     INNER JOIN IMPORTACAO.recinto d ON a.IDRECINTO = d.IDRECINTO
                                     INNER JOIN IMPORTACAO.armador e ON a.IDARMADOR = e.IDARMADOR
                                     INNER JOIN IMPORTACAO.transp_local f ON a.IDTRANSP_LOCAL = f.IDTRANSP_LOCAL
								     INNER JOIN IMPORTACAO.despachante g ON a.IDDESPACHANTE = g.IDDESPACHANTE
								     INNER JOIN IMPORTACAO.suframa h ON a.IDSUFRAMA= h.IDSUFRAMA
                                     WHERE a.LIBERADO = {0}{1}{2}{3}{4}", liberado, sqlPwce, sqlInvoice, sqlCliente, sqlPacklist);
                    // "ORDER BY a.IDSEA_SHIPMENT DESC ";

                    #endregion
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Tabela.Rows.Count > 0)
                    {
                        #region PREENCHE LISTA

                        dt = Objconn.Tabela;

                        #endregion
                    }
                }
                catch
                {
                    //
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return dt;
        }

        public List<DataTable> ListaDemurrage(int IdSea_shipiment)
        {
            List<DataTable> lista = new List<DataTable>();
            //
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                try
                {
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();
                    //
                    #region QUERY

                    string sql = @"SELECT a.IDDEMURRAGE, 
                                        a.ORIGEM, 
                                        a.DESTINO,
                                        a.DATA_IDEAL_DEV,
                                        a.VENCIMENTO,
                                        a.SOL_RETIRADA,
                                        a.ENTREGA_DEPOT,
                                        a.QTD_DIARIA,
                                        b.ETA_MAO,
                                        b.ETA_FOXCONN,
                                        b.IDDEMURRAGE,
                                        b.EMBARQUE
                                     FROM importacao.demurrage a 
                                     INNER JOIN importacao.sea_shipment b ON a.IDDEMURRAGE = b.IDDEMURRAGE 
                                     WHERE b.IDSEA_SHIPMENT= " + IdSea_shipiment;

                    #endregion
                    //
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Tabela.Rows.Count > 0)
                    {
                        #region PREENCHE LISTA

                        lista.Add(Objconn.Tabela);

                        #endregion
                    }
                }
                catch
                {
                    //
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            return lista;

        }
    }
}