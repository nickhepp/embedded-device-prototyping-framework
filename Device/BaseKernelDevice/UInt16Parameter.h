
#ifndef __EDPF_UINT16PARAMETER__
#define __EDPF_UINT16PARAMETER__

#include "parameter.h"
#include <arduino.h>

class UInt16Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    uint16_t getValue(uint8_t pIdx, struct cmd_param cmd_params[]);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_UINT16PARAMETER__
