using Ecs.Edpf.Devices.ComponentModel.Macros;
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.ComponentModel.Macros.Instructions
{

    [TestClass]
    public class InstructionCollectionFactoryTest
    {

        private InstructionCollectionFactory _factory;


        [TestInitialize]
        public void InitializeTest()
        {
            _factory = new InstructionCollectionFactory();
        }



        [TestMethod]
        public void ParseDeviceTextMacroInitArgs_DifferentTypes_TypesFound()
        {
            //-- arrange
            InstructionCollectionInitArgs initArgs = new InstructionCollectionInitArgs
            {
                InstructionsLines = new List<string>
                {
                    $"{DelayInstruction.DelayPrefices.First()} 500ms",
                    $"{DelayInstruction.DelayPrefices.Last()} 1.2 s",
                    "cmd:doStuff()",
                    $"{CommentInstruction.CommentPrefix} comment text",
                }
            };

            //-- act
            InstructionCollection instrColl = _factory.ParseDeviceTextMacroInitArgs(initArgs);


            //-- assert
            Assert.AreEqual(expected: 4, instrColl.InstructionsCount);
            
            List<Instruction> instructions = instrColl.Instructions.ToList();
            DelayInstruction delayInstr0 = instructions[0] as DelayInstruction;
            Assert.IsNotNull(delayInstr0);
            Assert.AreEqual(expected: 0.5, delayInstr0.DelayInSeconds);

            DelayInstruction delayInstr1 = instructions[1] as DelayInstruction;
            Assert.IsNotNull(delayInstr1);
            Assert.AreEqual(expected: 1.2, delayInstr1.DelayInSeconds);

            DeviceTextInstruction deviceTextInstruction = instructions[2] as DeviceTextInstruction;
            Assert.IsNotNull(deviceTextInstruction);

            CommentInstruction commentInstruction = instructions[3] as CommentInstruction;
            Assert.IsNotNull(commentInstruction);

        }


    }
}
