using Ecs.Edpf.GUI.ComponentModel.Macros;
using Ecs.Edpf.GUI.ComponentModel.Macros.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.ComponentModel.Macros.Instructions
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

            DelayInstruction delayInstruction0 = instrColl.Instructions[0] as DelayInstruction;
            Assert.IsNotNull(delayInstruction0);
            Assert.AreEqual(expected: 0.5, delayInstruction0.DelayInSeconds, 0.001);

            DelayInstruction delayInstruction1 = instrColl.Instructions[1] as DelayInstruction;
            Assert.IsNotNull(delayInstruction1);
            Assert.AreEqual(expected: 1.2, delayInstruction1.DelayInSeconds, 0.001);

            //Command

        }


    }
}
