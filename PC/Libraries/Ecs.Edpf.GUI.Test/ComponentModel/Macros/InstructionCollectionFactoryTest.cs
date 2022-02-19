using Ecs.Edpf.GUI.ComponentModel.Macros;
using Ecs.Edpf.GUI.ComponentModel.Macros.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.ComponentModel.Macros
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
            DeviceTextMacroInitArgs initArgs = new DeviceTextMacroInitArgs
            {
                Instructions = new List<string>
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
            Assert.AreEqual(expected: 4, instrColl.Instructions.Count);
            
            DelayInstruction delayInstr0 = instrColl.Instructions[0] as DelayInstruction;
            Assert.IsNotNull(delayInstr0);
            Assert.AreEqual(expected: 0.5, delayInstr0.DelayInSeconds);

            DelayInstruction delayInstr1 = instrColl.Instructions[1] as DelayInstruction;
            Assert.IsNotNull(delayInstr1);
            Assert.AreEqual(expected: 1.2, delayInstr1.DelayInSeconds);

            DeviceTextInstruction deviceTextInstruction = instrColl.Instructions[2] as DeviceTextInstruction;
            Assert.IsNotNull(deviceTextInstruction);

            CommentInstruction commentInstruction = instrColl.Instructions[3] as CommentInstruction;
            Assert.IsNotNull(commentInstruction);

        }


    }
}
