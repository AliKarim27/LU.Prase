using JetBrains.Annotations;
using LU.Prase.Configuration.Dto;
using LU.Prase.EmailSender.DTO;
using LU.Prase.Managers.EmailSendingManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.EmailSender
{
    public class EmailSenderAppService : IEmailSenderAppService
    {

        private readonly IEmailSendingManager _emailSendingManager;

        public EmailSenderAppService(IEmailSendingManager emailSendingManager)
        {
            _emailSendingManager = emailSendingManager;
        }

        public void SendEmail(CreateEmailDto emailDto)
        {
            _emailSendingManager.SendEmail(emailDto.Recipients, emailDto.Body, emailDto.Subject);
        }
    }
}
