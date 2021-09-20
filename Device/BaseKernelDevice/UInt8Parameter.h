#ifndef __EDPF_UINT8PARAMETER__
#define __EDPF_UINT8PARAMETER__

#include "parameter.h"

#define UINT8_TYPE_NAME  "uint8"

class UInt8Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    uint8_t getValue(uint8_t pIdx, struct cmd_param cmd_params[]);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_UINT8PARAMETER__
