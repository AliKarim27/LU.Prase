using Abp.Domain.Entities.Auditing;
using LU.Prase.Authorization.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LU.Prase.Entities
{
    public class StudentRequest : FullAuditedEntity<long>
    {
        [ForeignKey(nameof(User)), Required]
        public long UserID { get; set; }
        public User User { get; set; }

        [Required, MaxLength(100)]
        public string SuperVisor { get; set; }

        [Required, MaxLength(100)]
        public string Major { get; set; }
    }
}
