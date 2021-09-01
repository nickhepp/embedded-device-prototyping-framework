#ifndef __EDPF_PARAMETER__
#define __EDPF_PARAMETER__

#include <stdint.h>

class Parameter
{
    public:
    
        Parameter();

        virtual const char * getValueType() = 0;

        virtual uint8_t getValueTypeID() = 0;
    
    private:

};



#endif //__EDPF_PARAMETER__
