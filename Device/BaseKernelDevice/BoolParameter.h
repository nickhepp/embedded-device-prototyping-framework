#ifndef __EDPF_BOOLPARAMETER__
#define __EDPF_BOOLPARAMETER__

#include "parameter.h"

class BoolParameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    bool getValue(uint8_t pIdx, struct cmd_param cmd_params[]);

    const char * getValueType();

    uint8_t getValueTypeID();

    
};



#endif //__EDPF_BOOLPARAMETER__
