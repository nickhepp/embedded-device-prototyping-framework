
#include "common.h"
#include "KernelDevice.h"


KernelDevice deviceIoHelper;

void setup() 
{

    deviceIoHelper.init();
 
}

void loop() 
{

    deviceIoHelper.loopAction();

}
