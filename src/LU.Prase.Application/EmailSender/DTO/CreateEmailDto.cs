using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.EmailSender.DTO
{
    public class CreateEmailDto
    {
        public string Recipients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }


    }
}
