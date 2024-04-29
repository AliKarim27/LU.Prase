using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LU.Prase.Models.EmailConfiguration.EmailSendingConstants;

namespace LU.Prase.Models.EmailConfiguration
{
    public class EmailSendingConfiguration : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[] {
                 new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.Host,
                   EmailSendingHost
                   ),
               new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.Port,
                   EmailSendingPort
                   ),
               new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.UserName,
                   EmailSendingUserName
                   ),
                new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.Password,
                   EmailSendingPassword
                   ),
                 new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.EnableSsl,
                  EmailSendingEnableSsl
                   ),
                 new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.UseDefaultCredentials,
                   EmailSendingUseDefaultCredentials
                   ),
                  new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.Smtp.Domain,
                   EmailSendingUseDefaultDomain
                   ),
                  new SettingDefinition(
                   Abp.Net.Mail.EmailSettingNames.DefaultFromAddress,
                    EmailSendingUseDefaultFromAddress
                   ),
            };
        }
    }
}
