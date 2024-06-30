using LU.Prase.Entities.Enums;
using System.Collections.Generic;

namespace LU.Prase.Sections.Dto
{
    public class CreateSectionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long DepartementId { get; set; }
        public List<UserDto> Responsibles { get; set; }

    }
}
