#ifndef __EDPF_INT32PARAMETER__
#define __EDPF_INT32PARAMETER__

#include "parameter.h"
#include <arduino.h>

class Int32Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    int32_t getValue(uint8_t pIdx, struct cmd_param cmd_params[]);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_INT32PARAMETER__
