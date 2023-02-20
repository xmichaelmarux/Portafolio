using Portafolio.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Diagnostics.Contracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MailKit;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }
    public class ServicioEmailSenderGrid: IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSenderGrid(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje;
            var contenidoHtml = @$"De:{contacto.Nombre} -
                                   Email:{contacto.Email}
                                   Mensaje:{contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject,
                                mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);

            //String Servidor = "smtp.gmail.com";
            //int Puerto = 587;
            //String GmailUser = "marulanda19921995@gmail.com";
            //String GmailPass = "Pruebas2021";
            //MimeMessage mensaje = new();
            //mensaje.From.Add(new MailboxAddress("Pruebas", GmailUser));
            //mensaje.To.Add(new MailboxAddress("Destino", GmailUser));
            //mensaje.Subject = "Hola desde C# con MailKit";
            //BodyBuilder CuerpoMensaje = new();
            //CuerpoMensaje.TextBody = "Hola";
            //CuerpoMensaje.HtmlBody = "Hola <b>Mundo</b>";
            //mensaje.Body = CuerpoMensaje.ToMessageBody();
            //MailKit.Net.Smtp.SmtpClient ClienteSmtp = new();
            //ClienteSmtp.CheckCertificateRevocation = false;
            //ClienteSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
            //ClienteSmtp.Authenticate(GmailUser, GmailPass);
            //ClienteSmtp.Send(mensaje);
            //ClienteSmtp.Disconnect(true);
        }
    }
}
