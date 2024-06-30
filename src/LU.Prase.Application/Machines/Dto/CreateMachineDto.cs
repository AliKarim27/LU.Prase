using LU.Prase.Entities.Enums;
using System.Net.Sockets;

namespace LU.Prase.Machines.Dto
{
    public class CreateMachineDto
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public long SectionId { get; set; }

        public MachineStates MachineStates { get; set; }

    }
}
