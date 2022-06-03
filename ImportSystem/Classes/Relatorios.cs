using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data;
using System.Collections;
using Classes;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Classes
{
    public class Relatorios
    {
        #region FORMULÁRIO AÉREO

        public IList<Aereo> ListaFormularioAereo(string IdAereo)
        {
            #region SELECT AEREO
            //
            Moeda moeda = new Moeda();
            List<Aereo> Lista = new List<Aereo>();
            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                string sql = string.Format(@"SELECT a.IDAIR_SHIPMENT ID, 
                                              a.MATERIAL, 
                                              a.PWCE, 
                                              fo.NOME SUPPLIER_NAME,
                                              c.NOME CUSTOMER_NAME,                                             
                                              'AÉREO' AS MODAL ,
                                              i.NOME ICOTERM,
                                              f.NOME FORWARDER,
                                              a.ETD_MIA ETD,
                                              DATE_FORMAT (a.ETA_MAO,'%d/%m/%Y')ETA_MAO,
                                              r.NOME RECINTO, 
                                              l.NOME LOCAL, 
                                              a.HAWB, 
                                              a.QUANTIDADE CONTAINER, 
                                              a.DI DI_NUMBER,
                                              DATE_FORMAT (a.DATA_DI,'%d/%m/%Y')DATA_DI, 
                                              a.CANAL_RF, 
                                              a.CANAL_SEFAZ,
                                              m.NOME PROJECT_MODEL,
                                              a.PEDIDO PO, 
 -- COALESCE(CONCAT(a.PEDIDO,'\n\n\n\n REMARKS:\n\n',a.REMARK),CONCAT('\n\n\n\n REMARKS:\n\n',a.REMARK))AS PO, 
                                              a.INVOICE, 
                                              a.VLR_FOB VALOR,
                                              a.REMARK REMARKS
                                              FROM importacao.air_shipment a
                                              left JOIN importacao.cliente c on a.IDCLIENTE = c.IDCLIENTE
                                              left JOIN importacao.fornecedor fo on a.IDFORNECEDOR = fo.IDFORNECEDOR
                                              left JOIN importacao.icoterm i on a.IDICOTERM = i.IDICOTERM
                                              left JOIN importacao.forwarder f on a.IDFORWARDER = f.IDFORWARDER
                                              left JOIN importacao.recinto r on a.IDRECINTO = r.IDRECINTO 
                                              left JOIN importacao.local l on a.IDLOCAL = l.IDLOCAL
                                              left JOIN importacao.modelo m on a.IDMODELO = m.IDMODELO WHERE a.IDAIR_SHIPMENT ={0}", IdAereo);
//where UPPER(a.PWCE)='{0}'", pwce);
                //WHERE a.IDAIR_SHIPMENT ={0}", IdAereo);
                //
                Objconn.SetarSQL(sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    foreach (DataRow linha in Objconn.Tabela.Rows)
                    {
                        Aereo item = new Aereo();
                        // 
                        item.PWCE = linha["PWCE"].ToString();
                        item.SUPPLIER_NAME = linha["SUPPLIER_NAME"].ToString();
                        item.CUSTOMER_NAME = linha["CUSTOMER_NAME"].ToString();
                        item.MODAL = linha["MODAL"].ToString();
                        item.ICOTERM = linha["ICOTERM"].ToString();
                        item.FORWARDER = linha["FORWARDER"].ToString();
                        item.ETD = linha["ETD"].ToString();
                        item.ETA_MAO = linha["ETA_MAO"].ToString();
                        item.RECINTO = linha["RECINTO"].ToString();
                        item.LOCAL = linha["LOCAL"].ToString();
                        item.HAWB = linha["HAWB"].ToString();
                        item.CONTAINER = linha["CONTAINER"].ToString();
                        item.DI_NUMBER = linha["DI_NUMBER"].ToString();
                        item.DATA_DI = linha["DATA_DI"].ToString();
                        item.CANAL_RF = linha["CANAL_RF"].ToString();
                        item.CANAL_SEFAZ = linha["CANAL_SEFAZ"].ToString();
                        item.PROJECT_MODEL = linha["PROJECT_MODEL"].ToString();
                        item.PO = linha["PO"].ToString();
                        item.INVOICE = linha["INVOICE"].ToString();
                        item.VALOR = linha["VALOR"].ToString();
                        item.REMARKS = linha["REMARKS"].ToString();
                        //adiciona na lista
                        Lista.Add(item);
                    }
                }

            }
            catch (Exception erro)
            {
                string err = erro.Message;
                Lista.Clear();
            }
            finally
            {
                Objconn.Desconectar();
            }
            //
            return Lista;

            #endregion
        }

        #endregion
        //
        #region FORMULÁRIO MARÍTIMO

        public IList<Maritimo> ListaFormularioMaritimo(string IdMaritimo)
        {
            #region SELECT MARITIMO
            //
            Moeda moeda = new Moeda();
            List<Maritimo> Lista = new List<Maritimo>();

            MySQLDbConnect Objconn = new MySQLDbConnect();
            //
            try
            {
                Objconn.Conectar();
                Objconn.Parametros.Clear();
                string sql = string.Format(@"SELECT a.IDSEA_SHIPMENT ID, 
                                           -- a.MATERIAL, 
                                              a.PWCE, 
                                              fo.NOME SUPPLIER_NAME,
                                              c.NOME CUSTOMER_NAME,
                                              'MARÍTIMO' AS MODAL ,
                                              i.NOME ICOTERM,
                                              f.NOME FORWARDER,
                                              a.ETD_HK ETD,
                                              DATE_FORMAT (a.ETA_MAO,'%d/%m/%Y')ETA_MAO,
                                              r.NOME RECINTO, 
                                            -- l.NOME LOCAL, 
                                              a.BL, 
                                              concat(a.NR_CONTAINER,'/', a.QTD_PALLETS)CONTAINER, 
                                              a.DI DI_NUMBER,
                                              DATE_FORMAT (a.DATA,'%d/%m/%Y')DATA_DI,  
                                              a.CANAL_RF, 
                                              a.CANAL_SEFAZ,
                                              m.NOME PROJECT_MODEL,
                                              a.PEDIDO PO, 
 -- COALESCE(CONCAT(a.PEDIDO,'\n\n\n\n REMARKS:\n\n',a.REMARKS),CONCAT('\n\n\n\n REMARKS:\n\n',a.REMARKS))AS PO, 
                                              a.INVOICE, 
                                              a.FOB_USD VALOR,
                                              a.REMARKS
                                          FROM importacao.sea_shipment a
                                              left outer JOIN importacao.cliente c on a.IDCLIENTE = c.IDCLIENTE
                                              left outer JOIN importacao.exportador fo on a.IDEXPORTADOR = fo.IDEXPORTADOR
                                              left outer JOIN importacao.icoterm i on a.IDICOTERM = i.IDICOTERM
                                              left outer JOIN importacao.armador f on a.IDARMADOR = f.IDARMADOR
                                              left outer JOIN importacao.recinto r on a.IDRECINTO = r.IDRECINTO 
                                            -- left outer JOIN importacao.local l on a.IDLOCAL = l.IDLOCAL
                                              left outer JOIN importacao.modelo m on a.IDMODELO = m.IDMODELO WHERE IDSEA_SHIPMENT={0}", IdMaritimo);
//where UPPER(a.PWCE)='{0}'", pwce);
                // WHERE IDSEA_SHIPMENT={0}", IdMaritimo);
                //
                Objconn.SetarSQL(sql);
                Objconn.Executar();
                //
                if (Objconn.Tabela.Rows.Count > 0)
                {
                    foreach (DataRow linha in Objconn.Tabela.Rows)
                    {
                        Maritimo item = new Maritimo();
                        // 
                        item.PWCE = linha["PWCE"].ToString();
                        item.SUPPLIER_NAME = linha["SUPPLIER_NAME"].ToString();
                        item.CUSTOMER_NAME = linha["CUSTOMER_NAME"].ToString();
                        item.MODAL = linha["MODAL"].ToString();
                        item.ICOTERM = linha["ICOTERM"].ToString();
                        item.FORWARDER = linha["FORWARDER"].ToString();
                        item.ETD = linha["ETD"].ToString();
                        item.ETA_MAO = linha["ETA_MAO"].ToString();
                        item.RECINTO = linha["RECINTO"].ToString();
                        item.LOCAL = "";//linha["LOCAL"].ToString();
                        item.BL = linha["BL"].ToString();
                        item.CONTAINER = linha["CONTAINER"].ToString();
                        item.DI_NUMBER = linha["DI_NUMBER"].ToString();
                        item.DATA_DI = linha["DATA_DI"].ToString();
                        item.CANAL_RF = linha["CANAL_RF"].ToString();
                        item.CANAL_SEFAZ = linha["CANAL_SEFAZ"].ToString();
                        item.PROJECT_MODEL = linha["PROJECT_MODEL"].ToString();
                        item.PO = linha["PO"].ToString();
                        item.INVOICE = linha["INVOICE"].ToString();
                        item.VALOR = linha["VALOR"].ToString();
                        item.REMARKS = linha["REMARKS"].ToString();
                        //
                        Lista.Add(item);//adiciona na lista

                    }
                }

            }
            catch (Exception erro)
            {
                string err = erro.Message;
                Lista.Clear();
            }
            finally
            {
                Objconn.Desconectar();
            }

            //
            return Lista;

            #endregion
        }

        #endregion


    }

}