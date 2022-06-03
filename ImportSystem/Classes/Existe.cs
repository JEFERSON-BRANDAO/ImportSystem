using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class Existe
    {
        public string Usuario(string login)
        {
            #region VERIFICA SE USUÁRIO JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.usuario WHERE lower(trim(LOGIN))='{0}'", login);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Fornecedor(string nome)
        {
            #region VERIFICA SE FORNECEDOR JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.fornecedor  WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Local(string nome)
        {
            #region VERIFICA SE LOCAL JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.local WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Modelo(string nome)
        {
            #region VERIFICA SE MODELO JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.modelo WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Exportador(string nome)
        {
            #region VERIFICA SE EXPORTADOR JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.exportador WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Despachante(string nome)
        {
            #region VERIFICA SE DESPACHANTE JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.despachante WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Forwarder(string nome)
        {
            #region VERIFICA SE FORWARDER JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.forwarder WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Tranp_local(string nome)
        {
            #region VERIFICA SE TRANSPORTE LOCAL JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.transp_local WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Recinto(string nome)
        {
            #region VERIFICA SE RECINTO JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.recinto WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Moeda(string nome)
        {
            #region VERIFICA SE MOEDA JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.moeda  WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Suframa(string produto)
        {
            #region VERIFICA SE PRODUTO JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.suframa WHERE lower(trim(NOME))='{0}'", produto);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Ico_Term(string nome)
        {
            #region VERIFICA SE ICO TERM JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.ico_term WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

        public string Armador(string nome)
        {
            #region VERIFICA SE ARMADOR JÁ É EXISTENTE

            string resposta = string.Empty;
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
                    string Sql = string.Format("SELECT COUNT(*) AS ROWCOUNT FROM importacao.armador WHERE lower(trim(NOME))='{0}'", nome);
                    //
                    Objconn.SetarSQL(Sql);
                    Objconn.Executar();
                    //
                    if (Objconn.Isvalid)
                    {
                        resposta = Objconn.Tabela.Rows[0][0].ToString();
                        //
                        if (int.Parse(resposta) > 0)
                            resposta = "true";
                    }

                }
                catch (Exception erro)
                {
                    resposta = erro.Message;
                }
            }
            finally
            {
                Objconn.Desconectar();
            }

            return resposta;

            #endregion
        }

    }
}