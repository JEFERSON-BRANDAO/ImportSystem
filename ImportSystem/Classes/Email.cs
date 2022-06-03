using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace Classes
{
    public class Email
    {
        public void Enviar(string Remente, string NomeSolicitante, string EmailSolicitante, string NomeFuncCompras, string EmailFuncCompras, string Corpo, string Assunto, string NumSolicitacao, string TipoAviso)
        {
            #region ENVIAR EMAIL

            if (ConfigurationManager.AppSettings["ENVIAR_EMAIL"] == "1")//se habilitado para enviar
            {

                MailMessage Mail = new MailMessage();
                StringBuilder msgBody = new StringBuilder();
                //
                string ano = DateTime.Now.Year.ToString();
                string mes = DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
                string dia = DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                string hora = DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
                string minuto = DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
                string dataHora = dia + "/" + mes + "/" + ano + " " + hora + ":" + minuto;
                //
                string saudacao = string.Empty;
                if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour <= 11)
                {
                    saudacao = "Bom dia";
                }
                else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
                {
                    saudacao = "Boa tarde";
                }
                else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
                {
                    saudacao = "Boa noite";

                }
                //
                msgBody.Append("<br /><br />");

                if (TipoAviso == "COTAÇÃO")
                {
                    string url = ConfigurationManager.AppSettings["LINK"];
                    Corpo += saudacao +
                           "<br /><br />" +
                           "Prezado(a)  " + NomeSolicitante + "," +
                           "<br /> " +
                           "Foi dado início na cotação de sua solicitação número: " + NumSolicitacao +
                           "<br /> " +
                           "Por: " + NomeFuncCompras +
                           "<br /> " +
                           "<br /> " +
                           "Acesse o " + "<a href=" + url + ">" + "Sistema" + "</a>" + " para acompanhar." +
                           "<br /><br />" +
                           "Atenciosamente," +
                           "<br /> <br /> <br /> <br />" +
                           "PURCHASING MANAGEMENT SYSTEM";
                }
                else if (TipoAviso == "FINALIZADA")
                {
                    string url = ConfigurationManager.AppSettings["LINK"];
                    Corpo += saudacao +
                           "<br /><br />" +
                           "Prezado(a)  " + NomeSolicitante + "," +
                           "<br /> " +
                           "<br /> " +
                           "Sua solicitação número: " + NumSolicitacao + ", foi finalizada." +
                           "<br /> " +
                           "Acesse o " + "<a href=" + url + ">" + "Sistema" + "</a>" + " para verificar a conclusão." +
                           "<br /><br />" +
                           "Atenciosamente," +
                           "<br /> <br /> <br /> <br />" +
                           "PURCHASING MANAGEMENT SYSTEM";
                }
                else if (TipoAviso == "CANCELADA")
                {
                    string url = ConfigurationManager.AppSettings["LINK"];
                    Corpo += saudacao +
                           "<br /><br />" +
                           "Prezado(a)  " + NomeSolicitante + "," +
                           "<br /> " +
                           "Sua solicitação número: " + NumSolicitacao + ", foi cancelada." +
                           "<br /> " +
                           "<br /> " +
                           "Acesse o " + "<a href=" + url + ">" + "Sistema" + "</a>" + " para verificar o cancelamento." +
                           "<br /><br />" +
                           "Atenciosamente," +
                           "<br /> <br /> <br /> <br />" +
                           "PURCHASING MANAGEMENT SYSTEM";
                }

                //
                string sCorpoEmail = Corpo;
                sCorpoEmail = sCorpoEmail + msgBody.ToString();
                //
                Mail.To.Add(EmailSolicitante);//email para o solicitante

                if (!string.IsNullOrEmpty(EmailFuncCompras))//somente quando funcionário compras já estiver dado inicio a cotação da solicitação
                    Mail.CC.Add(EmailFuncCompras);
                //
                Mail.From = new MailAddress(Remente, "AVISO");
                //
                Mail.Subject = Assunto;
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                Mail.Body = sCorpoEmail;
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                Mail.IsBodyHtml = true;
                Mail.Priority = MailPriority.High;
                //
                try
                {
                    string Servidor_Smtp = ConfigurationManager.AppSettings["SMTP"];
                    //
                    SmtpClient smtp = new SmtpClient(Servidor_Smtp);
                    smtp.Port = 25;
                    //            
                    smtp.Send(Mail);

                    //
                    Log objLog = new Log();
                    objLog.Gravar(NumSolicitacao, "Email enviado com sucesso", TipoAviso);
                }
                catch (Exception erro)
                {
                    string messageErro = erro.Message;
                    //
                    if (erro.InnerException != null)
                    {
                        messageErro += " - " + erro.InnerException.Message;
                    }

                    Log objLog = new Log();
                    objLog.Gravar(NumSolicitacao, messageErro, TipoAviso);

                }
            }

            #endregion
        }

    }
}