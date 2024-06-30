using Abp.Domain.Entities.Auditing;
using LU.Prase.Entities.Enums;

namespace LU.Prase.Entities
{
    public class Machine : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public MachineStates MachineStates { get; set; }
        public virtual Section Section { get; set; }
    }
}
