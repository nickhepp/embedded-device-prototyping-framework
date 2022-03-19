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
    public class DelayInstructionTest
    {

        


        [TestInitialize]
        public void InitializeTest()
        {

        }


        [DataTestMethod]
        [DataRow("--sleep 500ms", 0.5)]
        [DataRow("-- sleep 750 ms", 0.75)]
        [DataRow("--sleep 5.12s", 5.12)]
        [DataRow("-- sleep 7.54 s", 7.54)]
        public void Cstor_ContainsValidText_TimeGotten(string instructionLine, double delayInSecs)
        {
            //-- arrange

            //-- act
            DelayInstruction delayInstruction = new DelayInstruction(instructionLine);


            //-- assert
            Assert.AreEqual(expected: delayInSecs, delayInstruction.DelayInSeconds);
        }

        [DataTestMethod]
        [DataRow("not a valid one")]
        [DataRow("--sleep missing number ms")]          // missing number
        [DataRow("--sleep 1.23")]                       // missing unit
        [DataRow("-slep 45.4s")]                        // misspelled sleep
        public void Cstor_ContainsInvalidText_ExceptionThrown(string instructionLine)
        {
            Assert.ThrowsException<Exception>(() => new DelayInstruction(instructionLine));
        }


    }
}
