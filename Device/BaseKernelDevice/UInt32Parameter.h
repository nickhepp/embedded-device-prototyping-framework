

#ifndef __EDPF_UINT32PARAMETER__
#define __EDPF_UINT32PARAMETER__

#include "parameter.h"

class UInt32Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    uint32_t getValue(uint8_t pIdx, struct cmd_param cmd_params[]);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_UINT32PARAMETER__
