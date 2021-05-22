#ifndef __EDPF_INT8PARAMETER__
#define __EDPF_INT8PARAMETER__

#include "parameter.h"

class Int8Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    int8_t getValue(uint8_t pIdx);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_INT8PARAMETER__
