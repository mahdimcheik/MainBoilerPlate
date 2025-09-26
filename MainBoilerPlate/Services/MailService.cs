using System.Dynamic;
using System.Net;
using System.Net.Mail;
using MainBoilerPlate.Models;
using MainBoilerPlate.Templates;
using MainBoilerPlate.Utilities;
using RazorLight;

namespace MainBoilerPlate.Services
{
    public class MailService
    {
        private readonly IRazorLightEngine _razorLightEngine;
        private readonly IWebHostEnvironment _env;

        public MailService(IWebHostEnvironment env)
        {
            _env = env;
            _razorLightEngine = new RazorLightEngineBuilder()
                .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "Templates"))
                //.UseFileSystemProject(Path.Combine(_env.WebRootPath, "TemplatesInvoice"))
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task SendEmail(MailApp mail)
        {
            var smtpClient = new SmtpClient(EnvironmentVariables.SMTP_HOST)
            {
                Port = EnvironmentVariables.SMTP_PORT,
                Credentials = new NetworkCredential(
                    EnvironmentVariables.SMTP_LOGIN,
                    EnvironmentVariables.SMTP_KEY
                ),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(mail.MailFrom),
                Subject = mail.MailSubject,
                Body = mail.MailBody,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(mail.MailTo);

            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendConfirmAccount(UserApp receiver, string confirmLink)
        {
            try
            {
                var model = new ConfirmMailModel(
                    receiver,
                    confirmLink,
                    EnvironmentVariables.API_FRONT_URL
                );

                string template = await _razorLightEngine.CompileRenderAsync("ConfirmAccountTemplate.cshtml", model);     

                MailApp mailApp = new MailApp
                {
                    MailFrom = EnvironmentVariables.DO_NO_REPLY_MAIL,
                    MailTo = receiver.Email!,
                    MailSubject = "Confirmation de votre compte",
                    MailBody = template,
                };

                await SendEmail(mailApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task SendResetPasswordAccount(UserApp receiver, string confirmLink)
        {
            try
            {
                var model = new ResetPasswordModel(
                    receiver,
                    confirmLink,
                    EnvironmentVariables.API_FRONT_URL
                );

                string template = await _razorLightEngine.CompileRenderAsync("ForgotPasswordTemplate.cshtml", model);

                MailApp mailApp = new MailApp
                {
                    MailFrom = EnvironmentVariables.DO_NO_REPLY_MAIL,
                    MailTo = receiver.Email!,
                    MailSubject = "Récupérer votre mot de passe",
                    MailBody = template,
                };

                await SendEmail(mailApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
