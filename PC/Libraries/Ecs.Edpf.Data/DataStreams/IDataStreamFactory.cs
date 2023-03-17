using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.Logging;

namespace Ecs.Edpf.Data
{

    /// <summary>
    /// Factory for data streams.
    /// </summary>
    public interface IDataStreamFactory
    {

        /// <summary>
        /// Takes in stream settings and converts them to a data stream.
        /// </summary>
        /// <param name="streamSettings"></param>
        /// <returns></returns>
        IDataStream CreateStream(DataStreamSettings streamSettings, ILogger logger);

    }
}
