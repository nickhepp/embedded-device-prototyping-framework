using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
{
    public enum InstructionType
    {
        /// <summary>
        /// Text that should be sent to the device.
        /// </summary>
        DeviceText,

        /// <summary>
        /// A delay used to space apart the sending of device text.
        /// </summary>
        Delay,

        /// <summary>
        /// A comment embedded in the text
        /// </summary>
        Comment,

    }
}
