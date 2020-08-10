using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject.Devices
{
    [TestClass]
    public class BaseKernelDeviceTest
    {



        //[TestMethod]
        //public void TestPrintCommandParams()
        //{
        //    // find a connected kernel device
        //    List<string> connectedPortNames = KernelDeviceUtility.GetConnectedDevicePorts();
        //    if (connectedPortNames.Count != 1)
        //    {
        //        Assert.Inconclusive($"Invalid number of base kernel devices found: {connectedPortNames.Count}.");
        //    }

        //    using (BaseKernelDevice bkd = new BaseKernelDevice())
        //    {
        //        bkd.ConnectionInfo = new DeviceConnectionInfo
        //        {
        //            DeviceBaudRate = DeviceConnectionInfo.BaudRate.Baudrate115200,
        //            DevicePort = connectedPortNames[0]
        //        };

        //        Assert.IsTrue(bkd.Open());

        //        Dictionary<int, string> paramValues = new Dictionary<int, string>();
        //        int paramCnt = bkd.GetCommandParameterCount();
        //        if (paramCnt < 1)
        //        {
        //            Assert.Inconclusive("Did not get a valid parameter count.");
        //        }
                

        //        for (int paramIdx = 0; paramIdx < paramCnt; paramIdx++)
        //        {
        //            string paramValue = $"salt{paramIdx}";
        //            paramValues[paramIdx] = paramValue;
        //            bkd.SetCommandParameter(paramIdx, paramValue);
        //        }

        //        Dictionary<int, string> returnedCmdParams = bkd.GetCommandParams();




        //    }



        //}




        //[TestMethod]
        //public void TestEchoCommandParameter()
        //{

        //}


    }
}
