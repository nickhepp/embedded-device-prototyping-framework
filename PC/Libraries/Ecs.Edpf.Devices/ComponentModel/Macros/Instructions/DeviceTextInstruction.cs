using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class DeviceTextInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.DeviceText;

        //public string DeviceText { get; set; } = "";
        private string _deviceText;

        public DeviceTextInstruction(string instructionLine)
        {
            _deviceText = instructionLine;
        }

        public override string GetDeviceText()
        {
            return _deviceText;
        }

        public override Instruction Copy()
        {
            return new DeviceTextInstruction(_deviceText);
        }

    }
}
