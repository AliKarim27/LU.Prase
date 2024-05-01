using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Email.Dto
{
	public class CreateEmailDto
	{
		public string Subject { get; set; }

		public string Body { get; set; }
		[Display(Name = "Recpients")]
		public string Recipients { get; set; }

	}
}
