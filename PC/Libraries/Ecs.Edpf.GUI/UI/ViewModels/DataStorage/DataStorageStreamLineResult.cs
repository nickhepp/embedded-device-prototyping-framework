using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage
{

    /// <summary>
    /// Captures the line of text returned from the device that was attempted to be recorded.
    /// </summary>
    public class DataStorageStreamLineResult
    {
        /// <summary>
        /// The line of recorded (or errored on recording attempt) device text.
        /// </summary>
        public string DeviceTextLine { get; set; }

        /// <summary>
        /// When the line was recorded.
        /// </summary>
        public DateTime TimeRecorded { get; set; }

        /// <summary>
        /// The error that occurred during the time of recording.  NULL otherwise.
        /// </summary>
        public Exception Exception { get; set; }

    }
}
