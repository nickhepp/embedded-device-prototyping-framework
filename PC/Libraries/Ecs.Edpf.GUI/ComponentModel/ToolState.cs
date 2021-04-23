using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public enum ToolState
    {
        /// <summary>
        /// The tool is on the roadmap for development.
        /// </summary>
        Roadmap,

        /// <summary>
        /// The tool is under development.
        /// </summary>
        InProgress,
        
        /// <summary>
        /// The tool is active.
        /// </summary>
        Active

    }
}
