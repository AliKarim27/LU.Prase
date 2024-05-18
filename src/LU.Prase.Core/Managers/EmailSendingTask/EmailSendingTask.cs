using Abp.Domain.Services;
using Abp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Managers.EmailSendingTask
{
    public class EmailSendingTask   : IEmailSendingTask
    {
        private readonly IEmailSender _emailSender;

        public async Task SendEmail(string recipient, string message, string subject)
        {
            await _emailSender.SendAsync(recipient, subject, message);
        }
    }
}
