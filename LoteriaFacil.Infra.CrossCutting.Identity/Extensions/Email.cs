using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using LoteriaFacil.Infra.CrossCutting.Identity.Offline;

namespace LoteriaFacil.Infra.CrossCutting.Identity.Extensions
{
    public class Email
    {
        private string _remetente;
        private string _destinatario;
        private List<string> _bcc;
        private List<string> _cc;
        private string _assunto;
        private string _corpo;
        private string[] _arquivos;

        /// <summary>
        /// Envia email SEM cc
        /// </summary>
        /// <param name="remetente"></param>
        /// <param name="destinatario"></param>
        /// <param name="assunto"></param>
        /// <param name="corpo"></param>
        /// <remarks></remarks>
        public Email(string remetente, string destinatario, string assunto, string corpo)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _corpo = corpo;
        }

        /// <summary>
        /// Enviar email apenas COM bcc
        /// </summary>
        /// <param name="remetente"></param>
        /// <param name="destinatario"></param>
        /// <param name="bcc"></param>
        /// <param name="assunto"></param>
        /// <param name="corpo"></param>
        public Email(string remetente, string destinatario, List<string> bcc, string assunto, string corpo)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _bcc = bcc;
            _corpo = corpo;
        }

        /// <summary>
        /// Enviar email SEM anexos
        /// </summary>
        /// <param name="remetente"></param>
        /// <param name="destinatario"></param>
        /// <param name="bcc"></param>
        /// <param name="cc"></param>
        /// <param name="assunto"></param>
        /// <param name="body"></param>
        /// <remarks></remarks>
        public Email(string remetente, string destinatario, List<string> bcc, List<string> cc, string assunto, string body)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _bcc = bcc;
            _cc = cc;
            _assunto = assunto;
            _corpo = body;
        }
        /// <summary>
        /// Enviar email COM anexos
        /// </summary>
        /// <param name="remetente"></param>
        /// <param name="destinatario"></param>
        /// <param name="bcc"></param>
        /// <param name="cc"></param>
        /// <param name="assunto"></param>
        /// <param name="body"></param>
        /// <param name="arquivos"></param>
        /// <remarks></remarks>
        public Email(string remetente, string destinatario, List<string> bcc, List<string> cc, string assunto, string body, string[] arquivos)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _bcc = bcc;
            _cc = cc;
            _assunto = assunto;
            _corpo = body;
            _arquivos = arquivos;
        }

        /// <summary>
        /// Método para enviar o e-mail. Originalmente ele é void, mas eu mudei pra bool.
        /// </summary>
        /// <returns></returns>
        public bool EnviaMensagemEmail()
        {
            bool ok = false;
            //Criar uma estancia de objeto mailMessage
            MailMessage mMailMessage = new MailMessage();

            //Indicacao da origem
            mMailMessage.From = new MailAddress(_remetente);

            if (!string.IsNullOrEmpty(_destinatario))
                //Indicacao do destinatario
                mMailMessage.To.Add(new MailAddress(_destinatario));

            //verificacao se o valor bcc é nulo ou texto é vazio
            if ((_bcc != null) && _bcc.Count > 0)
                for (int i = 0; i < _bcc.Count; i++)
                    mMailMessage.Bcc.Add(new MailAddress(_bcc[i]));

            //verificacao se o valor bcc é nulo ou texto é vazio
            if ((_cc != null) && _cc.Count > 0)
                for (int i = 0; i < _cc.Count; i++)
                    mMailMessage.Bcc.Add(new MailAddress(_cc[i]));

            //Define o assunto
            mMailMessage.Subject = _assunto;

            //Corpo da mensagem
            mMailMessage.Body = _corpo;

            //Tipo de formatacao do HTML
            mMailMessage.IsBodyHtml = false;

            //Definir a prioridade da mensagem
            mMailMessage.Priority = MailPriority.Normal;

            //Anexa arquivos
            if (_arquivos != null && _arquivos.Length > 0)
            {
                int i = 0;
                for (i = 0; i <= _arquivos.Length - 1; i++)
                    mMailMessage.Attachments.Add(new Attachment(_arquivos[i]));
            }

            /*Hotmail/Oultlook/Live*/
            //Cliente de envio do email smtp.server.com
            //SmtpClient mSmtpClient = new SmtpClient("smtp.live.com");
            //mSmtpClient.Credentials = new System.Net.NetworkCredential("biboskbr@hotmail.com", "5zrnt8hu");
            //mSmtpClient.Port = 25;
            //mSmtpClient.EnableSsl = true;
            //Enviar o Email

            //Gmail
            SmtpClient mSmtpClient = new SmtpClient("smtp.gmail.com");
            mSmtpClient.EnableSsl = true; // Gmail requer SSL
            mSmtpClient.Port = 587;       // porta para SSL
            mSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
            mSmtpClient.UseDefaultCredentials = false; // vamos utilizar credencias especificas

            mSmtpClient.Credentials = new NetworkCredential(Credenciais.EMAIL, Credenciais.PASSWORD);
            //Desabilita as crendenciais default

            //// usuário e senha para autenticação    
            //mSmtpClient.Credentials = new NetworkCredential("diegogalantte@gmail.com", "(5zrnt8hu);");

            mMailMessage.IsBodyHtml = true;
            try
            {
                mSmtpClient.Send(mMailMessage);
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                throw new Exception("Erro ao enviar email " + ex.Message);
            }
            finally
            {
                mSmtpClient.Dispose();
                mMailMessage.Dispose();
            }

            return ok;
        }

        ~Email()
        {

        }
    }
}

