using LU.Prase.Entities.Enums;
using System.Collections.Generic;

namespace LU.Prase.Department.Dto
{
    public class CreateDepartementDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<UserDto> Responsibles { get; set; }

    }
}
