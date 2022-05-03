
using Ecs.Edpf.Devices.ComponentModel.Macros;
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecs.Edpf.Devices.Test.ComponentModel.Macros
{

    [TestClass]
    public class DeviceTextMacroIterationMachineTest
    {

        const string line00 = "LINE 00";
        const string line01 = "LINE 01";
        const string line02 = "LINE 02";

        const string line10 = "LINE 10";
        const string line11 = "LINE 11";

        const string line20 = "LINE 20";
        const string line21 = "LINE 21";
        const string line22 = "LINE 22";
        const string line23 = "LINE 23";

        const string line30 = "LINE 30";
        const string line31 = "LINE 31";


        const double firstDelay = 0.1;
        const double secondDelay = 0.05;
        const double thirdDelay = 0.025;
        const double fourthDelay = 0.0125;
        const double fifthDelay = 0.02;

        private DeviceTextMacroIterationMachine _devTextMacroIterMachine;

        private StubDateTimeProvider _stubDateTimeProvider;

        [TestInitialize]
        public void InitializeTest()
        {
            _stubDateTimeProvider = new StubDateTimeProvider();
        }

        private InstructionCollection GetQuadInstructionCollection()
        {
            InstructionCollection instructions = new InstructionCollection(
                new List<Instruction>
                {
                    // [0], first TimeGrouping
                    new DelayInstruction(delayInSeconds: firstDelay),
                    new DeviceTextInstruction(line00),
                    new DeviceTextInstruction(line01),
                    new DeviceTextInstruction(line02),

                    // [1], second TimeGrouping
                    new DelayInstruction(delayInSeconds: secondDelay),
                    new DelayInstruction(delayInSeconds: thirdDelay),
                    new DeviceTextInstruction(line10),
                    new DeviceTextInstruction(line11),

                    // [2], third TimeGrouping
                    new DelayInstruction(fourthDelay),
                    new DeviceTextInstruction(line20),
                    new DeviceTextInstruction(line21),
                    new DeviceTextInstruction(line22),
                    new DeviceTextInstruction(line23),

                    // [3], fourth TimeGrouping
                    new DelayInstruction(fifthDelay),
                    new DeviceTextInstruction(line30),
                    new DeviceTextInstruction(line31),

                }
            );

            return instructions;
        }

        [TestMethod]
        public void GetNextTimeGroupings_LongDelay_CorrectOnesNext()
        {
            //-- arrange
            InstructionCollection instructions = GetQuadInstructionCollection();
            List<TimeGrouping> srcGroupings = instructions.GetTimeGroupings().ToList();

            double totalIterationTime = instructions.GetTotalTimeDuration();

            DateTime startTime = DateTime.Now;
            _stubDateTimeProvider.SetCurrentDateTime(startTime);
            _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(instructions, MacroExecutionType.Loop, _stubDateTimeProvider);

            // find the delay for the first two groups, set that delay, get the groups
            double twoGroupsDelayInSeconds = firstDelay + secondDelay + thirdDelay + (fourthDelay / 2.0);
            _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(twoGroupsDelayInSeconds * 1000));
            List<TimeGrouping> timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
            Assert.AreEqual(expected: 2, actual: timeGroupings.Count);
            Assert.IsTrue(object.ReferenceEquals(timeGroupings[0], srcGroupings[0]));
            Assert.IsTrue(object.ReferenceEquals(timeGroupings[1], srcGroupings[1]));

            // with this amount of delay by itself we should get the last two groups.
            double lastTwoGroupsDelayInSeconds = totalIterationTime + (firstDelay / 2);
            // but we want to test many total iterations of delay
            lastTwoGroupsDelayInSeconds += 10 * totalIterationTime;
            _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(lastTwoGroupsDelayInSeconds * 1000));
            timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
            Assert.AreEqual(expected: 2, actual: timeGroupings.Count);
            Assert.IsTrue(object.ReferenceEquals(timeGroupings[0], srcGroupings[2]));
            Assert.IsTrue(object.ReferenceEquals(timeGroupings[1], srcGroupings[3]));
        }


        [TestMethod]
        public void GetNextTimeGroupings_LongDelayOneGrouping_GetsGroup()
        {
            //-- arrange
            InstructionCollection instructions = new InstructionCollection(
                new List<Instruction>
                {
                    new DeviceTextInstruction(line31)
                });

            DateTime startTime = DateTime.Now;
            _stubDateTimeProvider.SetCurrentDateTime(startTime);

            _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(instructions, MacroExecutionType.Loop, _stubDateTimeProvider);

            double delayInMilliseconds = 1000 * InstructionCollection.MinimumTimeGroupingOffsetInSeconds * 50;
            _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(delayInMilliseconds));

            //-- act
            List<TimeGrouping> groupings = _devTextMacroIterMachine.GetNextTimeGroupings();

            //-- assert
            Assert.AreEqual(expected: 1, actual: groupings.Count);
        }



        [TestMethod]
        public void GetNextTimeGroupings_Loops_DoesntComplete()
        {
            //-- arrange
            InstructionCollection instructions = GetQuadInstructionCollection();

            double totalIterationTime = instructions.GetTotalTimeDuration();

            DateTime startTime = DateTime.Now;
            _stubDateTimeProvider.SetCurrentDateTime(startTime);

            _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(instructions, MacroExecutionType.Loop, _stubDateTimeProvider);

            List<TimeGrouping> srcGroupings = instructions.GetTimeGroupings().ToList();

            //-- act + assert
            for (int k = 0; k < 3; k++)
            {

                // this should return nothing, we are 1/2 way to the first delay
                double offset = (k * totalIterationTime) + (firstDelay / 2.0);
                _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(offset * 1000));
                List<TimeGrouping> timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 0, timeGroupings.Count);
                Assert.IsFalse(_devTextMacroIterMachine.Completed);

                // this should return the first group
                offset = (k * totalIterationTime) + firstDelay + (secondDelay / 2);
                _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(offset * 1000));
                timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 1, actual: timeGroupings.Count);
                Assert.IsTrue(ReferenceEquals(srcGroupings[0], timeGroupings[0]));
                Assert.IsFalse(_devTextMacroIterMachine.Completed);

                // now do the same time, but this time we do it, it should return an empty list
                timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 0, actual: timeGroupings.Count);
                Assert.IsFalse(_devTextMacroIterMachine.Completed);

                // now make a time past the 2nd and 3rd delays, this should return the 2nd set
                offset = (k * totalIterationTime) + firstDelay + secondDelay + thirdDelay + (fourthDelay / 2);
                _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(offset * 1000));
                timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 1, actual: timeGroupings.Count);
                Assert.IsTrue(ReferenceEquals(srcGroupings[1], timeGroupings[0]));
                Assert.IsFalse(_devTextMacroIterMachine.Completed);

                // now do the same time, but this time we do it, it should return an empty list
                timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 0, actual: timeGroupings.Count);
                Assert.IsFalse(_devTextMacroIterMachine.Completed);

                // now set the time to return the 3rd and 4th sets
                offset = (k * totalIterationTime) + firstDelay + secondDelay + thirdDelay + fourthDelay  + fifthDelay + (firstDelay / 2.0);
                _stubDateTimeProvider.SetCurrentDateTime(startTime.AddMilliseconds(offset * 1000));
                timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();
                Assert.AreEqual(expected: 2, actual: timeGroupings.Count);
                Assert.IsTrue(ReferenceEquals(srcGroupings[2], timeGroupings[0]));
                Assert.IsTrue(ReferenceEquals(srcGroupings[3], timeGroupings[1]));
                Assert.IsFalse(_devTextMacroIterMachine.Completed);
            }

        }


        [TestMethod]
        public void GetNextTimeGroupings_NonLoop_Completes()
        {
            //-- arrange
            InstructionCollection instructions = GetQuadInstructionCollection();

            double totalIterationTime = instructions.GetTotalTimeDuration();

            DateTime startTime = DateTime.Now;
            _stubDateTimeProvider.SetCurrentDateTime(startTime);

            _devTextMacroIterMachine = new DeviceTextMacroIterationMachine(instructions, MacroExecutionType.OneShot, _stubDateTimeProvider);

            List<TimeGrouping> srcGroupings = instructions.GetTimeGroupings().ToList();
            double offset = totalIterationTime + (firstDelay * 1000);
            _stubDateTimeProvider.SetCurrentDateTime(startTime.AddSeconds(offset));

            //-- act + assert
            Assert.IsFalse(_devTextMacroIterMachine.Completed);
            List<TimeGrouping> timeGroupings = _devTextMacroIterMachine.GetNextTimeGroupings();

            Assert.AreEqual(expected: 4, actual: timeGroupings.Count);
            Assert.IsTrue(ReferenceEquals(srcGroupings[0], timeGroupings[0]));
            Assert.IsTrue(ReferenceEquals(srcGroupings[1], timeGroupings[1]));
            Assert.IsTrue(ReferenceEquals(srcGroupings[2], timeGroupings[2]));
            Assert.IsTrue(ReferenceEquals(srcGroupings[3], timeGroupings[3]));
            Assert.IsTrue(_devTextMacroIterMachine.Completed);
        }



    }
}
