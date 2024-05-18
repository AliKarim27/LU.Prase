using Abp.Net.Mail;
using Hangfire;
using LU.Prase.Managers.EmailSendingTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Managers.EmailSendingManagers
{
    public class EmailSendingManager : IEmailSendingManager
    {
        private readonly IEmailSender _emailSender;

        public EmailSendingManager(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }
        public void SendEmail(string recipient, string message, string subject)
        {
            BackgroundJob.Enqueue<IEmailSendingTask>(x => x.SendEmail(recipient, message, subject));
        }
    }
}
