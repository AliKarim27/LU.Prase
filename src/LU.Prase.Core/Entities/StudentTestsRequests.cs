using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Entities
{
    public class StudentTestsRequests : FullAuditedEntity<long>
    {
        public Student Student { get; set; }


    }
}
