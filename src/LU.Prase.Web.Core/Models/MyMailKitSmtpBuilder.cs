using Abp.MailKit;
using Abp.Net.Mail.Smtp;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Models
{
    internal class MyMailKitSmtpBuilder : DefaultMailKitSmtpBuilder
    {
        public MyMailKitSmtpBuilder(ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration, IAbpMailKitConfiguration abpMailKitConfiguration) : base(smtpEmailSenderConfiguration, abpMailKitConfiguration)
        {
        }
        protected override void ConfigureClient(SmtpClient client)
        {
            client.CheckCertificateRevocation = false;
            base.ConfigureClient(client);
        }
    }
}
