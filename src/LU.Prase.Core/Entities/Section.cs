using Abp.Domain.Entities.Auditing;
using LU.Prase.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Entities
{
    public class Section : FullAuditedEntity<long>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual List<User> Responsibles { get; set; }

    }
}
