using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections
{

    /// <summary>
    /// A device connection.  Note one should not operate with this directly, but rather through a device class.
    /// </summary>
    public interface IConnection : IDisposable
    {

        IConnectionInfo ConnectionInfo { get; }

        int CommandTimeout { get; set; }


        void Open(IConnectionInfo connectionInfo);

        /// <summary>
        /// Closes the connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Reads the device until the read buffer is cleared.
        /// </summary>
        /// <returns></returns>
        string ReadToEndOfBuffer();

        /// <summary>
        /// Reads to the end of the device resoponse.
        /// </summary>
        /// <exception>Timeout has expired.</exception>
        /// <returns></returns>
        (string text, bool endOfResponse) ReadToEndOfResponse();


        void Write(string text);


    }
}
