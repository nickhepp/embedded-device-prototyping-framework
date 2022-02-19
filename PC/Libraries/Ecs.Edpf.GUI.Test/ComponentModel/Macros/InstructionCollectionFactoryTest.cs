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
            

        }


    }
}
