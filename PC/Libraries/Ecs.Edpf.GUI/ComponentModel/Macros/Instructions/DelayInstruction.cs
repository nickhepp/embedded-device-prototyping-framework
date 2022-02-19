using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
{
    public class DelayInstruction : Instruction
    {

        public static readonly string[] DelayPrefices = new string[] { "--sleep", "-- sleep"};

        private const string MillisecsDelayTimeUnit = "ms";
        private const string SecondsDelayTimeUnit = "s";

        public override InstructionType InstructionType => InstructionType.Delay;

        public double DelayInSeconds { get; set; }

        public DelayInstruction(string instructionLine)
        {
            int? prefixIndex = null;
            if (instructionLine.StartsWith(DelayPrefices[0]))
            {
                prefixIndex = 0;
            }
            else if (instructionLine.StartsWith(DelayPrefices[1]))
            {
                prefixIndex = 1;
            }

            if (prefixIndex == null)
            {
                throw new Exception($"Did not find delay prefix of '{DelayPrefices[0]}' or '{DelayPrefices[1]}'.");
            }

            string timeSubStr = instructionLine.Substring(DelayPrefices[prefixIndex.Value].Length).Trim();
            string timeNumbSubStr;

            // look for an ending
            double factor;
            if (timeSubStr.EndsWith(MillisecsDelayTimeUnit))
            {
                factor = 0.001;
                timeNumbSubStr = timeSubStr.Substring(0, timeSubStr.Length - MillisecsDelayTimeUnit.Length).Trim();
            }
            else if (timeSubStr.EndsWith(SecondsDelayTimeUnit))
            {
                factor = 1.0;
                timeNumbSubStr = timeSubStr.Substring(0, timeSubStr.Length - SecondsDelayTimeUnit.Length).Trim();
            }
            else
            {
                throw new Exception($"Instruction line '{instructionLine}' does not end with the time unit of '{SecondsDelayTimeUnit}' or '{MillisecsDelayTimeUnit}'.");
            }

            if (!double.TryParse(timeNumbSubStr, out double timeNumb))
            {
                throw new Exception($"Instruction line '{instructionLine}' does not contain the expected number to use for a delay.");
            }

            DelayInSeconds = factor * timeNumb;
        }



    }
}
