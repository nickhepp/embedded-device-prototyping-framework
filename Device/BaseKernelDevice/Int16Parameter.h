#ifndef __EDPF_INT16PARAMETER__
#define __EDPF_INT16PARAMETER__

#include "parameter.h"
#include "arduino.h"

class Int16Parameter : public Parameter
{

     using Parameter::Parameter;
  
  public:
    
    int16_t getValue(uint8_t pIdx);

    const char * getValueType();

    uint8_t getValueTypeID();
    
};



#endif //__EDPF_INT16PARAMETER__
