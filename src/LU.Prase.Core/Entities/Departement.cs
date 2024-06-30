using Abp.Domain.Entities.Auditing;
using LU.Prase.Authorization.Users;
using System.Collections.Generic;

namespace LU.Prase.Entities
{
    public class Departement : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public virtual List<User> Responsibles { get; set; }
        public virtual List<Section> Sections { get; set; }
    }
}
