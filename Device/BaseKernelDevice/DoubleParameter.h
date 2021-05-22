#ifndef __EDPF_DOUBLEPARAMETER__
#define __EDPF_DOUBLEPARAMETER__

#include "parameter.h"

class DoubleParameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    double getValue(uint8_t pIdx);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_DOUBLEPARAMETER__
