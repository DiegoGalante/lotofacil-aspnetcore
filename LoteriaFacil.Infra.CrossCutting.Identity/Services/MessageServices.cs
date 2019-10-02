using System.Threading.Tasks;
using LoteriaFacil.Infra.CrossCutting.Identity.Extensions;
using LoteriaFacil.Infra.CrossCutting.Identity.Offline;

namespace LoteriaFacil.Infra.CrossCutting.Identity.Services
{

    public class AuthEmailMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            Email emailEnviar = new Email(Credenciais.EMAIL_REMETENTE, email, subject, message);
            try
            {
                emailEnviar.EnviaMensagemEmail();
                return Task.FromResult(1);
            }
            catch (System.Exception ex)
            {
                return Task.FromResult(0);
            }
            
        }
    }

    public class AuthSMSMessageSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
