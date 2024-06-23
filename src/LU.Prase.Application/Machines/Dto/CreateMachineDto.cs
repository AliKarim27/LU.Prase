using LU.Prase.Entities.Enums;

namespace LU.Prase.Machines.Dto
{
    public class CreateMachineDto
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public MachineStates MachineStates { get; set; }

    }
}
