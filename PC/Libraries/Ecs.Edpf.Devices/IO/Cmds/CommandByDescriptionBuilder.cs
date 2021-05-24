using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class CommandByDescriptionBuilder
    {

        private static IParameter GetBoolParameter(ParameterArgs paramArgs)
        {
            return new BoolParameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetDoubleParameter(ParameterArgs paramArgs)
        {
            return new DoubleParameter(paramArgs.ParameterName, paramArgs.ParameterIndex); ;
        }

        private static IParameter GetUInt8Parameter(ParameterArgs paramArgs)
        {
            return new UInt8Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetUInt16Parameter(ParameterArgs paramArgs)
        {
            return new UInt16Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetUInt32Parameter(ParameterArgs paramArgs)
        {
            return new UInt32Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetInt8Parameter(ParameterArgs paramArgs)
        {
            return new Int8Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetInt16Parameter(ParameterArgs paramArgs)
        {
            return new Int16Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static IParameter GetInt32Parameter(ParameterArgs paramArgs)
        {
            return new Int32Parameter(paramArgs.ParameterName, paramArgs.ParameterIndex);
        }

        private static Dictionary<string, Func<ParameterArgs, IParameter>> _typeMappings = new Dictionary<string, Func<ParameterArgs, IParameter>>
        {
            { "bool", GetBoolParameter },
            { "double", GetDoubleParameter },
            { "uint8", GetUInt8Parameter },
            { "uint16", GetUInt16Parameter },
            { "uint32", GetUInt32Parameter },
            { "int8", GetInt8Parameter },
            { "int16", GetInt16Parameter },
            { "int32", GetInt32Parameter },
        };


        private class ParameterArgs
        {
            public int ParameterIndex { get; set; }

            public string ParameterType { get; set; }

            public string ParameterDescription { get; set; }

            public string ParameterName { get; set; }

        }

        private IParameter GetParameterByDescription(string paramDesc)
        {
            const string paramIndexStart = "p[";
            const string paramIndexEnd = "]:";
            const string typeStart = "(";
            const string typeEnd = ")";

            IParameter param = null;

            int paramIndexStartIdx = paramDesc.IndexOf(paramIndexStart);
            int paramIndexEndIdx = paramDesc.IndexOf(paramIndexEnd);
            int typeStartIdx = paramDesc.IndexOf(typeStart);
            int typeEndIdx = paramDesc.IndexOf(typeEnd);

            if ((paramIndexStartIdx == 0) && 
                    (paramIndexEndIdx >= (paramIndexStartIdx + paramIndexStart.Length + 1)) &&
                    (typeStartIdx == (paramIndexEndIdx + paramIndexEnd.Length)) &&
                    (typeEndIdx > (typeStartIdx + typeEnd.Length)))
            {
                int paramIdx;
                string paramIdxStr = paramDesc.Substring(paramIndexStartIdx + paramIndexStart.Length, paramIndexEndIdx - (paramIndexStartIdx + paramIndexStart.Length));
                if (!int.TryParse(paramIdxStr, out paramIdx))
                {
                    throw new Exception($"Couldnt parse parameter index: {paramDesc}");
                }

                string typeStr = paramDesc.Substring(typeStartIdx + typeStart.Length, typeEndIdx - (typeStartIdx + typeStart.Length));
                Func<ParameterArgs, IParameter> parameterFactory;
                if (!_typeMappings.TryGetValue(typeStr, out parameterFactory))
                {
                    throw new Exception($"Couldnt parse type: {paramDesc}");
                }

                string paramName = paramDesc.Substring(typeEndIdx + typeEnd.Length);

                ParameterArgs pArgs = new ParameterArgs
                {
                    ParameterIndex = paramIdx,
                    ParameterType = typeStr,
                    ParameterDescription = paramDesc,
                    ParameterName = paramName
                };
                param = parameterFactory(pArgs);
            }
            else
            {
                throw new Exception($"Parameter description was not the expected format: {paramDesc}");
            }

            return param;
        }


        public IDeviceCommand GetCommandByDescription(string description)
        {
            List<string> cmdParamParts = description.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (cmdParamParts.Count != 2 || !cmdParamParts[1].StartsWith("{") || !cmdParamParts[1].EndsWith("}"))
            {
                throw new Exception($"Invalid Command description: {description}");
            }

            List<string> paramDescs = cmdParamParts[1].Substring(1, cmdParamParts[1].Length - 2).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<IParameter> parameters = new List<IParameter>();
            foreach (string paramDesc in paramDescs)
            {
                parameters.Add(GetParameterByDescription(paramDesc));
            }

            ReadOnlyCollection<IParameter> paramsCollection = new ReadOnlyCollection<IParameter>(parameters);
            AutoBuiltCommand autoBuiltCommand = new AutoBuiltCommand(cmdParamParts[0], paramsCollection);
            return autoBuiltCommand;
        }

    }
}
