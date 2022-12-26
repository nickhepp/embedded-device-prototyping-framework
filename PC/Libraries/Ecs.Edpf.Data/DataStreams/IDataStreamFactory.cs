using System;
using StrmSettings = Ecs.Edpf.Data.StreamSettings;


namespace Ecs.Edpf.Data
{
    public interface IDataStreamFactory
    {

        IDataStream CreateStream(StrmSettings.StreamSettings streamSettings);

    }
}
