using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Managers.EmailSendingManagers
{
    public interface IEmailSendingManager : IDomainService
    {
        void SendEmail(string recipient, string message, string subject);
    }
}
