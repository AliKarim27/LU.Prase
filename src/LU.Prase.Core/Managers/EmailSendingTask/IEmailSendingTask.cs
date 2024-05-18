using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Managers.EmailSendingTask
{
    public interface IEmailSendingTask : IDomainService
    {
        Task SendEmail(string recipient, string message, string subject);
    }
}
