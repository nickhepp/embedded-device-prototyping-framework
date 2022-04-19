
using Ecs.Edpf.Devices.ComponentModel.Macros;
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Ecs.Edpf.Devices.Test.ComponentModel.Macros
{

    [TestClass]
    public class DeviceTextMacroIterationMachineTest
    {

        private DeviceTextMacroIterationMachine _devTextMacroIterMachine;

        private StubDateTimeProvider _stubDateTimeProvider;

        [TestInitialize]
        public void InitializeTest()
        {
            _stubDateTimeProvider = new StubDateTimeProvider();
        }


        [TestMethod]
        public void GetNextDeviceTextLine_Loops_DoesntComplete()
        {
            //-- arrange
            const string line1 = "LINE 1";
            const string line2 = "LINE 2";
            InstructionCollection instructions = new InstructionCollection
            {
                Instructions = new List<Instruction>
                {
                    new DelayInstruction(delayInSeconds: 0.100),
                    new DeviceTextInstruction(line1),
                    new DelayInstruction(delayInSeconds: 0.100),
                    new DeviceTextInstruction(line2),
                }
            };

            double totalIterationTime = instructions.GetTotalTimeDuration();

            DateTime startTime = DateTime.Now;
            _stubDateTimeProvider.SetCurrentDateTime(startTime);

            _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(instructions, MacroExecutionType.Loop, _stubDateTimeProvider);

            ////-- act + assert
            //for (int k = 0; k < 3; k++)
            //{

            //    // this should return nothing, we are 50 millisecs before "LINE 1"
            //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds((k * totalIterationTime) + 50));
            //    Instruction devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
            //    Assert.IsNull(devTextLine);
            //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

            //    // this should return the first item
            //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds((k * totalIterationTime) + 120));
            //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
            //    Assert.IsNotNull(devTextLine);
            //    Assert.AreEqual(expected: line1, actual: devTextLine.DeviceText);
            //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

            //    // this should return nothing, we are 50 millisecs before "LINE 2"
            //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds((k * totalIterationTime) + 150));
            //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
            //    Assert.IsNull(devTextLine);
            //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

            //    // this should return the second item
            //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds((k * totalIterationTime) + 220));
            //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
            //    Assert.IsNotNull(devTextLine);
            //    Assert.AreEqual(expected: line2, actual: devTextLine.DeviceText);
            //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

            //    // we should be rolled over
            //    Assert.AreEqual(expected: k + 1, actual: _devTextMacroIterMachine.IterationCount);

            //}

        }



        //[TestMethod]
        //public void GetNextDeviceTextLine_NonLoop_Completes()
        //{
        //    //-- arrange
        //    string line1 = "LINE 1";
        //    string line2 = "LINE 2";
        //    DeviceTextMacro deviceTextMacro = new DeviceTextMacro
        //    {
        //        DeviceTextLines = new List<DeviceTextLine>
        //        {
        //            new DeviceTextLine { Delay = 100, DeviceText = line1 },
        //            new DeviceTextLine { Delay = 100, DeviceText = line2 },
        //        },
        //        Loop = false
        //    };

        //    DateTime startTime = DateTime.Now;
        //    _stubDateTimeProvider.SetCurrentDateTime(startTime);

        //    _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(deviceTextMacro, _stubDateTimeProvider);

        //    // this should return nothing, we are 50 millisecs before "LINE 1"
        //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(50));
        //    DeviceTextLine devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
        //    Assert.IsNull(devTextLine);
        //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

        //    // this should return the first item
        //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(120));
        //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
        //    Assert.IsNotNull(devTextLine);
        //    Assert.AreEqual(expected: line1, actual: devTextLine.DeviceText);
        //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

        //    // this should return nothing, we are 50 millisecs before "LINE 2"
        //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(150));
        //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
        //    Assert.IsNull(devTextLine);
        //    Assert.IsFalse(_devTextMacroIterMachine.Completed);

        //    // this should return the second item
        //    _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(220));
        //    devTextLine = _devTextMacroIterMachine.GetNextDeviceTextLine();
        //    Assert.IsNotNull(devTextLine);
        //    Assert.AreEqual(expected: line2, actual: devTextLine.DeviceText);

        //    // and now it should be done
        //    Assert.IsTrue(_devTextMacroIterMachine.Completed);

        //}



    }
}
