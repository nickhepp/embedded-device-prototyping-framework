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
    public class InstructionCollectionTest
    {

        [TestInitialize]
        public void InitializeTest()
        {
        }

        [TestMethod]
        public void GetTimeGroupings_ThreeGroupsExist_ThreeGroupsGotten()
        {
            //-- arrange
            // group 0
            const string grp0Idx0DevText = "0-0";
            const double grp0Delay = InstructionCollection.MinimumTimeGroupingOffsetInSeconds;
            DeviceTextInstruction grp0Idx0DevTextInstr = new DeviceTextInstruction(grp0Idx0DevText);
            const string grp0Idx1DevText = "0-1";
            DeviceTextInstruction grp0Idx1DevTextInstr = new DeviceTextInstruction(grp0Idx1DevText);
            CommentInstruction grp0Idx2CmtInstr = new CommentInstruction("0-2");

            // group 1
            const double grp1Idx0Delay = 0.500;
            DelayInstruction grp1Idx0DelayInstr = new DelayInstruction(grp1Idx0Delay);
            const string grp1Idx1DevText = "1-1";
            DeviceTextInstruction grp1Idx1DevTextInstr = new DeviceTextInstruction(grp1Idx1DevText);
            string grp1Idx2DevText = "1-2";
            DeviceTextInstruction grp1Idx2DevTextInstr = new DeviceTextInstruction(grp1Idx2DevText);
            CommentInstruction grp1Idx3CmtInstr = new CommentInstruction("1-3");

            // group 2
            const double grp2Idx0Delay = 0.700;
            DelayInstruction grp2Idx0DelayInstr = new DelayInstruction(grp2Idx0Delay);
            CommentInstruction grp2Idx1CmtInstr = new CommentInstruction("2-1");
            const string grp2Idx2DevText = "2-2";
            DeviceTextInstruction grp2Idx2DevTextInstr = new DeviceTextInstruction(grp2Idx2DevText);
            const string grp2Idx3DevText = "2-3";
            DeviceTextInstruction grp2Idx3DevTextInstr = new DeviceTextInstruction(grp2Idx3DevText);

            InstructionCollection instructionCollection = new InstructionCollection(
                new List<Instruction>
                {
                    grp0Idx0DevTextInstr, grp0Idx1DevTextInstr, grp0Idx2CmtInstr,
                    grp1Idx0DelayInstr, grp1Idx1DevTextInstr, grp1Idx2DevTextInstr, grp1Idx3CmtInstr,
                    grp2Idx0DelayInstr, grp2Idx1CmtInstr, grp2Idx2DevTextInstr, grp2Idx3DevTextInstr
                }
            );

            //-- act
            List<TimeGrouping> groupings = instructionCollection.GetTimeGroupings().ToList();

            //-- assert
            Assert.AreEqual(expected: 3, groupings.Count, "Did not find the expected number of groupings.");

            foreach (TimeGrouping grouping in groupings)
            {
                Assert.AreEqual(expected: 2, grouping.DeviceTextInstructions.Count, "Did not find the expected amount of DeviceTextInstructions in each grouping.");
            }

            Assert.AreEqual(expected: grp0Delay, groupings[0].TimeOffsetInSeconds, "Grouping 0 did not have the correct time offest.");
            Assert.AreEqual(expected: grp0Delay + grp1Idx0Delay, groupings[1].TimeOffsetInSeconds, "Grouping 1 did not have the correct time offest.");
            Assert.AreEqual(expected: grp0Delay + grp1Idx0Delay + grp2Idx0Delay, groupings[2].TimeOffsetInSeconds, "Grouping 2 did not have the correct time offest.");

            List<(int grpIdx, int itemIdx, DeviceTextInstruction devTxtInstr)> mappings = new List<(int grpIdx, int itemIdx, DeviceTextInstruction devTxtInstr)>
            {
                (0, 0, grp0Idx0DevTextInstr), (0, 1, grp0Idx1DevTextInstr),
                (1, 0, grp1Idx1DevTextInstr), (1, 1, grp1Idx2DevTextInstr),
                (2, 0, grp2Idx2DevTextInstr), (2, 1, grp2Idx3DevTextInstr)
            };

            foreach ((int grpIdx, int itemIdx, DeviceTextInstruction devTxtInstr) mapping in mappings)
            {
                Assert.IsTrue(ReferenceEquals(groupings[mapping.grpIdx].DeviceTextInstructions[mapping.itemIdx], mapping.devTxtInstr));
            }
            
        }



    }
}
